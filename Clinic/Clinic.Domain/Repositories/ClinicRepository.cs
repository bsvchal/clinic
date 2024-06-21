using Clinic.Domain.Entities;
using Clinic.Domain.Interfaces;
using System.Linq.Expressions;

namespace Clinic.Domain.Repositories;

public class ClinicRepository : IClinicRepository
{
    private readonly AppDbContext _appDbContext;

    public ClinicRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Guid?> CreateAppointmentAsync(
        Appointment appointment, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry =
            await _appDbContext.Appointments.AddAsync(appointment, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public async Task<Guid?> CreateOfficeAsync(
        Office office, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry =
            await _appDbContext.Offices.AddAsync(office, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public Task DeleteAppointmentAsync(
        Appointment appointment, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Appointments.Remove(appointment), cancellationToken);
    }

    public Task DeleteOfficeAsync(
        Office office, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Offices.Remove(office), cancellationToken);
    }

    public IQueryable<Appointment> GetAppointments(
        Expression<Func<Appointment, bool>>? predicate)
    {
        return predicate is null ?
            _appDbContext.Appointments : _appDbContext.Appointments.Where(predicate);
    }

    public IQueryable<Office> GetOffices(
        Expression<Func<Office, bool>>? predicate)
    {
        return predicate is null ?
            _appDbContext.Offices : _appDbContext.Offices.Where(predicate);
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public Task UpdateAppointmentAsync(
        Appointment appointment, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Appointments.Update(appointment), cancellationToken);
    }

    public Task UpdateOfficeAsync(
        Office office, CancellationToken cancellationToken = default)
    {
        return Task.Run(
            () => _appDbContext.Offices.Update(office), cancellationToken);
    }
}
