FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./IoTWebClient.csproj", "IoTWebClient/"]
RUN dotnet restore "IoTWebClient/IoTWebClient.csproj"
COPY [".", "IoTWebClient/"]
WORKDIR /src/IoTWebClient
RUN dotnet build "IoTWebClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IoTWebClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IoTWebClient.dll"]