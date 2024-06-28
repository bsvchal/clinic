using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class DoctorsRepository : BaseRepository<Doctor>, IDoctorsRepository
{
    private readonly AppDbContext _appDbContext;

    public DoctorsRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public override async Task<List<Doctor>> GetAsync(
        CancellationToken cancellationToken = default)
    {
        return await _appDbContext.Doctors
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
            .Where(d => !d.IsDeleted)
            .Where(d => d.Id == id)
            .Include(d => d.Account)
            .Include(d => d.Office)
            .Include(d => d.Appointments)
            .FirstOrDefaultAsync(cancellationToken);

    }
}
