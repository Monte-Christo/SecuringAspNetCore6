using Marvin.IDP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Marvin.IDP.Pages.User.Activation;

[SecurityHeaders]
[AllowAnonymous]
public class IndexModel : PageModel
{
  private readonly ILocalUserService _localUserService;

  public IndexModel(ILocalUserService localUserService)
  {
    _localUserService = localUserService ?? throw new ArgumentNullException(nameof(localUserService));
  }

  [BindProperty]
  public InputModel Input { get; set; }

  public async Task<IActionResult> OnGet(string securityCode)
  {
    if (await _localUserService.ActivateUserAsync(securityCode))
    {
      Input.Message = "Activation successful. Log in now";
    }
    else
    {
      Input.Message = "Activation failed. Go away";
    }

    await _localUserService.SaveChangesAsync();
    return Page();
  }
}

