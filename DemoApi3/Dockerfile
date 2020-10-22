#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY DemoApi3.csproj DemoApi3/
RUN dotnet restore DemoApi3/DemoApi3.csproj
COPY . DemoApi3
WORKDIR /src/DemoApi3
RUN dotnet build DemoApi3.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish DemoApi3.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DemoApi3.dll"]