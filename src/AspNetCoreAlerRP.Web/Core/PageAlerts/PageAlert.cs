namespace AspNetCoreAlerRP.Web.Core.PageAlerts
{
	public class PageAlert
	{
		public const string TempDataKey = "TempDataAlerts";

		public string AlertStyle { get; set; }
		public string Message { get; set; }
		public bool Dismissable { get; set; }
	}

	public static class PageAlertStyles
	{
		public const string Success = "success";
		public const string Information = "info";
		public const string Warning = "warning";
		public const string Danger = "danger";
	}
}

