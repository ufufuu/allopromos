#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/allopromo.Api/allopromo.Api.csproj", "src/allopromo.Api/"]
COPY ["src/allopromo.Core/allopromo.Core.csproj", "src/allopromo.Core/"]
COPY ["src/allopromo.Infrastructure/allopromo.Infrastructure.csproj", "src/allopromo.Infrastructure/"]
COPY ["src/allopromo.Domain/allopromo.Domain.csproj", "src/allopromo.Domain/"]
RUN dotnet restore "src/allopromo.Api/allopromo.Api.csproj"
COPY . .
WORKDIR "/src/src/allopromo.Api"
RUN dotnet build "allopromo.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "allopromo.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "allopromo.Api.dll"]
