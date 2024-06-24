using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class PatientsRepository : IBaseRepository
{
    private readonly AppDbContext _appDbContext;

    public PatientsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Guid?> CreateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = await _appDbContext.Patients
            .AddAsync((Patient)entity, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public Task DeleteAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Patients.Remove((Patient)entity), cancellationToken);
    }

    public IQueryable<BaseEntity> Get()
    {
        return _appDbContext.Patients
            .Include(p => p.Account)
            .Include(p => p.Appointments);
    }

    public Task UpdateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Patients.Update((Patient)entity), cancellationToken);
    }
}
