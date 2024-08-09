using IdentityServer.Entities;
using IdentityServer.Infrastructure;
using IdentityServer.Infrastructure.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityServer.Pages.Account.Registration;

[IgnoreAntiforgeryToken]
[AllowAnonymous]
public class IndexModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    [BindProperty]
    public Input Input { get; set; } = default!;

    public IndexModel(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager,
        SignInManager<IdentityUser> signInManager
    )
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public IActionResult OnGet(string? ReturnUrl)
    {
        Input = new()
        {
            ReturnUrl = ReturnUrl
        };
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(
        string? Email,
        string? Password,
        string? FirstName,
        string? MiddleName,
        string? LastName,
        DateOnly? DateOfBirth
    )
    {
        using var sender = new RabbitMQMessageSender();

        if ((await _userManager.FindByNameAsync(Email!)) is not null)
        {
            return Page();
        }

        await _userManager.CreateAsync(
            new()
            {
                Email = Email,
                NormalizedEmail = Email,
                UserName = Email,
            },
            Password!
        );
       
        // assign to role
        var user = await _userManager.FindByNameAsync(Email!);
        await _userManager.AddToRoleAsync(user!, AccountRoles.Patient);

        sender.Send(new PatientCreationModel(
            user!.Id,
            FirstName!,
            MiddleName!,
            LastName!,
            DateOfBirth!.Value
        ));
        return Redirect(Input.ReturnUrl ?? "~/");
    }
}
    