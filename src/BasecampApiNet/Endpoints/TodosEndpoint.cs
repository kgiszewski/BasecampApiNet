using System.Collections.Generic;
using BasecampApiNet.Core;
using BasecampApiNet.Interfaces;
using BasecampApiNet.Models;

namespace BasecampApiNet.Endpoints
{
    public class TodosEndpoint : EndpointBase
    {
        public TodosEndpoint(IResponseCache responseCache)
            :base(responseCache)
        {
            
        }
    }
}
