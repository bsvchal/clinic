using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class AppointmentsRepository : BaseRepository<Appointment>, IAppointmentsRepository
{
    private readonly ClinicDbContext _clinicDbContext;

    public AppointmentsRepository(ClinicDbContext clinicDbContext)
        : base(clinicDbContext)
    {
        _clinicDbContext = clinicDbContext;
    }

    public override async Task<List<Appointment>> GetAsync(
        bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return includeDeleted ?
            await _clinicDbContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync(cancellationToken) :
            await _clinicDbContext.Appointments
                .Where(a => !a.IsDeleted)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync(cancellationToken);
    }

    public override async Task<Appointment?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _clinicDbContext.Appointments
            .Where(a => !a.IsDeleted && a.Id == id)
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
