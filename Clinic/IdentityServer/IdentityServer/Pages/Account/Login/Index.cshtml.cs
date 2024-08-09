using Duende.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace IdentityServer.Pages.Account.Login
{
    [IgnoreAntiforgeryToken]
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        [BindProperty]
        public Input Input { get; set; } = default!;

        public IndexModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult OnGet(string? ReturnUrl)
        {
            Input = new Input()
            {
                ReturnUrl = ReturnUrl
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? Email, string? Password)
        {
            var user = await _signInManager.UserManager.FindByNameAsync(Email!);

            if (user is null || (await _signInManager.CheckPasswordSignInAsync(user, Password!, false)) != SignInResult.Success)
                return Page();

            var issuer = new IdentityServerUser(user.Id);
            var properties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            await HttpContext.SignInAsync(issuer, properties);
            return Redirect(Input.ReturnUrl ?? "~/");
        }
    }
}
