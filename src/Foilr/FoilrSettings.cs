namespace Foilr
{
	public class FoilrSettings
	{
		public FoilrSettings()
		{
			ServiceUrl = "http://api.foilr.com/error";
		}

		public string ServiceUrl { get; set; }
		public string ApiKey { get; set; }

		public string LoggingUrl()
		{
			return string.Format("{0}?key={1}", ServiceUrl, ApiKey);
		}
	}
}