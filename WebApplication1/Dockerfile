# Use .NET 9 SDK as the build environment
FROM mcr.microsoft.com/dotnet/nightly/sdk:9.0 AS build
WORKDIR /app

# Copy only the .csproj file first (to leverage Docker cache)
COPY WebApplication1/WebApplication1.csproj ./WebApplication1/
RUN dotnet restore WebApplication1/WebApplication1.csproj

# Copy the entire project and build it
COPY . .
WORKDIR /app/WebApplication1
RUN dotnet publish -c Release -o /out

# Use .NET 9 runtime as the execution environment
FROM mcr.microsoft.com/dotnet/nightly/aspnet:9.0
WORKDIR /app

# Copy the published app
COPY --from=build /out .

# Set environment variable for the port
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Start the application
CMD ["dotnet", "WebApplication1.dll"]
