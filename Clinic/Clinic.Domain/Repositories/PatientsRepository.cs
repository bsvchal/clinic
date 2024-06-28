using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class PatientsRepository : BaseRepository<Patient>, IPatientsRepository
{
    private readonly AppDbContext _appDbContext;

    public PatientsRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<Patient>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Patients
            .Where(p => !p.IsDeleted)
            .Include(p => p.Account)
            .Include(p => p.Appointments)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Patient?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Patients
            .Where(p => !p.IsDeleted)
            .Where(p => p.Id == id)
            .Include(p => p.Account)
            .Include(p => p.Appointments)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
