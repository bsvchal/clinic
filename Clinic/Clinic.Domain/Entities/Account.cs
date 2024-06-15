namespace Clinic.Domain.Entities;

public class Account
{
    public Guid Id { get; set; }
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public bool IsEmailVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? PhotoId { get; set; }
    public Photo? Photo { get; set; }
}
