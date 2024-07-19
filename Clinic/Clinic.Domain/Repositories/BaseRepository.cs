﻿using Clinic.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Domain.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly ClinicDbContext _clinicDbContext;

    public BaseRepository(ClinicDbContext clinicDbContext)
    {
        _clinicDbContext = clinicDbContext;
    }

    public virtual async Task<Guid?> CreateAsync(
        T entity, CancellationToken cancellationToken = default)
    {
        var addedEntityEntry = 
            await _clinicDbContext.Set<T>().AddAsync(entity, cancellationToken);
        return addedEntityEntry?.Entity.Id;
    }

    public virtual void Delete(T entity)
    {
        _clinicDbContext.Set<T>().Remove(entity);
    }

    public virtual async Task<List<T>> GetAsync(
        bool includeDeleted = false, CancellationToken cancellationToken = default)
    {
        return includeDeleted ? 
            await _clinicDbContext.Set<T>()
                .ToListAsync(cancellationToken) : 
            await _clinicDbContext.Set<T>()
                .Where(e => !e.IsDeleted)
                .ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(
        Guid id, CancellationToken cancellationToken = default)
    {
        return await _clinicDbContext.Set<T>()
            .Where(e => !e.IsDeleted)
            .Where(e => e.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public virtual void Update(T entity)
    {
        _clinicDbContext.Set<T>().Update(entity);
    }
}
