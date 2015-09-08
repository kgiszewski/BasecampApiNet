using BasecampApiNet.Interfaces;

namespace BasecampApiNet.Core
{
    public class BasecampApi : BasecampApiBase
    {
        public BasecampApi(string accountId, string username, string password, IResponseCache responseCache) 
            : base (accountId, username, password, responseCache)
        {

        }
    }
}
