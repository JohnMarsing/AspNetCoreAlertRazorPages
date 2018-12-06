using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreAlerRP.Web.Core.Alerts;

namespace AspNetCoreAlerRP.Web.Pages
{
	public class AlertServiceRedirectTestModel : PageModel
	{
		public IAlertService _alert;
		
		public AlertServiceRedirectTestModel(IAlertService alertService)
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
