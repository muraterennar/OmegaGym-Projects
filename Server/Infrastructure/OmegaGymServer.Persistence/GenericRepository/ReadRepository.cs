using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OmegaGymServer.Application.GenericRepository;
using OmegaGymServer.Domain.Entities.Common;
using OmegaGymServer.Persistence.Contexts;

namespace OmegaGymServer.Persistence.GenericRepository;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly OmegaGymEfDbContext _context;

    public ReadRepository(OmegaGymEfDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracing = true)
    {
        var query = Table.AsQueryable();
        if (!tracing)
            query = query.AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool tracing = true)
    {
        var query = Table.Where(expression);
        if (!tracing)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> expression, bool tracing = true)
    {
        var query = Table.AsQueryable();
        if (!tracing)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(expression);
    }

    public async Task<T> GetByIdAsync(Guid id, bool tracing = true)
    {
        var query = Table.AsQueryable();
        if (!tracing)
            query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(data => data.Id == id);
    }

}

