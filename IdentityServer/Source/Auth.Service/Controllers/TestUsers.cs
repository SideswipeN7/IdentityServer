// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer4.Quickstart.UI
{
    public static class TestUsers
    {
        public static List<TestUser> Users = new()
        {
            new()
            {
                SubjectId = "818727",
                Username = "alice",
                Password = "alice",
                Claims =
                {
                    new (JwtClaimTypes.Name, "Alice Smith"),
                    new (JwtClaimTypes.GivenName, "Alice"),
                    new (JwtClaimTypes.FamilyName, "Smith"),
                    new (JwtClaimTypes.Email, "AliceSmith@email.com"),
                    new (JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new (JwtClaimTypes.WebSite, "http://alice.com"),
                    new (JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                }
            },
            new()
            {
                SubjectId = "88421113",
                Username = "bob",
                Password = "bob",
                Claims =
                {
                    new (JwtClaimTypes.Name, "Bob Smith"),
                    new (JwtClaimTypes.GivenName, "Bob"),
                    new (JwtClaimTypes.FamilyName, "Smith"),
                    new (JwtClaimTypes.Email, "BobSmith@email.com"),
                    new (JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                    new (JwtClaimTypes.WebSite, "http://bob.com"),
                    new (JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                    new ("location", "somewhere")
                }
            }
        };
    }
}