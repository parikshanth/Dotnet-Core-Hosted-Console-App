
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HostedConsoleApp.csproj", "HostedConsoleApp/"]
RUN dotnet restore "HostedConsoleApp/HostedConsoleApp.csproj"
WORKDIR "/src/HostedConsoleApp"
COPY . .
RUN dotnet build "HostedConsoleApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HostedConsoleApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HostedConsoleApp.dll"]