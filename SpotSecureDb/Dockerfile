FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SpotSecureDB.csproj", "./"]
RUN dotnet restore "SpotSecureDB.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "SpotSecureDB.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpotSecureDB.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpotSecureDB.dll"]
