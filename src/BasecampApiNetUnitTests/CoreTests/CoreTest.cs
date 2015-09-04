using BasecampApiNet.Core;
using BasecampApiNetUnitTests.Models;
using NUnit.Framework;

namespace BasecampApiNetUnitTests.CoreTests
{
    [TestFixture]
    public class CoreTest
    {
        static readonly CredentialModel Credentials = CredentialModel.GetCredentials();

        private BasecampApiBase Api = new BasecampApiFactory().GetApi(Credentials.AccountId, Credentials.Username, Credentials.Password);
        
        [Test]
        public void Can_Cache_Responses()
        {
            var people = Api.People.GetAll();

            Assert.AreEqual(1, Api.CacheCount());

            Api.ClearCache();

            Assert.AreEqual(0, Api.CacheCount());

            var x = Api.People.GetAll();

            Assert.AreEqual(1, Api.CacheCount());

            var y = Api.People.GetAll();

            Assert.AreEqual(1, Api.CacheCount());

            var z = Api.Projects.GetAll();

            Assert.AreEqual(2, Api.CacheCount());
        }
    }
}
