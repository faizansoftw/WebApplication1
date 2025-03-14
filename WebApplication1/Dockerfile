# Use the official .NET Core 9 SDK as the build environment
FROM mcr.microsoft.com/dotnet/nightly/sdk:9.0 AS build
WORKDIR /app

# Copy everything and restore dependencies
COPY . ./
RUN dotnet restore

# Build and publish the app
RUN dotnet publish -c Release -o /out

# Use the official .NET Core 9 runtime as the execution environment
FROM mcr.microsoft.com/dotnet/nightly/aspnet:9.0
WORKDIR /app

# Copy the published output from the build step
COPY --from=build /out .

# Set the environment variable for the port
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Start the application
CMD ["dotnet", "WebApplication1.dll"]
