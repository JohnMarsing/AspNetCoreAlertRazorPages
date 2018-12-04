using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AspNetCoreAlerRP.Web.Core.PageAlerts; 

namespace AspNetCoreAlerRP.Web.ViewComponents
{
	public class PageAlertsViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			var alerts = TempData.ContainsKey(PageAlert.TempDataKey)
			? (List<PageAlert>)TempData[PageAlert.TempDataKey]
			: new List<PageAlert>();

			return View(alerts);
			
		}
	}
}

