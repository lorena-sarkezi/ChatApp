
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.IdentityServer
{
    public class Config
    {
        //public IConfiguration Configuration { get; }

        //public Config(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api", "SPA Api for ChatApp")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client
                {
                    ClientId = "client",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = GetApis().Select(x => x.Name).ToList()
                },
                new Client
                {
                    ClientId = "spa",
                    ClientName = "Single Page Javascript App",
                    AllowedGrantTypes = GrantTypes.Code,
                    // Specifies whether this client can request refresh tokens
                    AllowOfflineAccess = true,
                    RequireClientSecret = false,
                    
                    // no consent page
                    RequireConsent = false,

                    // where to redirect to after login
                    //RedirectUris = { "http://localhost:8080/callback.html" },

                    // where to redirect to after logout
                    //PostLogoutRedirectUris = { "http://localhost:8080/index.html" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api"
                    }
                }
            };
        }
    }
}
