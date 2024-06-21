using Clinic.Domain.Entities;
using System.Linq.Expressions;

namespace Clinic.Domain.Interfaces;

public interface IClinicRepository
{
    IQueryable<Appointment> GetAppointments(
        Expression<Func<Appointment, bool>>? predicate);

    IQueryable<Office> GetOffices(
        Expression<Func<Office, bool>>? predicate);

    Task<Guid?> CreateAppointmentAsync(
        Appointment appointment,
        CancellationToken cancellationToken = default
    );

    Task<Guid?> CreateOfficeAsync(
        Office office,
        CancellationToken cancellationToken = default
    );

    Task UpdateAppointmentAsync(
        Appointment appointment,
        CancellationToken cancellationToken = default
    );

    Task UpdateOfficeAsync(
        Office office,
        CancellationToken cancellationToken = default
    );

    Task DeleteAppointmentAsync(
        Appointment appointment,
        CancellationToken cancellationToken = default
    );

    Task DeleteOfficeAsync(
        Office office,
        CancellationToken cancellationToken = default
    );

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}