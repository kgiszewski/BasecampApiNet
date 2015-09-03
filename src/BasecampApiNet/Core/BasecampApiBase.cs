using System.Net;
using BasecampApiNet.Endpoints;

namespace BasecampApiNet.Core
{
    public abstract class BasecampApiBase
    {
        protected BasecampApiBase(string accountId, string username, string password)
        {
            Username = username;
            Password = password;
            AccountId = accountId;
            
            ResponseCache = new ResponseCache();
            Projects = new ProjectEndpoint();
            People = new PeopleEndpoint(ResponseCache);
        }

        public static NetworkCredential Credentials
        {
            get
            {
                return new NetworkCredential(Username, Password);
            }
        }

        public static string AccountId { get; set; }

        public static string Username { get; set; }

        protected static string Password { get; set; }

        public static ResponseCache ResponseCache { get; set; }
        public ProjectEndpoint Projects;
        public PeopleEndpoint People;
    }
}
