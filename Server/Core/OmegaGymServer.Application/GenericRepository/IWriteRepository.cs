using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Application.GenericRepository;

public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T entity);
    Task<bool> AddRangeAsync(List<T> entities);
    bool Remove(T entity);
    Task<bool> RemoveAsync(Guid id);
    bool Update(T entity);

    Task<int> SaveAsync();
}

