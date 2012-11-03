using FubuTestingSupport;
using NUnit.Framework;

namespace Foilr.Tests
{
	[TestFixture]
	public class ExceptionRecordTester
	{
		private ExceptionRecord theRecord;

		[SetUp]
		public void SetUp()
		{
			theRecord = new ExceptionRecord();
		}

		[Test]
		public void defaults_to_server()
		{
			theRecord.Origin.ShouldEqual(ExceptionOrigin.Server);
		}
	}
}