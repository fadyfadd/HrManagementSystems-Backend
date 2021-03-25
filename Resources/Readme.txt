Technical Briefing.

This Application is composed of 2 parts
- Angular 11.2.5 version (client side)
- .Net Core WebApi 3.1 (server side)

the server side run by default on port https://localhost:44371/
and exposes a single rest service called dataprovider.
this rest service exposes the following interfaces

/HighestPaidEmployeeList
/YoungestEmployeeList
/EmployeeAgingBetween
/ManagerList

Note that no stored procedures are used , the backend solely rely on Linq and EF Core
Each of this service is used to create a view for the application in hand. 
In order to run this application the following prerequisites are needed

.Net framework core 3.1
Angular 11.2.5.1 installable using npm
Angular Material library installable using npm

As per your request sheet the tables used support pagination , filter and sorting.

in order to test the system do the following:

- Run the .Net application using visual studio 2019
- Open client-app folder and run npm install . As a result a big node_modules folder will 
be created where the javascript dependencies will be downloaded
- Restore the database HrManagementSystem

If for some reason the application failed to installed , I can provide a life demo on my machine when asked.
I am providing screenshots inside the solution folder to give you and idea of the final outcome/output.

Best Regards
Fady Faddoul
