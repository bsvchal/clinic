namespace Clinic.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<Guid?> CreateAsync(T entity, CancellationToken cancellationToken = default);
    void Delete(T entity);
    Task<List<T>> GetAsync(bool includeDeleted = false, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Update(T entity);
}
