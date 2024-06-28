using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _appDbContext;

    public BaseRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Guid?> CreateAsync(
        T entity, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = 
            await _appDbContext.Set<T>().AddAsync(entity, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public Task DeleteAsync(
        T entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Set<T>().Remove(entity), cancellationToken);
    }

    public virtual async Task<List<T>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Set<T>()
            .Where(e => !e.IsDeleted)
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Set<T>()
            .Where(e => !e.IsDeleted)
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public Task UpdateAsync(
        T entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Set<T>().Update(entity), cancellationToken);
    }
}
