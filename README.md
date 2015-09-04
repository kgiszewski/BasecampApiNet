# BasecampApiNet

This is a WIP .NET API wrapper for the BCX API for Basecamp. It returns staticly typed models and all is needed is the accountId, username and password.

##Syntax Example##

###All Projects###
`var project = new BasecampApiFactory().GetApi("account-id", "user", "password").Projects.GetAll();`

###Single Project###
`var project = new BasecampApiFactory().GetApi("account-id", "user", "password").Projects.Get(12345);`

###Reuse the Interface###

```
//get the api
var api = new BasecampApiFactory().GetApi("account-id", "user", "password"); //store this locally or globally

//get all projects
api.Projects.GetAll();
```

##WIP##
This wrapper is work in progress. 

Caching is in place with `MemoryCache`. If wish you can wrap this project into a Singleton to ensure the cache lasts as long as the application. This may be incorporated at some point.

Mostly Done:
* Project GET
* People GET
* TODOs GET
* UnitTests

Priority of work:

* Pagination - Presently if you have more that 25 items in a result, you'll not get items 26+.
* GET requests
* Singleton
* Everything else

###Everything Else###

I'd like to get to these:
* POST/PUT/DELETE verbs

##Dependencies##
Only Newtonsoft JSON.net at the moment.
