#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443

#FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
#WORKDIR /src
#COPY ["WebAPIDevops-H2/WebAPIDevops-H2.csproj", "WebAPIDevops-H2/"]
#RUN dotnet restore "WebAPIDevops-H2/WebAPIDevops-H2.csproj"
#COPY . .
#WORKDIR "/src/WebAPIDevops-H2"
#RUN dotnet build "WebAPIDevops-H2.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "WebAPIDevops-H2.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "WebAPIDevops-H2.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers

COPY *.csproj ./

RUN dotnet restore

# Copy everything else and build

COPY . ./

RUN dotnet publish -c Release -o out

# Build runtime image

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "WebAPIDevops-H2.dll"]