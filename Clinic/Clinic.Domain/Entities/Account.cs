namespace Clinic.Domain.Entities;

public class Account : BaseEntity
{
    public string Email { get; set; } 
    public string Password { get; set; } 
    public string PhoneNumber { get; set; } 
    public bool IsEmailVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? PhotoId { get; set; }
    public Photo? Photo { get; set; }
}
