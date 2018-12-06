# Asp.Net Core 2.1 Alert Razor Pages

I had used _Alerts_ before in numerous .Net 4.6 Framework web apps and wanted to do the same in Core 2.1 while leveraging all the cool new stuff like **Razor Pages**, **DI**, **Services** and **View Components**.  In the past, I had used the technique developed by James Chambers [see](http://jameschambers.com/2014/06/day-14-bootstrap-alerts-and-mvc-framework-tempdata/) which was part of his **Bootstrapping the MVC Framework MVC** series of blogs.  In that solution he used a BaseController class for the code and a shared partial view.  It worked well but things changed in 2.0 such that it quit working.

# ASP.NET Monsters to the rescue
In Episode #115: **Creating Bootstrap Alerts with the ASP.NET Core MVC Framework** [YouTube](https://www.youtube.com/watch?v=Z8RstrIaeFA) James walked through an upgrade to **Alerts** and except for one problem (at least for me it was) it doesn't do **RedirectToPage**.  Maybe I did something wrong I don't know, regardless I thought it would be usefull to have an example to work from (plus it will cause me to create more OSS / GitHub projects).

# Notes from the Video re. 2.1, TempData and serialization
- Here is what James had to say at [10:38](https://youtu.be/Z8RstrIaeFA?t=638)
> Returning to 2.1, the tempdata will serialized the objects for me.  When core came out it only accepts strings as eligible entries for the dictionary (which was string to string).  Previously (before core) we had a string, object dictionary so we could put whatever we wanted in there.  In version 1.x of Core, the object had to serialize the list to JSON and  de-serialize it on the way out.  As of 2.1 we no longer have to do that.
- The error message I get would indicate that this still is a problem at least when doing a `RredirectToPage();`

# No RedirectToPage - Works Fine
- Pages\AlertServiceRedirectTest.cshtml.cs
```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreAlerRP.Web.Core.Alerts;
using Microsoft.Extensions.Logging;

namespace AspNetCoreAlerRP.Web.Pages.Home
{
  public class AlertServiceTestModel : PageModel
  {
    public IPageAlertService _alert;
    private readonly ILogger log;
    public AlertServiceTestModel(IPageAlertService alertService, ILogger<AlertServiceTestModel> logger) 
    {
      log = logger;
      _alert = alertService;
    }

    public IActionResult OnGet()
    {
      try
      {
        _alert.Information("Inside AboutModel");
        _alert.Warning("After some information, a warning", true);
        _alert.Danger("Then Danger", true);  //
        _alert.Success("Success!!! --> It's my <b>middle</b> name.");
      }
      catch (System.Exception ex)
      {
        log.LogDebug(ex, nameof(OnGet));
        return RedirectToPage("/Error");
      }
      return Page();
    }
  }

}
```

# RedirectToPage - causes exception
- Pages\AlertServiceRedirectTest.cshtml.cs
- the code `return RedirectToPage("/About");` will trow an **exception**

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreAlerRP.Web.Core.Alerts;

namespace AspNetCoreAlerRP.Web.Pages
{
  public class AlertServiceRedirectTestModel : PageModel
  {
    public IPageAlertService _alert;
    
    public AlertServiceRedirectTestModel(IPageAlertService alertService)
    {
      _alert = alertService;
    }

    public IActionResult OnGet()
    {
      _alert.Information("Inside AlertServiceRedirectTestModel.  Redirect to About");
      return RedirectToPage("/About"); // THIS WILL THROW AN EXCEPTION
    }
  }
}

/*
The RedirectToPage("/About"); after an _alert has been inserted causes an unhandled exception
 - InvalidOperationException: 
    The 'Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TempDataSerializer' cannot serialize an object of type 
    'AspNetCoreAlerRP.Web.Core.Alerts.Alert'.
 
  - Microsoft.AspNetCore.Mvc.ViewFeatures.Internal.TempDataSerializer.EnsureObjectCanBeSerialized(object item) 
*/

```

