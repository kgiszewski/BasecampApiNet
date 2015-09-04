using BasecampApiNet.Core;
using BasecampApiNetUnitTests.Models;
using NUnit.Framework;

namespace BasecampApiNetUnitTests.CoreTests
{
    [TestFixture]
    public class CoreTest
    {
        [Test]
        public void Can_Cache_Responses()
        {
            var credentials = CredentialModel.GetCredentials();

            var api = new BasecampApiFactory().GetApi(credentials.AccountId, credentials.Username, credentials.Password);

            var people = api.People.GetAll();

            Assert.IsNotNullOrEmpty(api.CacheDump());
        }
    }
}
