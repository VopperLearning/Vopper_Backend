# DockerFile AuthService
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
# Copy csproj and restore as distinct layers
WORKDIR /src/Auth_Module
COPY ["./Modules/Auth_Module/Auth_Module.csproj", "."]
RUN dotnet restore "./Auth_Module.csproj"
COPY . .
RUN dotnet build "./Auth_Module.csproj" -c Release -o /app/Auth_Module/build


FROM build AS publish
RUN dotnet publish "./Auth_Module.csproj" -c Release -o /app/Auth_Module/publish

FROM build AS final
WORKDIR /src/Auth_Module
COPY --from=publish /app/publish .
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"
ENTRYPOINT ["sh", "-c", "dotnet ef database update && dotnet Auth_Module.dll"]


