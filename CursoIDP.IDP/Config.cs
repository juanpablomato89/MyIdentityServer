// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace CursoIDP.IDP
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
            { };

        public static IEnumerable<Client> Clients =>
            new Client[] 
            {
                new Client
                {
                    ClientName = "UserApiClient",
                    ClientId ="userapiclient",
                    AllowedGrantTypes= GrantTypes.Code,
                    RedirectUris = new List<string>{ "https://localhost:5010/singnin-oidc"},
                    AllowedScopes= 
                    { 
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    
                    },
                    ClientSecrets = { new Secret("UserClientSecret".Sha512())},
                    RequirePkce=false,
                    RequireConsent=true
                },
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                
            };

    }
}