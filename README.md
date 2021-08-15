/** SimpleContactEntry **/
.Net Core REST API Example project
SimpleContactEntry has CRUD functionality for json files in an embedded LiteDB database

/** To Run **/
Clone the Git Repo
Open the solution in Visual Studio and start a new instance
Open SimpleContact.postman_collection.json in Postman and send the various calls
 - This will likely require changing the routes to match the LocalHost port Visual Studio uses for your instance

 /** TODO **/
 This app is just a sample, but these would be the next action items if we wanted this in a production setting

 - Add LiteDB security
 - Store LiteDB credentials and file locations in a secure location
 - Add Auth Token etc to API Calls
 - Fix unit tests
	- Mock LiteDB connection
	- Test functionality of LiteDBRepo methods, not integration
 - Investigate the dependency warning for microsoft.aspnet.webapi.core
