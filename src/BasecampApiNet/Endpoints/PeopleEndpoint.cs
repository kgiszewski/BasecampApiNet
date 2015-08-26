using System.Collections.Generic;
using BasecampApiNet.Core;
using BasecampApiNet.Helpers;
using BasecampApiNet.Models;

namespace BasecampApiNet.Endpoints
{
    public class PeopleEndpoint
    {
        public IEnumerable<PeopleResultModel> GetAll()
        {
            //TODO: handle pagination
            return WebHelper.Get(string.Format(Constants.BASECAMP_URL, 1, "projects.json")).Result.AsListModel<PeopleResultModel>(); 
        } 
    }
}
