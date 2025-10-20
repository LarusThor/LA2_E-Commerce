FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files
COPY OrderManagement.Models/OrderManagement.Models.csproj OrderManagement.Models/
COPY OrderManagement.Repositories/OrderManagement.Repositories.csproj OrderManagement.Repositories/
COPY OrderManagement.Services/OrderManagement.Services.csproj OrderManagement.Services/
COPY OrderManagement.WebApi/OrderManagement.WebApi.csproj OrderManagement.WebApi/

# Restore dependencies
RUN dotnet restore OrderManagement.WebApi/OrderManagement.WebApi.csproj

# Copy all files
COPY . .

WORKDIR /src/OrderManagement.WebApi
RUN dotnet publish -c Release -o /app

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "OrderManagement.WebApi.dll"]
