using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace ImageGallery.Client.Controllers;

public class AuthenticationController : Controller
{
  private readonly IHttpClientFactory _httpClientFactory;
  private readonly HttpClient _httpClient;

  public AuthenticationController(IHttpClientFactory httpClientFactory)
  {
    _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    _httpClient = _httpClientFactory.CreateClient("IDPClient");
  }

  [Authorize]
  public async Task Logout()
  {
    var discoveryDocResponse = await _httpClient.GetDiscoveryDocumentAsync();
    if (discoveryDocResponse.IsError)
    {
      throw new Exception(discoveryDocResponse.Error);
    }

    var revocationEndPoint = discoveryDocResponse.RevocationEndpoint;
    await RevokeToken(revocationEndPoint, OpenIdConnectParameterNames.AccessToken);
    await RevokeToken(revocationEndPoint, OpenIdConnectParameterNames.RefreshToken);

    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
  }

  private async Task RevokeToken(string endPoint, string token)
  {
    var tokenRevocationResponse = await _httpClient.RevokeTokenAsync(new()
    {
      Address = endPoint,
      ClientId = "imagegalleryclient",
      ClientSecret = "secret",
      Token = await HttpContext.GetTokenAsync(token)
    });

    if (tokenRevocationResponse.IsError)
    {
      throw new Exception(tokenRevocationResponse.Error);
    }
  }

  public IActionResult AccessDenied()
  {
    return View();
  }
}