using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class OfficesRepository : BaseRepository<Office>, IOfficesRepository
{
    private readonly AppDbContext _appDbContext;

    public OfficesRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<Office>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Offices
            .Where(o => !o.IsDeleted)
            .Include(o => o.Doctors)
            .Include(o => o.Receptionists)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Office?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Offices
            .Where(o => !o.IsDeleted)
            .Where(o => o.Id == id)
            .Include(o => o.Doctors)
            .Include(o => o.Receptionists)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
