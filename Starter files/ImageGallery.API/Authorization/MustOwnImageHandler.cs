using ImageGallery.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace ImageGallery.API.Authorization;

public class MustOwnImageHandler : AuthorizationHandler<MustOwnImageRequirement>
{
  private readonly IGalleryRepository _galleryRepository;
  private readonly IHttpContextAccessor _contextAccessor;

  public MustOwnImageHandler(IGalleryRepository galleryRepository ,IHttpContextAccessor contextAccessor)
  {
    _galleryRepository = galleryRepository ?? throw new ArgumentNullException(nameof(galleryRepository));
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
    if (!await _galleryRepository.IsImageOwnerAsync(id, ownerId))
    {
      context.Fail();
      return;
    }
    context.Succeed(requirement);
  }
}
