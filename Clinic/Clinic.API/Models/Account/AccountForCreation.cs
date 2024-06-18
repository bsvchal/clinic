namespace Clinic.API.Models.Account;

public class AccountForCreation
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string? PathToPhoto { get; set; }
}
