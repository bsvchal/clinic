﻿using Clinic.Domain.Entities;
using System.Linq.Expressions;

namespace Clinic.Domain.Interfaces;

public interface IClinicRepository
{
    IQueryable<Appointment> GetAppointments(
        Expression<Predicate<Appointment>>? predicate);

    IQueryable<Office> GetOffices(
        Expression<Predicate<Office>>? predicate);

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
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task DeleteOfficeAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}