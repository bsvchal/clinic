using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;

namespace Clinic.Domain.Repositories;

public class PhotosRepository : BaseRepository<Photo>, IPhotosRepository
{
    public PhotosRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
    }
}
