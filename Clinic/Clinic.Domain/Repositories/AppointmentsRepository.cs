using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class AppointmentsRepository : IBaseRepository
{
    private readonly AppDbContext _appDbContext;

    public AppointmentsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Guid?> CreateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = await _appDbContext.Appointments
            .AddAsync((Appointment)entity, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public Task DeleteAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Appointments.Remove((Appointment)entity), cancellationToken);
    }

    public IQueryable<BaseEntity> Get()
    {
        return _appDbContext.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient);
    }

    public Task UpdateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Appointments.Update((Appointment)entity), cancellationToken);
    }
}
