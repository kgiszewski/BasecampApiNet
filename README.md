# BasecampApiNet

This is a WIP .NET API wrapper for the BSX API for Basecamp.

##Syntax Example##

###All Projects###
`var project = new BasecampApi("account-id", "user", "password").Projects.GetAll();`

###Single Project###
`var project = new BasecampApi("account-id", "user", "password").Projects.Get(12345);`

###Reuse the Interface###

```
//get the api
var api = new BasecampApi("account-id", "user", "password"); //store this locally or globally

//get all projects
api.Projects.GetAll();

##WIP##
This wrapper is work in progress.

Priority of work:

* GET requests
* HTTP Caching
* Pagination
* Everything else

##Dependencies##
Only Newtonsoft JSON.net at the moment.
