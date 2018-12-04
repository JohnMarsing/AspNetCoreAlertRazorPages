using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;

namespace AspNetCoreAlerRP.Web.Core.PageAlerts
{
	//public class PageAlertService
	public class PageAlertService : IPageAlertService
	{
		private readonly ITempDataDictionary _tempData;

		public PageAlertService(IHttpContextAccessor contextAccessor, 
														ITempDataDictionaryFactory tempDataDictionaryFactory)
		{
			_tempData = tempDataDictionaryFactory.GetTempData(contextAccessor.HttpContext);
		}

		public void Success(string message, bool dismissable = true)
		{
			AddAlert(PageAlertStyles.Success, message, dismissable);
		}

		public void Information(string message, bool dismissable = true)
		{
			AddAlert(PageAlertStyles.Information, message, dismissable);
		}

		public void Warning(string message, bool dismissable = true)
		{
			AddAlert(PageAlertStyles.Warning, message, dismissable);
		}

		public void Danger(string message, bool dismissable = true)
		{
			AddAlert(PageAlertStyles.Danger, message, dismissable);
		}

		private void AddAlert(string alertStyle, string message, bool dismissable)
		{
			var alerts = _tempData.ContainsKey(PageAlert.TempDataKey)
					? (List<PageAlert>)_tempData[PageAlert.TempDataKey]
					: new List<PageAlert>();

			alerts.Add(new PageAlert
			{
				AlertStyle = alertStyle,
				Message = message,
				Dismissable = dismissable
			});

			_tempData[PageAlert.TempDataKey] = alerts;

		}
	}
}
