using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Marvin.IDP;

public static class Config
{
  private static readonly string ImageGalleryApi = nameof(ImageGalleryApi).ToLower();

  public static IEnumerable<IdentityResource> IdentityResources =>
    new[]
    {
      new IdentityResources.OpenId(),
      new IdentityResources.Profile(),
      new IdentityResource("roles", "Your role(s)", new []{"role"}),
      new IdentityResource("country", "Country you are living in", new List<string>(){"country"})
    };

  public static IEnumerable<ApiResource> ApiResources =>
    new ApiResource[]
    {
      new(ImageGalleryApi, "Image Gallery API", new []{"role", "country"})
      {
        Scopes =
        {
          $"{ImageGalleryApi}.fullaccess",
          $"{ImageGalleryApi}.read",
          $"{ImageGalleryApi}.write"
        },
        ApiSecrets = { new Secret("apisecret".Sha256()) }
      }
    };

  public static IEnumerable<ApiScope> ApiScopes =>
    new ApiScope[]
    {
      new ($"{ImageGalleryApi}.fullaccess"),
      new ($"{ImageGalleryApi}.read"),
      new ($"{ImageGalleryApi}.write"),
    };

  public static IEnumerable<Client> Clients =>
    new[]
    {
      new Client
      {
        ClientName = "Image Gallery",
        ClientId = "imagegalleryclient",
        AllowedGrantTypes = GrantTypes.Code,
        AccessTokenType = AccessTokenType.Reference,
        AllowOfflineAccess = true,
        UpdateAccessTokenClaimsOnRefresh = true,
        AccessTokenLifetime = 30,
        //AuthorizationCodeLifetime = ...,
        //IdentityTokenLifetime = ...,
        RedirectUris =
        {
          "https://localhost:7184/signin-oidc"
        },
        PostLogoutRedirectUris =
        {
          "https://localhost:7184/signout-callback-oidc"
        },
        AllowedScopes =
        {
          IdentityServerConstants.StandardScopes.OpenId,
          IdentityServerConstants.StandardScopes.Profile,
          "roles",
          $"{ImageGalleryApi}.read",
          $"{ImageGalleryApi}.write",
          "country",
        },
        ClientSecrets =
        {
          new Secret("secret".Sha256())
        },
        //RequireConsent = true
      }
    };
}