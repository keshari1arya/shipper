# shipper

To run API

Make sure you have a healthy DB get the connection string and replace it in appsettings.json of shipper-api file

Either open the solution in VisualStudio and click run project. (shipper_api lunch option is recomended)

OR do a dotnet build and dotnet run under shipper/shipper-api

UI
(I am using angular as my front end app)

then take api base url

go to ./shipper/ui/shipper-ui/src/app.service.ts and update baseUrl

under ./shipper/ui/shipper-ui folder run follwing commands

npm install

ng serve

goto localhost:4200 and you will find the app 



