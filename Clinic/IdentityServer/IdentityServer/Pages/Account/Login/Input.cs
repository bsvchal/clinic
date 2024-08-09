using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Pages.Account.Login;

public class Input
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Password { get; set; }
    public string? ReturnUrl { get; set; }
}
