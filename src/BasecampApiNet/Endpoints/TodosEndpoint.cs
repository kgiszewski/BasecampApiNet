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

        public IEnumerable<TodoResultModel> GetAllForProject(int projectId)
        {
            return ResponseCache.Get<IEnumerable<TodoResultModel>>(string.Format(Constants.BASECAMP_URL, 1, string.Format("projects/{0}/todos.json", projectId)));
        }
    }
}
