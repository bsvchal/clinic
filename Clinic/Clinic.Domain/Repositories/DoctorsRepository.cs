using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class DoctorsRepository : BaseRepository<Doctor>, IDoctorsRepository
{
    private readonly ClinicDbContext _appDbContext;

    public DoctorsRepository(ClinicDbContext appDbContext)
        : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<Doctor>> GetAsync(
        bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return includeDeleted ?
            await _appDbContext.Doctors
                .Include(d => d.Account)
                .Include(d => d.Office)
                .Include(d => d.Appointments)
                .ToListAsync(cancellationToken) :
            await _appDbContext.Doctors
                .Where(d => !d.IsDeleted)
                .Include(d => d.Account)
                .Include(d => d.Office)
                .Include(d => d.Appointments)
                .ToListAsync(cancellationToken);
    }

    public override async Task<Doctor?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Doctors
            .Where(d => !d.IsDeleted && d.Id == id)
            .Include(d => d.Account)
            .Include(d => d.Office)
            .Include(d => d.Appointments)
            .FirstOrDefaultAsync(cancellationToken);

    }
}
