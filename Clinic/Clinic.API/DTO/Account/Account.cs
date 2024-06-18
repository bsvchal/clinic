namespace Clinic.API.DTO.Account;

public class Account
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsEmailVerified { get; set; }
    public DateTime CreatedAt { get; set; }
}
