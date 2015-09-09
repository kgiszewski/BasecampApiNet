using System;
using System.Collections.Generic;
using BasecampApiNet.Core;
using BasecampApiNet.Helpers;
using BasecampApiNet.Interfaces;
using BasecampApiNet.Models;

namespace BasecampApiNet.Endpoints
{
    public class EventsEndpoint : EndpointBase
    {
        public EventsEndpoint(IResponseCache responseCache) 
            : base (responseCache)
        {
            
        }

        public IEnumerable<EventResultModel> GetAll(DateTime since)
        {
            return ResponseCache.Get<IEnumerable<EventResultModel>>(string.Format(Constants.BASECAMP_URL, 1, string.Format("events.json?since={0}", since.ToStandardDate())));
        }
    }
}
 