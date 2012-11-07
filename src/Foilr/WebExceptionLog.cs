using System.Collections.Generic;

namespace Foilr
{
	public class WebExceptionLog
	{
		public string Url { get; set; }
		[Alias("statusCode")]
		public int? StatusCode { get; set; }
		public string UserAgent { get; set; }
		public string Username { get; set; }
		public string IpAddress { get; set; }
		[Alias("server")]
		public string ServerIdentifier { get; set; }

		public void WriteTo(IDictionary<string, object> values)
		{
			values.Write(x => x.Url, this);
			values.Write(x => x.StatusCode, this);
			values.Write(x => x.UserAgent, this);
			values.Write(x => x.Username, this);
			values.Write(x => x.IpAddress, this);
			values.Write(x => x.ServerIdentifier, this);
		}
	}
}