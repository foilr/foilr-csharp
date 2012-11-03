using System;
using FubuTestingSupport;
using NUnit.Framework;

namespace Foilr.Tests
{
	[TestFixture]
	public class creating_a_record_from_an_exception
	{
		private Exception theException;
		private ExceptionRecord theRecord;

		[SetUp]
		public void SetUp()
		{
			theException = new Exception("Test");
			theRecord = ExceptionRecord.FromException(theException);
		}

		[Test]
		public void sets_the_message()
		{
			theRecord.Message.ShouldEqual(theException.Message);
		}

		[Test]
		public void sets_the_file()
		{
			theRecord.StackTrace.ShouldEqual(theException.StackTrace);
		}
	}
}