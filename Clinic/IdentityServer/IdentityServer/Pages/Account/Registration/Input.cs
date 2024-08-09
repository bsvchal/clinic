namespace IdentityServer.Pages.Account.Registration;

public class Input
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string? LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public string? ReturnUrl { get; set; }
}
