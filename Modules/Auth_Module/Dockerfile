# DockerFile AuthService
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Copy csproj and restore as distinct layers
WORKDIR /src/Auth_Module
COPY ["./Auth_Module.csproj", "."]
RUN dotnet restore "./Auth_Module.csproj"
COPY . .
RUN dotnet build "./Auth_Module.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Auth_Module.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth_Module.dll"]

