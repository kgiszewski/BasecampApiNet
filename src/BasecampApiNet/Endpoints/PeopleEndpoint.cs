using System.Collections.Generic;
using BasecampApiNet.Core;
using BasecampApiNet.Models;

namespace BasecampApiNet.Endpoints
{
    public class PeopleEndpoint : EndpointBase
    {
        public PeopleEndpoint(ResponseCache responseCache) 
            : base (responseCache)
        {
            
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
