FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SistemaSocios.WebApi.MySqlN/SistemaSocios.WebApi.MySqlN.csproj", "SistemaSocios.WebApi.MySqlN/"]
RUN dotnet restore "./SistemaSocios.WebApi.MySqlN/SistemaSocios.WebApi.MySqlN.csproj"
COPY . .
WORKDIR "/src/SistemaSocios.WebApi.MySqlN"
RUN /usr/bin/dotnet build "./SistemaSocios.WebApi.MySqlN.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN /usr/bin/dotnet publish "./SistemaSocios.WebApi.MySqlN.csproj" -c $BUILD_CONFIGURATION -o /app/publish --no-restore
