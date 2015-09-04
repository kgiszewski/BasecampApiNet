using BasecampApiNet.Core;

namespace BasecampApiNet.Endpoints
{
    public class EndpointBase
    {
        protected ResponseCache ResponseCache;

        public EndpointBase(ResponseCache responseCache)
        {
            ResponseCache = responseCache;
        }
    }
}
