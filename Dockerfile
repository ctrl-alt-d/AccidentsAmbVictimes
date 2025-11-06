# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar el fitxer del projecte i restaurar dependències
COPY etl/importa/importa.csproj etl/importa/
RUN dotnet restore etl/importa/importa.csproj

# Copiar tot el codi i compilar
COPY etl/importa/ etl/importa/
COPY Data/ Data/
WORKDIR /src/etl/importa
RUN dotnet build importa.csproj -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish importa.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY Data/ Data/

# Esperar que postgres estigui llest abans d'executar
CMD ["dotnet", "importa.dll"]
