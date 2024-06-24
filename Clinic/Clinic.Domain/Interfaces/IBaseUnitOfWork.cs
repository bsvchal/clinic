using Clinic.Domain.Repositories;

namespace Clinic.Domain.Interfaces;

public interface IBaseUnitOfWork
{
    AppointmentsRepository AppointmentsRepository { get; }
    DoctorsRepository DoctorsRepository { get; }
    OfficesRepository OfficesRepository { get; }
    PatientsRepository PatientsRepository { get; }
    PhotosRepository PhotosRepository { get; }
    ReceptionistsRepository ReceptionistsRepository { get; }

    Task<int> SaveChangesAsync();
}