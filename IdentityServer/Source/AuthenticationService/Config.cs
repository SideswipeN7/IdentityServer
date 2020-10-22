using System.Collections.Generic;
using IdentityServer4.Models;

namespace AuthenticationService
{
    internal static class Config
    {
        internal static IEnumerable<ApiResource> GetAllApiResources()
        {
            yield return new ApiResource("UserAPI", "Test user API")
            {
                Scopes = { "UserAPI_SCOPE" }
            };
        }

        internal static IEnumerable<Client> GetClients()
        {
            yield return new Client
            {
                ClientId = "TestClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("qwerty".Sha256()),
                },
                AllowedScopes = { "UserAPI_SCOPE" },
            };
        }

        internal static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }

        internal static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("UserAPI_SCOPE", "User API scope");
        }
    }
}