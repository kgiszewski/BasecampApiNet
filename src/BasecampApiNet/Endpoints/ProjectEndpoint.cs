using System.Collections.Generic;
using BasecampApiNet.Core;
using BasecampApiNet.Models;

namespace BasecampApiNet.Endpoints
{
    public class ProjectEndpoint : EndpointBase
    {
        public ProjectEndpoint(ResponseCache responseCache) 
            : base (responseCache)
        {
            
        }

        public IEnumerable<ProjectResultModel> GetAll()
        {
            return ResponseCache.Get<IEnumerable<ProjectResultModel>>(string.Format(Constants.BASECAMP_URL, 1, "projects.json"));
        }

        public ProjectResultModel Get(int projectId)
        {
            return ResponseCache.Get<ProjectResultModel>(string.Format(Constants.BASECAMP_URL, 1, string.Format("projects/{0}.json", projectId)));
        }
    }
}
