using System;
using NUnit.Framework;

namespace Foilr.Tests
{
	[TestFixture]
	public class debugging
	{
		[Test]
		public void blah()
		{
			var settings = new FoilrSettings
						   {
							   ApiKey = "1c8c537f982144c377e9101507f365ef",
							   ServiceUrl = "http://api.foilr.com/exception"
						   };

			var exception = new Exception("Oh Hai");
			FoilrService
				.Basic(settings)
				.LogException(exception);
		}
	}
}