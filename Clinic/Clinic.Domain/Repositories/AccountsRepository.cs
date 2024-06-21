using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace Clinic.Domain.Repositories;

public class AccountsRepository : IAccountsRepository
{
    private readonly AppDbContext _appDbContext;

    public AccountsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Guid?> CreateDoctorAsync(
        Doctor doctor, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = 
            await _appDbContext.Doctors.AddAsync(doctor, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public async Task<Guid?> CreatePatientAsync(
        Patient patient, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = 
            await _appDbContext.Patients.AddAsync(patient, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public async Task<Guid?> CreateReceptionistAsync(
        Receptionist receptionist, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = 
            await _appDbContext.Receptionists.AddAsync(receptionist, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public Task DeleteDoctorAsync(
        Doctor doctor, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Doctors.Remove(doctor), cancellationToken);
    }

    public Task DeletePatientAsync(
        Patient patient, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Patients.Remove(patient), cancellationToken);
    }

    public Task DeleteReceptionistAsync(
        Receptionist receptionist, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Receptionists.Remove(receptionist), cancellationToken);
    }

    public IQueryable<Doctor> GetDoctors(Expression<Func<Doctor, bool>>? predicate)
    {
        return predicate is null ?
            _appDbContext.Doctors : _appDbContext.Doctors.Where(predicate);
    }

    public IQueryable<Patient> GetPatients(Expression<Func<Patient, bool>>? predicate)
    {
        return predicate is null ?
            _appDbContext.Patients : _appDbContext.Patients.Where(predicate);
    }

    public IQueryable<Receptionist> GetReceptionists(Expression<Func<Receptionist, bool>>? predicate)
    {
        return predicate is null ?
            _appDbContext.Receptionists : _appDbContext.Receptionists.Where(predicate);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateDoctorAsync(
        Doctor doctor, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Doctors.Update(doctor), cancellationToken);
    }

    public Task UpdatePatientAsync(
        Patient patient, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Patients.Update(patient), cancellationToken);
    }

    public Task UpdateReceptionistAsync(
        Receptionist receptionist, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Receptionists.Update(receptionist), cancellationToken);
    }
}
