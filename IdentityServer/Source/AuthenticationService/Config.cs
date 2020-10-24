using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

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
            // Client Credential
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

            // User Password based
            yield return new Client
            {
                ClientId = "ResourceOwnerClient",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret("qwerty_zxc".Sha256()),
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

        internal static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser { SubjectId = "1", Username = "Test", Password = "test123!" },
                new TestUser { SubjectId = "2", Username = "Test1", Password = "test123!" },
            };
        }
    }
}