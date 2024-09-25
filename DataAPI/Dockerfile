# Use the official .NET 6 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files into the container
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Use the official .NET 6 runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .

# Command to run the Web API
ENTRYPOINT ["dotnet", "MyWebAPI.dll"]
