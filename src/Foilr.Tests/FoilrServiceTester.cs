using FubuTestingSupport;
using NUnit.Framework;
using Rhino.Mocks;

namespace Foilr.Tests
{
	[TestFixture]
	public class FoilrServiceTester : InteractionContext<FoilrService>
	{
		private FoilrSettings theSettings;

		protected override void beforeEach()
		{
			theSettings = new FoilrSettings
			              {
			              	ApiKey = "test"
			              };

			Services.Inject(theSettings);
		}

		[Test]
		public void posts_json_for_the_record()
		{
			var theRecord = new ExceptionRecord();
			ClassUnderTest.LogException(theRecord);

			MockFor<IHttpClient>().AssertWasCalled(x => x.PostJson(theSettings.LoggingUrl(), theRecord.Values()));
		}
	}
}