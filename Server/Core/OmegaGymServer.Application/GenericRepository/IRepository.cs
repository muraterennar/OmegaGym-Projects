using Microsoft.EntityFrameworkCore;
using OmegaGymServer.Domain.Entities.Common;

namespace OmegaGymServer.Application.GenericRepository;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}

