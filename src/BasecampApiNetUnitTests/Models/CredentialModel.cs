using System.Xml.Linq;

namespace BasecampApiNetUnitTests.Models
{
    public class CredentialModel
    {
        public string AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static CredentialModel GetCredentials()
        {
            var doc = XDocument.Load("BasecampTestCredentials.xml");

            return new CredentialModel()
            {
                AccountId = doc.Root.Element("accountId").Value,
                Username = doc.Root.Element("username").Value,
                Password = doc.Root.Element("password").Value
            };
        }
    }
}
