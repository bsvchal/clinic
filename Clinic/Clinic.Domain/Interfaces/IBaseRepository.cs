namespace Clinic.Domain.Interfaces;

public interface IBaseRepository
{
    Task<Guid?> CreateAsync(BaseEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(BaseEntity entity, CancellationToken cancellationToken = default);
    IQueryable<BaseEntity> Get();
    Task UpdateAsync(BaseEntity entity, CancellationToken cancellationToken = default);
}
