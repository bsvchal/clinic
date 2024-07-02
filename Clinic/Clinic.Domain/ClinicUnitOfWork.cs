using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Domain;

public class ClinicUnitOfWork : IUnitOfWork
{
    private readonly ClinicDbContext _appDbContext;
    private readonly IServiceProvider _serviceProvider;

    private IAccountsRepository? _accountsRepository;
    private IAppointmentsRepository? _appointmentsRepository;
    private IDoctorsRepository? _doctorsRepository;
    private IOfficesRepository? _officesRepository;
    private IPatientsRepository? _patientsRepository;
    private IPhotosRepository? _photosRepository;
    private IReceptionistsRepository? _receptionistsRepository;

    public ClinicUnitOfWork(ClinicDbContext appDbContext, IServiceProvider serviceProvider)
    {
        _appDbContext = appDbContext;
        _serviceProvider = serviceProvider;
    }

    public IAccountsRepository AccountsRepository
    {
        get
        {
            if (_accountsRepository is null)
                _accountsRepository = _serviceProvider.GetRequiredService<IAccountsRepository>();
            return _accountsRepository;
        }
    }

    public IAppointmentsRepository AppointmentsRepository 
    {
        get
        {
            if (_appointmentsRepository is null)
                _appointmentsRepository = _serviceProvider.GetRequiredService<IAppointmentsRepository>();
            return _appointmentsRepository;
        }
    }

    public IDoctorsRepository DoctorsRepository
    {
        get
        {
            if (_doctorsRepository is null)
                _doctorsRepository = _serviceProvider.GetRequiredService<IDoctorsRepository>();
            return _doctorsRepository;
        }
    }

    public IOfficesRepository OfficesRepository
    {
        get
        {
            if (_officesRepository is null)
                _officesRepository = _serviceProvider.GetRequiredService<IOfficesRepository>();
            return _officesRepository;
        }
    }

    public IPatientsRepository PatientsRepository
    {
        get
        {
            if (_patientsRepository is null)
                _patientsRepository = _serviceProvider.GetRequiredService<IPatientsRepository>();
            return _patientsRepository;
        }
    }

    public IPhotosRepository PhotosRepository
    {
        get
        {
            if (_photosRepository is null)
                _photosRepository = _serviceProvider.GetRequiredService<IPhotosRepository>();
            return _photosRepository;
        }
    }

    public IReceptionistsRepository ReceptionistsRepository
    {
        get
        {
            if (_receptionistsRepository is null)
                _receptionistsRepository = _serviceProvider.GetRequiredService<IReceptionistsRepository>();
            return _receptionistsRepository;
        }
    }

    public async Task<int> CommitAsync(CancellationToken cancellationToken = default) 
        => await _appDbContext.SaveChangesAsync(cancellationToken);

    public void Rollback()
    {
        var entries = _appDbContext.ChangeTracker.Entries().ToList();
        foreach (var entry in entries) 
        {
            switch (entry.State) 
            {
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Modified;
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Modified:
                    entry.State = EntityState.Unchanged;
                    break;
                default:
                    break;
            }
        }
    }
}
