using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;

namespace Clinic.Domain.Repositories;

public class PhotosRepository : BaseRepository<Photo>, IPhotosRepository
{
    public PhotosRepository(ClinicDbContext appDbContext)
        : base(appDbContext)
    {
    }
}
