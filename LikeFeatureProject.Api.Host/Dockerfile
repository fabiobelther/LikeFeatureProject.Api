#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["LikeFeatureProject.Api.Host/LikeFeatureProject.Api.Host.csproj", "LikeFeatureProject.Api.Host/"]
RUN dotnet restore "LikeFeatureProject.Api.Host/LikeFeatureProject.Api.Host.csproj"
COPY . .
WORKDIR "/src/LikeFeatureProject.Api.Host"
RUN dotnet build "LikeFeatureProject.Api.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LikeFeatureProject.Api.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LikeFeatureProject.Api.Host.dll"]