using System.Collections.Generic;
using BasecampApiNet.Core;
using BasecampApiNet.Models;

namespace BasecampApiNet.Endpoints
{
    public class PeopleEndpoint
    {
        protected ResponseCache ResponseCache;

        public PeopleEndpoint(ResponseCache responseCache)
        {
            ResponseCache = responseCache;
        }

        public IEnumerable<PeopleResultModel> GetAll()
        {
            return ResponseCache.Get<IEnumerable<PeopleResultModel>>(string.Format(Constants.BASECAMP_URL, 1, "people.json"));
        }

        public PeopleResultModel Get(int personId)
        {
            return ResponseCache.Get<PeopleResultModel>(string.Format(Constants.BASECAMP_URL, 1, string.Format("people/{0}.json", personId)));
        }
    }
}
