#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443
ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Qarc.DataFeed.Adapter.Api/Qarc.DataFeed.Adapter.Api.csproj", "Qarc.DataFeed.Adapter.Api/"]
COPY ["Qarc.DataFeed.Adapter.Mongo/Qarc.DataFeed.Adapter.Mongo.csproj", "Qarc.DataFeed.Adapter.Mongo/"]
COPY ["Qarc.DataFeed.Core.Application/Qarc.DataFeed.Core.Application.csproj", "Qarc.DataFeed.Core.Application/"]
COPY ["Qarc.DataFeed.Core.Domain/Qarc.DataFeed.Core.Domain.csproj", "Qarc.DataFeed.Core.Domain/"]
RUN dotnet restore "Qarc.DataFeed.Adapter.Api/Qarc.DataFeed.Adapter.Api.csproj"
COPY . .
WORKDIR "/src/Qarc.DataFeed.Adapter.Api"
RUN dotnet build "Qarc.DataFeed.Adapter.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Qarc.DataFeed.Adapter.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Qarc.DataFeed.Adapter.Api.dll"]