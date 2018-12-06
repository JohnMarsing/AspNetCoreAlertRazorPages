using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AspNetCoreAlerRP.Web.Core.Alerts; 

namespace AspNetCoreAlerRP.Web.ViewComponents
{
	public class AlertsViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var alerts = TempData.ContainsKey(Alert.TempDataKey)
			? (List<Alert>)TempData[Alert.TempDataKey]
			: new List<Alert>();

			return View(alerts);
			
		}
	}
}

