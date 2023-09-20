# get base sdk image from Microsoft
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# copy the csproj file and restore any dependecies (via Nuget)
COPY *.csproj ./
RUN dotnet restore

# copy the project files and build our release
COPY . ./
RUN dotnet publish -c release -o /app

# generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app ./
ENTRYPOINT ["dotnet", "DemoApiPushDocker.dll"]