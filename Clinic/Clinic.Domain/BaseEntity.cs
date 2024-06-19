using System.ComponentModel.DataAnnotations;

namespace Clinic.Domain;

public abstract class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}
