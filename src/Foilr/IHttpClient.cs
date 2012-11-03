using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace Foilr
{
	public interface IHttpClient
	{
		void PostJson(string url, object model);
	}

	public class HttpClient : IHttpClient
	{
		public void PostJson(string url, object model)
		{
			try
			{
				post(url, model);
			}
			catch (Exception exc)
			{
				handleException(exc);
			}
		}

		private static void handleException(Exception exception)
		{
			if(exception != null)
				Debug.WriteLine(exception.Message);
		}

		private static void post(string url, object model)
		{
			var request = (HttpWebRequest)WebRequest.Create(url);
			request.Accept = "text/json";
			request.ContentType = "application/json";
			request.Method = "POST";

			var stream = request.GetRequestStream();
			var serializer = new JavaScriptSerializer();
			var json = serializer.Serialize(model);
			var bytes = Encoding.Default.GetBytes(json);

			stream.Write(bytes, 0, bytes.Length);

			stream.Close();

			request.GetResponse();
		}
	}
}