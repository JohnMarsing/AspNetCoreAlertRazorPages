namespace AspNetCoreAlerRP.Web.Core.PageAlerts
{
	public interface IPageAlertService
	{
		void Danger(string message, bool dismissable = true);
		void Information(string message, bool dismissable = true);
		void Success(string message, bool dismissable = true);
		void Warning(string message, bool dismissable = true);
	}
}