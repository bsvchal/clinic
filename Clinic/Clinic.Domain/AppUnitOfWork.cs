using Clinic.Domain.Interfaces;
using Clinic.Domain.Repositories;

namespace Clinic.Domain;

public class AppUnitOfWork : IBaseUnitOfWork
{
    private readonly AppDbContext _appDbContext;

    private readonly Lazy<AppointmentsRepository> _appointmentsRepository;
    private readonly Lazy<DoctorsRepository> _doctorsRepository;
    private readonly Lazy<OfficesRepository> _officesRepository;
    private readonly Lazy<PatientsRepository> _patientsRepository;
    private readonly Lazy<PhotosRepository> _photosRepository;
    private readonly Lazy<ReceptionistsRepository> _receptionistsRepository;

    public AppUnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;

        _appointmentsRepository = new(() => new(_appDbContext));
        _doctorsRepository = new(() => new(_appDbContext));
        _officesRepository = new(() => new(_appDbContext));
        _patientsRepository = new(() => new(_appDbContext));
        _photosRepository = new(() => new(_appDbContext));
        _receptionistsRepository = new(() => new(_appDbContext));
    }

    public AppointmentsRepository AppointmentsRepository => _appointmentsRepository.Value;
    public DoctorsRepository DoctorsRepository => _doctorsRepository.Value;
    public OfficesRepository OfficesRepository => _officesRepository.Value;
    public PatientsRepository PatientsRepository => _patientsRepository.Value;
    public PhotosRepository PhotosRepository => _photosRepository.Value;
    public ReceptionistsRepository ReceptionistsRepository => _receptionistsRepository.Value;

    public async Task<int> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}
