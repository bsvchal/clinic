using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class AppointmentsRepository : BaseRepository<Appointment>, IAppointmentsRepository
{
    private readonly AppDbContext _appDbContext;

    public AppointmentsRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<Appointment>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Appointments
            .Where(a => !a.IsDeleted)
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Appointment?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Appointments
            .Where(a => !a.IsDeleted)
            .Where(a => a.Id == id)
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
