using Microsoft.AspNetCore.Authorization;

namespace ImageGallery.API.Authorization;

public class MustOwnImageHandler : AuthorizationHandler<MustOwnImageRequirement>
{
  private readonly IHttpContextAccessor _contextAccessor;

  public MustOwnImageHandler(IHttpContextAccessor contextAccessor)
  {
    _contextAccessor = contextAccessor ?? throw new ArgumentNullException(nameof(contextAccessor));
  }
  protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MustOwnImageRequirement requirement)
  {
    var imageId = _contextAccessor.HttpContext?.GetRouteValue("id")?.ToString();
    if (!Guid.TryParse(imageId, out Guid id))
    {
      context.Fail();
      return;
    }
    var ownerId = context.User.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
    if (ownerId == null)
    {
      context.Fail();
      return;
    }

  }
}
