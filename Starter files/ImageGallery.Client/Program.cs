using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using ImageGallery.Authorization;
using Microsoft.AspNetCore.Authentication;


string ImageGalleryApi = nameof(ImageGalleryApi).ToLower();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(configure => configure.JsonSerializerOptions.PropertyNamingPolicy = null);

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAccessTokenManagement();

// create an HttpClient used for accessing the API
builder.Services.AddHttpClient("APIClient", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ImageGalleryAPIRoot"]);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
}).AddUserAccessTokenHandler();

builder.Services
    .AddAuthentication(o =>
    {
        o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
    })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
      o.AccessDeniedPath = "/Authentication/AccessDenied";
    })
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, o =>
    {
        o.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        o.Authority = "https://localhost:5001/";
        o.ClientId = "imagegalleryclient";
        o.ClientSecret = "secret";
        o.ResponseType = "code";
        o.SaveTokens = true;
        o.GetClaimsFromUserInfoEndpoint = true;
        o.ClaimActions.Remove("aud");
        o.ClaimActions.DeleteClaim("sid");
        o.ClaimActions.DeleteClaim("idp");
        o.Scope.Add("roles");
        o.Scope.Add($"{ImageGalleryApi}.read");
        o.Scope.Add($"{ImageGalleryApi}.write");
        o.Scope.Add("country");
        o.Scope.Add("offline_access");
        o.ClaimActions.MapJsonKey("role", "role");
        o.ClaimActions.MapUniqueJsonKey("country", "country");
        o.TokenValidationParameters = new()
        {
          NameClaimType = "given_name",
          RoleClaimType = "role",
        };
    });

builder.Services.AddAuthorization(o =>
  {
    o.AddPolicy("UserCanAddImage", AuthorizationPolicies.CanAddImage());
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Gallery}/{action=Index}/{id?}");

await app.RunAsync();
