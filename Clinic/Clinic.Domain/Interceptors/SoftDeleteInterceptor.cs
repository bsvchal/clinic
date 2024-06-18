using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Clinic.Domain.Interceptors;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result
    )
    {
        if (eventData.Context is null)
            return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.State is not EntityState.Deleted ||
                entry.Entity is not BaseEntity)
                continue;

            entry.State = EntityState.Modified;
            (entry.Entity as BaseEntity)!.IsDeleted = true;
        }

        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        if (eventData.Context is null)
            return ValueTask.FromResult(result);

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry.State is not EntityState.Deleted ||
                entry.Entity is not BaseEntity)
                continue;

            entry.State = EntityState.Modified;
            (entry.Entity as BaseEntity)!.IsDeleted = true;
        }

        return ValueTask.FromResult(result);
    }
}
