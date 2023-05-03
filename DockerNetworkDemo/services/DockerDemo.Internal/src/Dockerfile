#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
COPY ["libraries/DockerDemo.Shared/", "libraries/DockerDemo.Shared/"]
WORKDIR /src
COPY ["services/DockerDemo.Internal/src/DockerDemo.Internal.csproj", "services/DockerDemo.Internal/src/"]
RUN dotnet restore "services/DockerDemo.Internal/src/DockerDemo.Internal.csproj"
COPY . .
WORKDIR "/src/services/DockerDemo.Internal/src"
RUN dotnet build "DockerDemo.Internal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerDemo.Internal.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerDemo.Internal.dll"]