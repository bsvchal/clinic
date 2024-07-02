using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class PatientsRepository : BaseRepository<Patient>, IPatientsRepository
{
    private readonly ClinicDbContext _clinicDbContext;

    public PatientsRepository(ClinicDbContext clinicDbContext)
        : base(clinicDbContext)
    {
        _clinicDbContext = clinicDbContext;
    }

    public override async Task<List<Patient>> GetAsync(
        bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return includeDeleted ?
            await _clinicDbContext.Patients
                .Include(p => p.Account)
                .Include(p => p.Appointments)
                .ToListAsync(cancellationToken) :
            await _clinicDbContext.Patients
                .Where(p => !p.IsDeleted)
                .Include(p => p.Account)
                .Include(p => p.Appointments)
                .ToListAsync(cancellationToken);
    }

    public override async Task<Patient?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _clinicDbContext.Patients
            .Where(p => !p.IsDeleted && p.Id == id)
            .Include(p => p.Account)
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
