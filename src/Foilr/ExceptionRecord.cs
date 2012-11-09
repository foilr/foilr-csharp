using System;
using System.Collections.Generic;
using System.Linq;

namespace Foilr
{
	public class ExceptionRecord
	{
		public ExceptionRecord()
		{
			Origin = ExceptionOrigin.Server;
			Data = new Dictionary<string, object>();
			WebLog = new WebExceptionLog();
		}

		[Alias("errorType")]
		public ExceptionOrigin Origin { get; set; }

		public string File { get; set; }
		[Alias("lineNumber")]
		public int? LineNumber { get; set; }

		public string Message { get; set; }
		public string StackTrace { get; set; }

		[Alias("additional")]
		public IDictionary<string, object> Data { get; set; }
		public WebExceptionLog WebLog { get; set; }

		public IDictionary<string, object> Values()
		{
			var values = new Dictionary<string, object>();
			values.Write(x => x.Origin, this, Origin == ExceptionOrigin.Server ? "server" : "javascript");
			values.Write(x => x.File, this);
			values.Write(x => x.LineNumber, this);
			values.Write(x => x.Message, this);
			values.Write(x => x.StackTrace, this);
			
			WebLog.WriteTo(values);

			if(Data.Keys.Any())
			{
				values.Write(x => x.Data, this);
			}

			return values;
		}

		public static ExceptionRecord FromException(Exception exception)
		{
			return new ExceptionRecord
			       {
					   Message = exception.Message,
					   StackTrace = exception.StackTrace
			       };
		}
	}
}