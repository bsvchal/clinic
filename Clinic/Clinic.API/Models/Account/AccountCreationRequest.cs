namespace Clinic.API.Models.Account;

public class AccountCreationRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string? PathToPhoto { get; set; }
}
