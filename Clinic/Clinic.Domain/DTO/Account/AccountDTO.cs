namespace Clinic.Domain.DTO.Account;

public class AccountDTO
{
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsEmailVerified { get; set; }
    public DateTime CreatedAt { get; set; }
}
