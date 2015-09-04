using System.Linq;
using BasecampApiNet.Core;
using BasecampApiNetUnitTests.Models;
using NUnit.Framework;

namespace BasecampApiNetUnitTests.EndpointTests
{
    [TestFixture]
    public class ProjectTests
    {
        static readonly CredentialModel Credentials = CredentialModel.GetCredentials();

        private BasecampApiBase Api = new BasecampApiFactory().GetApi(Credentials.AccountId, Credentials.Username, Credentials.Password);
        
        [Test]
        public void Can_Get_Projects()
        {
            var firstProject = Api.Projects.GetAll().First();

            Assert.IsNotNull(firstProject);

            Assert.GreaterOrEqual(firstProject.Id, 0);

            var project = Api.Projects.Get(firstProject.Id);

            Assert.IsNotNull(project);

            Assert.GreaterOrEqual(project.Id, 0);
        }
    }
}
