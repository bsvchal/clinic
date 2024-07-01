using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class PatientsRepository : BaseRepository<Patient>, IPatientsRepository
{
    private readonly ClinicDbContext _appDbContext;

    public PatientsRepository(ClinicDbContext appDbContext)
        : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<Patient>> GetAsync(
        bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return includeDeleted ?
            await _appDbContext.Patients
                .Include(p => p.Account)
                .Include(p => p.Appointments)
                .ToListAsync(cancellationToken) :
            await _appDbContext.Patients
                .Where(p => !p.IsDeleted)
                .Include(p => p.Account)
                .Include(p => p.Appointments)
                .ToListAsync(cancellationToken);
    }

    public override async Task<Patient?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Patients
            .Where(p => !p.IsDeleted && p.Id == id)
            .Include(p => p.Account)
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
