using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreAlerRP.Web.Core.Alerts;
using Microsoft.Extensions.Logging;

namespace AspNetCoreAlerRP.Web.Pages.Home
{
	public class AlertServiceTestModel : PageModel
	{
		public IAlertService _alert;
		private readonly ILogger log;
		public AlertServiceTestModel(IAlertService alertService, ILogger<AlertServiceTestModel> logger) 
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
