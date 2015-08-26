using System.Net;
using BasecampApiNet.Endpoints;

namespace BasecampApiNet.Core
{
    public class BasecampApi
    {
        internal static NetworkCredential Credentials
        {
            get
            {
                return new NetworkCredential(Username, Password);
            }    
        }

        internal static string AccountId { get; set; }

        internal static string Username { get; set; }

        private static string Password { get; set; }

        public ProjectEndpoint Projects;
        public PeopleEndpoint People;

        public BasecampApi(string accountId, string username, string password)
        {
            Username = username;
            Password = password;
            AccountId = accountId;

            Projects = new ProjectEndpoint();
            People = new PeopleEndpoint();
        }
    }
}
