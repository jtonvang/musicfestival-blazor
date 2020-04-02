# MusicFestival Blazor Templates

This is a ASP.NET Blazor WebAssembly port of Episervers excellent [Music Festival](https://github.com/episerver/musicfestival-vue-template) demo site. 

Blazor enables running our .NET code directly in the browser using WebAssembly. This allows us to make an SPA or any application with a rich front-end without using Javascript at all. 

Blazor requires .NET Core and so it needs a standalone project, but the output from a publish can be served on a .NET Framework site (or any other platform). To run it alongside Episerver, there are some UrlRewrite-rules in place that route requests to a subdirectory were we serve the Blazor application from. Requests made to Episerver, Content Delivery API and locations the UI depends on are exempt from these rules.

The Blazor application is automatically published and copied to the Episerver site on every build, it's important to set the Episerver-project as startup-project to get it working out of the box. 


## Prerequisites

This project uses:
* .NET Core SDK 3.1.103 or higher  ([download here](https://dotnet.microsoft.com/download/dotnet-core/3.1))
* Visual Studio 2019 version 16.4.5 or higher with the ASP.NET and web development workload
* SQL Server 2016 Express LocalDB ([download here](https://www.microsoft.com/en-us/sql-server/sql-server-downloads))

## Setup and Run

1. Run `setup.cmd`
2. Open `MusicFestival.Blazor.sln` 
3. Make sure The MusicFestival.Blazor.Epi project is set as the startup project (instructions for running the Blazor-templates stand-alone further down)
4. Press F5 to run (first time loading will take some time, due to DB being populated)
5. Login on `/episerver` with either one of the following:

|Name    |Password    |Mailbox | Email |
|--------|------------|--------|-------|
|cmsadmin|sparr0wHawk |        |       |
|emil    |sparr0wHawk |https://www.mailinator.com/v3/index.jsp?zone=public&query=epic-emil   |epic-emil@mailinator.com   |
|ida     |sparr0wHawk |https://www.mailinator.com/v3/index.jsp?zone=public&query=epic-ida    |epic-ida@mailinator.com    |
|alfred  |sparr0wHawk |https://www.mailinator.com/v3/index.jsp?zone=public&query=epic-alfred |epic-alfred@mailinator.com |
|lina    |sparr0wHawk |https://www.mailinator.com/v3/index.jsp?zone=public&query=epic-lina   |epic-lina@mailinator.com   |

## Notable files

### Routing + deserialization

* [ContentApiRouter.cs](src/MusicFestival.Blazor.Template/Routing/ContentApiRouter.cs) : custom router replacing the default Blazor router, enabling rendering components based on response from the API. 
* [ContentTypeHelper.cs](src/MusicFestival.Blazor.Template/Helpers/ContentTypeHelper.cs) : this static class resolves the types from the API to the Blazor Component types. 
* [PageTypeConverter.cs](src/MusicFestival.Blazor.Template/Json/PageTypeConverter.cs) : custom JSON converter for deserializing page types from the API *while* maintaining polymorphism.
* [BlockTypeConverter.cs](src/MusicFestival.Blazor.Template/Json/BlockTypeConverter.cs) : same as above, but for blocks.

### Services + state

* [ContentApiService.cs](src/MusicFestival.Blazor.Template/Services/ContentApiService.cs) : the service that fetches data from Content Delivery API
* [StateService.cs](src/MusicFestival.Blazor.Template/Services/StateService.cs) : this service holds the state (current viewmodels etc)

### API

* [ExtendedContentModelMapper.cs](src/MusicFestival.Blazor.Epi/Models/ExtendedContentModelMapper.cs): flattens the ContentDeliveryAPI JSON and enables languages.


## Debugging 

Blazor WebAssembly debugging in Visual Studio will be available next preview version (3.2 preview 3), but for now debugging can be done (with a bit of effort) in Chrome or the new Edge.
Follow the steps in https://itnext.io/debugging-blazor-web-assembly-apps-c47ef25bcb5f to get started, or wait until this repo is updated to the next preview version which will be when VS 2019 16.6 is officially released. 

## Running the Blazor Application standalone

When developing features etc, it might be less cumbersome to run the Blazor application standalone. You can do this by setting up the Episerver site in IIS as a local site and configure the URL in [settings.json](src/MusicFestival.Blazor.Template/wwwroot/settings.json) so the Blazor app will know where to make requests to the Content Delivery API. 

Bear in mind that Blazor uses the browser's Fetch API and requests to Content Delivery API will be subject to certificate and CORS policies.
