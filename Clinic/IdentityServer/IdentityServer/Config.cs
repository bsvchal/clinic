using Duende.IdentityServer.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ("read"),
                new ("write")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
                new ()
                {
                    Name = "api",
                    Scopes = { "read", "write" },
                    ApiSecrets = { new Secret("resource".Sha256()) },
                    UserClaims = ["role"]
                }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new ()
                {
                    ClientId = "m2m",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("m2m".Sha256()) },
                    AllowedScopes = { "read", "write" }
                },
                new ()
                {
                    ClientId = "int",
                    RequireClientSecret = false,
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "http://localhost:4200" },
                    FrontChannelLogoutUri = "http://localhost:4200",
                    PostLogoutRedirectUris = { "http://localhost:4200" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "read", "openid", "profile" },
                    AllowedCorsOrigins = { "http://localhost:4200" },
                    AllowAccessTokensViaBrowser = true,
                }
            };
    }
}