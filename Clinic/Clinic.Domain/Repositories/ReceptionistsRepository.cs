using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class ReceptionistsRepository : BaseRepository<Receptionist>, IReceptionistsRepository
{
    private readonly ClinicDbContext _appDbContext;

    public ReceptionistsRepository(ClinicDbContext appDbContext)
        : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<Receptionist>> GetAsync(
        bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return includeDeleted ?
            await _appDbContext.Receptionists
                .Include(r => r.Account)
                .Include(r => r.Office)
                .ToListAsync(cancellationToken) :
            await _appDbContext.Receptionists
                .Where(r => !r.IsDeleted)
                .Include(r => r.Account)
                .Include(r => r.Office)
                .ToListAsync(cancellationToken);
    }

    public override async Task<Receptionist?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Receptionists
            .Where(r => !r.IsDeleted && r.Id == id)
            .Include(r => r.Account)
            .Include(r => r.Office)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
