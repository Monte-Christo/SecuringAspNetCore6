using System.IdentityModel.Tokens.Jwt;
using ImageGallery.API.Authorization;
using ImageGallery.API.DbContexts;
using ImageGallery.API.Services;
using ImageGallery.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

string ImageGalleryApi = nameof(ImageGalleryApi).ToLower();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(configure => configure.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddDbContext<GalleryContext>(options =>
{
  options.UseSqlite(
      builder.Configuration["ConnectionStrings:ImageGalleryDBConnectionString"]);
});

// register the repository
builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthorizationHandler, MustOwnImageHandler>();

// register AutoMapper-related services
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddOAuth2Introspection(o =>
  {
    o.Authority = "https://localhost:5001";
    o.ClientId = ImageGalleryApi;
    o.ClientSecret = "apisecret";
    o.NameClaimType = "given_name";
    o.RoleClaimType = "role";
  });
//.AddJwtBearer(o =>
//{
//  o.Authority = "https://localhost:5001";
//  o.Audience = ImageGalleryApi;
//  o.TokenValidationParameters = new()
//  {
//    NameClaimType = "given_name",
//    RoleClaimType = "role",
//    ValidTypes = new[] { "at+jwt" }
//  };
//});

builder.Services.AddAuthorization(o =>
{
  o.AddPolicy("UserCanAddImage", AuthorizationPolicies.CanAddImage());
  o.AddPolicy("ClientApplicationCanWrite", policyBuilder =>
  {
    policyBuilder.RequireClaim("scope", $"{ImageGalleryApi}.write");
  });
  o.AddPolicy("MustOwnImage", policyBuilder =>
  {
    policyBuilder.RequireAuthenticatedUser();
    policyBuilder.AddRequirements(new MustOwnImageRequirement());
  });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
