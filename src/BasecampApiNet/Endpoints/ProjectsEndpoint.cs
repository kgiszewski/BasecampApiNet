using System;
using System.Collections.Generic;
using BasecampApiNet.Core;
using BasecampApiNet.Helpers;
using BasecampApiNet.Interfaces;
using BasecampApiNet.Models;

namespace BasecampApiNet.Endpoints
{
    public class ProjectsEndpoint : EndpointBase
    {
        public ProjectsEndpoint(IResponseCache responseCache) 
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

        public IEnumerable<TodoResultModel> GetTodos(int projectId)
        {
            return ResponseCache.Get<IEnumerable<TodoResultModel>>(string.Format(Constants.BASECAMP_URL, 1, string.Format("projects/{0}/todos.json", projectId)));
        }

        public IEnumerable<EventResultModel> GetEvents(int projectId, DateTime since)
        {
            return ResponseCache.Get<IEnumerable<EventResultModel>>(string.Format(Constants.BASECAMP_URL, 1, string.Format("projects/{0}/events.json?since={1}", projectId, since.ToStandardDate())));
        }
    }
}
