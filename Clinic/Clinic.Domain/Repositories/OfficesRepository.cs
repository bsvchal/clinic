using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class OfficesRepository : BaseRepository<Office>, IOfficesRepository
{
    private readonly ClinicDbContext _clinicDbContext;

    public OfficesRepository(ClinicDbContext clinicDbContext)
        : base(clinicDbContext)
    {
        _clinicDbContext = clinicDbContext;
    }

    public override async Task<List<Office>> GetAsync(
        bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return includeDeleted ?
            await _clinicDbContext.Offices
                .Include(o => o.Doctors)
                .Include(o => o.Receptionists)
                .ToListAsync(cancellationToken) :
            await _clinicDbContext.Offices
                .Where(o => !o.IsDeleted)
                .Include(o => o.Doctors)
                .Include(o => o.Receptionists)
                .ToListAsync(cancellationToken);
    }

    public override async Task<Office?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _clinicDbContext.Offices
            .Where(o => !o.IsDeleted && o.Id == id)
            .Include(o => o.Doctors)
            .Include(o => o.Receptionists)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
