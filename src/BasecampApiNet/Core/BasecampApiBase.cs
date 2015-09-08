using System.Net;
using System.Text;
using BasecampApiNet.Endpoints;
using BasecampApiNet.Interfaces;

namespace BasecampApiNet.Core
{
    public abstract class BasecampApiBase
    {
        protected BasecampApiBase(string accountId, string username, string password, IResponseCache responseCache)
        {
            Username = username;
            Password = password;
            AccountId = accountId;

            ResponseCache = responseCache;
            Projects = new ProjectEndpoint(ResponseCache);
            People = new PeopleEndpoint(ResponseCache);
            Todos = new TodosEndpoint(ResponseCache);
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

        public static string Password { get; set; }

        internal static IResponseCache ResponseCache { get; set; }

        public ProjectEndpoint Projects;

        public PeopleEndpoint People;

        public TodosEndpoint Todos;

        public virtual string CacheDump()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("{0} items in the cache.\n", CacheCount());

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

        public int CacheCount()
        {
            return ResponseCache.CacheCount();
        }
    }
}
