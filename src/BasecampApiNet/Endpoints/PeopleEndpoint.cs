﻿using System;
using System.Collections.Generic;
using BasecampApiNet.Core;
using BasecampApiNet.Helpers;
using BasecampApiNet.Interfaces;
using BasecampApiNet.Models;

namespace BasecampApiNet.Endpoints
{
    public class PeopleEndpoint : EndpointBase
    {
        public PeopleEndpoint(IResponseCache responseCache) 
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

        public IEnumerable<PersonTodoListResultModel> GetAssignedTodoList(int personId)
        {
            return ResponseCache.Get<IEnumerable<PersonTodoListResultModel>>(string.Format(Constants.BASECAMP_URL, 1, string.Format("people/{0}/assigned_todos.json", personId)));
        }

        public IEnumerable<EventResultModel> GetEvents(int personId, DateTime since)
        {
            return ResponseCache.Get<IEnumerable<EventResultModel>>(string.Format(Constants.BASECAMP_URL, 1, string.Format("people/{0}/events.json?since={1}", personId, since.ToStandardDate())));
        }
    }
}
