using System.Collections.Generic;
using FubuTestingSupport;
using NUnit.Framework;

namespace Foilr.Tests
{
	[TestFixture]
	public class writing_an_exception_record
	{
		private ExceptionRecord theRecord;

		[SetUp]
		public void SetUp()
		{
			theRecord = new ExceptionRecord();	
		}

		private IDictionary<string, object> theValues
		{
			get { return theRecord.Values(); }
		}

		[Test]
		public void writes_the_errorType_type()
		{
			theValues["errorType"].ShouldEqual("server");

			theRecord.Origin = ExceptionOrigin.Client;
			theValues["errorType"].ShouldEqual("javascript");
		}

		[Test]
		public void writes_url_if_not_empty()
		{
			theRecord.WebLog.Url = "test/url";
			theValues["url"].ShouldEqual(theRecord.WebLog.Url);
		}

		[Test]
		public void no_url_if_empty()
		{
			theValues.ContainsKey("url").ShouldBeFalse();
		}

		[Test]
		public void writes_username_if_not_empty()
		{
			theRecord.WebLog.Username = "test";
			theValues["username"].ShouldEqual(theRecord.WebLog.Username);
		}

		[Test]
		public void no_username_if_empty()
		{
			theValues.ContainsKey("username").ShouldBeFalse();
		}

		[Test]
		public void writes_ip_if_not_empty()
		{
			theRecord.WebLog.IpAddress = "127.0.0.1";
			theValues["ipaddress"].ShouldEqual(theRecord.WebLog.IpAddress);
		}

		[Test]
		public void no_ip_if_empty()
		{
			theValues.ContainsKey("ipaddress").ShouldBeFalse();
		}

		[Test]
		public void writes_useragent_if_not_empty()
		{
			theRecord.WebLog.UserAgent = "Mozilla";
			theValues["useragent"].ShouldEqual(theRecord.WebLog.UserAgent);
		}

		[Test]
		public void no_useragent_if_empty()
		{
			theValues.ContainsKey("useragent").ShouldBeFalse();
		}

		[Test]
		public void writes_statusCode_if_not_null()
		{
			theRecord.WebLog.StatusCode = 404;
			theValues["statusCode"].ShouldEqual(theRecord.WebLog.StatusCode);
		}

		[Test]
		public void no_statusCode_if_empty()
		{
			theValues.ContainsKey("statusCode").ShouldBeFalse();
		}

		[Test]
		public void writes_server_if_not_empty()
		{
			theRecord.WebLog.ServerIdentifier = "node1";
			theValues["server"].ShouldEqual(theRecord.WebLog.ServerIdentifier);
		}

		[Test]
		public void no_server_if_empty()
		{
			theValues.ContainsKey("server").ShouldBeFalse();
		}

		[Test]
		public void writes_file_if_not_empty()
		{
			theRecord.File = "test1.js";
			theValues["file"].ShouldEqual(theRecord.File);
		}

		[Test]
		public void no_file_if_empty()
		{
			theValues.ContainsKey("file").ShouldBeFalse();
		}

		[Test]
		public void writes_lineNumber_if_not_null()
		{
			theRecord.LineNumber = 101;
			theValues["lineNumber"].ShouldEqual(theRecord.LineNumber);
		}

		[Test]
		public void no_lineNumber_if_null()
		{
			theValues.ContainsKey("lineNumber").ShouldBeFalse();
		}

		[Test]
		public void writes_message_if_not_empty()
		{
			theRecord.Message = "The Message";
			theValues["message"].ShouldEqual(theRecord.Message);
		}

		[Test]
		public void no_message_if_empty()
		{
			theValues.ContainsKey("message").ShouldBeFalse();
		}

		[Test]
		public void writes_stacktrace_if_not_empty()
		{
			theRecord.StackTrace = "something happened";
			theValues["stacktrace"].ShouldEqual(theRecord.StackTrace);
		}

		[Test]
		public void no_stacktrace_if_empty()
		{
			theValues.ContainsKey("stacktrace").ShouldBeFalse();
		}

		[Test]
		public void writes_additional_if_not_null()
		{
			var additional = new Dictionary<string, object> {{"blah", "blah"}};
			theRecord.Data = additional;
			theValues["additional"].ShouldEqual(theRecord.Data);
		}

		[Test]
		public void no_additional_if_null()
		{
			theValues.ContainsKey("additional").ShouldBeFalse();
		}
	}
}