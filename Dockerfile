# First stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /DockerSource

# Copy csproj and restore as distinct layers
COPY albumcollection/*.sln .
COPY albumcollection/albumcollection/*.csproj ./albumcollection/
RUN dotnet restore

# Copy everything else and build website
COPY albumcollection/. ./albumcollection/
WORKDIR /DockerSource/albumcollection
RUN dotnet publish -c release -o /DockerOutput/Website

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /DockerOutput/Website
COPY --from=build /DockerOutput/Website ./
# ENTRYPOINT ["dotnet", "herokutraining.dll"]

# For heroku compatibility
 CMD ASPNETCORE_URLS=http://*:$PORT dotnet albumcollection.dll


