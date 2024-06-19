﻿using Clinic.Domain.Entities;
using System.Linq.Expressions;

namespace Clinic.Domain.Interfaces;

public interface IAccountsRepository
{
    IQueryable<Patient> GetPatients(
        Expression<Predicate<Patient>>? predicate
    );

    IQueryable<Doctor> GetDoctors(
        Expression<Predicate<Doctor>>? predicate
    );

    IQueryable<Receptionist> GetReceptionists(
        Expression<Predicate<Receptionist>>? predicate
    );

    Task<Guid?> CreatePatientAsync(
        Patient patient,
        CancellationToken cancellationToken = default
    );

    Task<Guid?> CreateDoctorAsync(
        Doctor doctor,
        CancellationToken cancellationToken = default
    );

    Task<Guid?> CreateReceptionistAsync(
        Receptionist receptionist,
        CancellationToken cancellationToken = default
    );

    Task UpdatePatientAsync(
        Patient patient,
        CancellationToken cancellationToken = default
    );

    Task UpdateDoctorAsync(
        Doctor doctor,
        CancellationToken cancellationToken = default
    );

    Task UpdateReceptionistAsync(
        Receptionist receptionist,
        CancellationToken cancellationToken = default
    );

    Task DeletePatientAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task DeleteDoctorAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task DeleteReceptionistAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}