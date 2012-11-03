using System;

namespace Foilr
{
	public class FoilrService : IFoilrService
	{
		private readonly FoilrSettings _settings;
		private readonly IHttpClient _http;

		public FoilrService(FoilrSettings settings, IHttpClient http)
		{
			_settings = settings;
			_http = http;
		}

		public void LogException(Exception exception)
		{
			LogException(ExceptionRecord.FromException(exception));
		}

		public void LogException(ExceptionRecord record)
		{
			_http.PostJson(_settings.LoggingUrl(), record.Values());
		}

		public static IFoilrService Basic(FoilrSettings settings)
		{
			return new FoilrService(settings, new HttpClient());
		}
	}
}