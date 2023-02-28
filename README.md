## Scope
Ingest tick data and aggregated data from different sources via REST, SignalR, WebSockets, then push data to storage and send notifications.

## Microservice Diagram
![Microservice Diagram](https://github.com/quantarcanum/qarc.datafeed/blob/main/Qarc.DataFeed/Documentation/Diagram.png)

## Structure
Qarc.DataFeed Empty Solution
- Qarc.DataFeed.Startup (Console App) 
  - Entry point for starting Qarc.DataFeed.Adaptor.Api
  - Dirty CompositionRoot project hooking up dependencies for the whole microservice code   
- Qarc.DataFeed.Adaptor (ASP.NET Core Web API) 
- Qarc.DataFeed.Core.Domain (ClassLibrary)
- Qarc.DataFeed.Core.Application (ClassLibrary)  

## Dependency Graph
