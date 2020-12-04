# Device Gateway Service

This example implements the library [RohdeSchwarz.Iot.Middleware.Gateway](../../../src/Middleware.Gateway/README.md) and provides a graphical web interface to configure the gateway.

## Build and run this example

### Via Docker
Run the following commands in this directory:
```
docker build -t rohdeschwarz/iotgateway:X.X.X .
```

To run the generated image execute the following command:
```
docker container run --name gateway -p 5000:80 rohdeschwarz/iotgateway:X.X.X
```

### Via .NET CLI
To build this project run the following commands in this directory:
```
dotnet restore
dotnet build -c Release
```

To run the build artifact execute the following command (change the backslashes to slashes on an UNIX system):
```
dotnet .\bin\Release\netcoreapp3.1\DeviceGatewayService.dll
```