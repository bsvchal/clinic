namespace Clinic.Domain.Interfaces;

public interface IUnitOfWork
{
    IAppointmentsRepository AppointmentsRepository { get; }
    IDoctorsRepository DoctorsRepository { get; }
    IOfficesRepository OfficesRepository { get; }
    IPatientsRepository PatientsRepository { get; }
    IPhotosRepository PhotosRepository { get; }
    IReceptionistsRepository ReceptionistsRepository { get; }

    Task<int> CommitAsync(CancellationToken cancellationToken = default);
    void Rollback();
}