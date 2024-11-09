# DockerFile AuthService
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Copy csproj and restore as distinct layers
WORKDIR /src/Vopper_Gateway
COPY ["./Vopper_Gateway/Vopper_Gateway.csproj", "."]
RUN dotnet restore "./Vopper_Gateway.csproj"
COPY . .
RUN dotnet build "./Vopper_Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Vopper_Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Vopper_Gateway.dll"]