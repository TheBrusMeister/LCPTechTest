# LPCTechTest
Repository for LPC tech test.

Summary:
I have created a Data API for handling the Client related information. This API would then be consumed by a front end application to then be able to perform the associated actions. A front end has not been created for this rest api as part of this test.

Swagger for the Data API can be viewed by starting the project via IIS and going to /swagger. The database aspect is not wired up to a database. In order to make this solution work as expected a DB schema would need to be created for the Client and then the associated stored procedures as named in the dbwrapper to get, create, update, delete and list client information.

The unit tests for the client details service can be ran from the tests folder.
