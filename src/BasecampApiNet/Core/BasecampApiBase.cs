using System.Net;
using System.Text;
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
            Projects = new ProjectEndpoint(ResponseCache);
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

        internal static ResponseCache ResponseCache { get; set; }
        public ProjectEndpoint Projects;
        public PeopleEndpoint People;

        public string CacheDump()
        {
            var sb = new StringBuilder();

            foreach (var item in ResponseCache.CacheDump())
            {
                sb.AppendFormat(string.Format("{0}=>{1} - {2} - {3}\n", item.Key, item.Value.TypeString, item.Value.LastRequested.ToString("R"), item.Value.ETag));
            }

            return sb.ToString();
        }

        public void ClearCache()
        {
            ResponseCache.ClearCache();
        }
    }
}
