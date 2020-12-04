FROM fschuetze/aspnet-rsvisa:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./DeviceGatewayService.csproj", "DeviceGatewayService/"]
RUN dotnet restore "DeviceGatewayService/DeviceGatewayService.csproj"
COPY [".", "DeviceGatewayService/"]
WORKDIR "/src/DeviceGatewayService"
RUN dotnet build "DeviceGatewayService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeviceGatewayService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeviceGatewayService.dll", "withoutOpenUrl"]