FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files for all dependent projects
COPY ProductCatalog.Models/ProductCatalog.Models.csproj ProductCatalog.Models/
COPY ProductCatalog.Repositories/ProductCatalog.Repositories.csproj ProductCatalog.Repositories/
COPY ProductCatalog.Services/ProductCatalog.Services.csproj ProductCatalog.Services/
COPY ProductCatalog.WebApi/ProductCatalog.WebApi.csproj ProductCatalog.WebApi/

# Restore dependencies
RUN dotnet restore ProductCatalog.WebApi/ProductCatalog.WebApi.csproj

# Copy all source files
COPY . .

WORKDIR /src/ProductCatalog.WebApi
RUN dotnet publish -c Release -o /app

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "ProductCatalog.WebApi.dll"]
