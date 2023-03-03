## Scope
Ingest tick data and aggregated data from different sources via REST, SignalR, WebSockets, then push data to storage and send notifications.

## Microservice Diagram
![Microservice Diagram](https://github.com/quantarcanum/qarc.datafeed/blob/main/Qarc.DataFeed/Documentation/Diagram.png)

## Structure
Qarc.DataFeed Empty Solution
- Qarc.DataFeed.Startup (Console App) 
  - Entry point for starting Qarc.DataFeed.Adaptor.Api
  - Dirty CompositionRoot project hooking up dependencies for the whole microservice code   
- Qarc.DataFeed.Adaptor.Api (ASP.NET Core Web API) 
- Qarc.DataFeed.Adaptor.Mongo (ClassLibrary) 
  - Add MongoDb.Driver nuget
- Qarc.DataFeed.Core.Domain (ClassLibrary)
- Qarc.DataFeed.Core.Application (ClassLibrary)  

## Dependency Graph


## Tech Debt

 - Add CompositionRoot project for bootstrapping and REMOVE mongo & kafka project dependencies form API project!!!!
 - Point datafeed to Write mongo instance after cluster is ready
 - Add composion to models and write custom serializer for mongo mapper and also adjust automapper
 - Add input model fluent validation
 - Add Security
 - Add logging & tracing w/ correlation token after setting up the infrastructure in kubernetes 
 - Tests
