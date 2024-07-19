namespace Clinic.API.Models.Account;

public class AccountResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public bool IsEmailVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? PhotoPath { get; set; }

    public AccountResponse(Domain.Entities.Account account)
    {
        Id = account.Id;
        Email = account.Email;
        PhoneNumber = account.PhoneNumber;
        IsEmailVerified = account.IsEmailVerified;
        CreatedAt = account.CreatedAt;
        PhotoPath = account.Photo?.Path;
    }
}
