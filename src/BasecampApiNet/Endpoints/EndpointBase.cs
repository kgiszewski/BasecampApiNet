using BasecampApiNet.Interfaces;

namespace BasecampApiNet.Endpoints
{
    public class EndpointBase
    {
        protected IResponseCache ResponseCache;

        public EndpointBase(IResponseCache responseCache)
        {
            ResponseCache = responseCache;
        }
    }
}
