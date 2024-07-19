using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Entities;

public class Photo : BaseEntity
{
    [MaxLength(100)]
    public string Path { get; set; }
    public Guid AccountId { get; set; }
}
