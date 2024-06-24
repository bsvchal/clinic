using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class OfficesRepository : IBaseRepository
{
    private readonly AppDbContext _appDbContext;

    public OfficesRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Guid?> CreateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = await _appDbContext.Offices
            .AddAsync((Office)entity, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public Task DeleteAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Offices.Remove((Office)entity), cancellationToken);
    }

    public IQueryable<BaseEntity> Get()
    {
        return _appDbContext.Offices
            .Include(o => o.Doctors)
            .Include(o => o.Receptionists);
    }

    public Task UpdateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Offices.Update((Office)entity), cancellationToken);
    }
}
