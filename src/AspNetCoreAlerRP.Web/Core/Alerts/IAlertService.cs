namespace AspNetCoreAlerRP.Web.Core.Alerts
{
	public interface IAlertService
	{
		void Danger(string message, bool dismissable = true);
		void Information(string message, bool dismissable = true);
		void Success(string message, bool dismissable = true);
		void Warning(string message, bool dismissable = true);
	}
}