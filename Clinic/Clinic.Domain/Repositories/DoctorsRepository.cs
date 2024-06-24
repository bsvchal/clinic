using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class DoctorsRepository : IBaseRepository
{
    private readonly AppDbContext _appDbContext;

    public DoctorsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Guid?> CreateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = await _appDbContext.Doctors
            .AddAsync((Doctor)entity, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public Task DeleteAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Doctors.Remove((Doctor)entity), cancellationToken);
    }

    public IQueryable<BaseEntity> Get()
    {
        return _appDbContext.Doctors
            .Include(d => d.Office)
            .Include(d => d.Account)
            .Include(d => d.Appointments);
    }

    public Task UpdateAsync(BaseEntity entity, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Doctors.Update((Doctor)entity), cancellationToken);
    }
}
