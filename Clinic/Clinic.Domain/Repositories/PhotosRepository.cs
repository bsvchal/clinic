using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;

namespace Clinic.Domain.Repositories;

public class PhotosRepository : IBaseRepository
{
    private readonly AppDbContext _appDbContext;

    public PhotosRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public Task<Guid?> CreateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Photos.Remove((Photo)entity), cancellationToken);
    }

    public IQueryable<BaseEntity> Get()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Photos.Update((Photo)entity), cancellationToken);
    }
}
