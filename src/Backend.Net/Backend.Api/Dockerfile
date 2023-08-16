#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
ARG ENV_ARG=Production
ENV ASPNETCORE_ENVIRONMENT=$ENV_ARG
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /Backend.Net
COPY ["src/Backend.Net/Backend.Api/Backend.Api.csproj", "Backend.Api/"]
COPY ["src/Backend.Net/Backend.Application/Backend.Application.csproj", "Backend.Application/"]
COPY ["src/Backend.Net/Backend.Domain/Backend.Domain.csproj", "Backend.Domain/"]
COPY ["src/Backend.Net/Backend.Infra/Backend.Infra.csproj", "Backend.Infra/"]
COPY ["src/Backend.Net/Backend.CrossCutting/Backend.CrossCutting.csproj", "Backend.CrossCutting/"]
COPY ["src/Backend.Net/Backend.Ioc/Backend.Ioc.csproj", "Backend.Ioc/"]
COPY ["src/Backend.Net/databases/pokedex.db", "databases/"]

RUN dotnet restore "Backend.Api/Backend.Api.csproj"
COPY . .
WORKDIR "src/Backend.Net/Backend.Api"
RUN dotnet build "Backend.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Backend.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Backend.Api.dll"]