using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace IdentityServer.Services;

public class ProfileService : IProfileService
{
    private readonly UserManager<IdentityUser> _userManager;

    public ProfileService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var user = await _userManager.GetUserAsync(context.Subject);
        var roles = await _userManager.GetRolesAsync(user!);

        context.IssuedClaims.AddRange(
            [new(JwtClaimTypes.Role, roles.First())]
        );
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var user = await _userManager.GetUserAsync(context.Subject);
        context.IsActive = user != null;
    }
}
