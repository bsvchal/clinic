using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class ReceptionistsRepository : IBaseRepository
{
    private readonly AppDbContext _appDbContext;

    public ReceptionistsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Guid?> CreateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = await _appDbContext.Receptionists
            .AddAsync((Receptionist)entity, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public Task DeleteAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Receptionists.Remove((Receptionist)entity), cancellationToken);
    }

    public IQueryable<BaseEntity> Get()
    {
        return _appDbContext.Receptionists
             .Include(r => r.Account)
             .Include(r => r.Office);
    }

    public Task UpdateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Receptionists.Update((Receptionist)entity), cancellationToken);
    }
}
