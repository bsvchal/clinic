using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Domain.Entities;

public class Account : BaseEntity
{
    [MaxLength(30)]
    public string Email { get; set; }
    [MaxLength(30)]
    public string Password { get; set; }
    [MaxLength(15)]
    public string PhoneNumber { get; set; } 
    public bool IsEmailVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    [ForeignKey("Photo")]
    public Guid? PhotoId { get; set; }
    public Photo? Photo { get; set; }
}
