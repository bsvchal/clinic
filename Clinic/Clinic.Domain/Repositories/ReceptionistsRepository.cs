using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class ReceptionistsRepository : BaseRepository<Receptionist>, IReceptionistsRepository
{
    private readonly AppDbContext _appDbContext;

    public ReceptionistsRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<Receptionist>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Receptionists
            .Where(r => !r.IsDeleted)
            .Include(r => r.Account)
            .Include(r => r.Office)
            .ToListAsync(cancellationToken);
    }

    public override async Task<Receptionist?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Receptionists
            .Where(r => !r.IsDeleted)
            .Where(r => r.Id == id)
            .Include(r => r.Account)
            .Include(r => r.Office)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
