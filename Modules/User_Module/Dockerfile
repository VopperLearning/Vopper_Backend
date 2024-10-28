# DockerFile AuthService
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Copy csproj and restore as distinct layers
WORKDIR /src/User_Module
COPY ["./User_Module.csproj", "."]
RUN dotnet restore "./User_Module.csproj"
COPY . .
RUN dotnet build "./User_Module.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./User_Module.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User_Module.dll"]

