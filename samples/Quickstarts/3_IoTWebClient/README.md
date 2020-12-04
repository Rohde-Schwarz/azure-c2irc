# IoT Web Client

This example implements the library [RohdeSchwarz.Iot.Middleware.IotClient](../../../src/Middleware.IotClient/README.md) and provides a web interface to test remote control commands for devices connected to the gateway.

## Configure this example
to connect to the gateway via the hub the following two constants must be replaced in the file **Controllers/HomeController.cs**:

- `IOT_HUB_CONNECTION_STRING` e.g. "HostName=..."
- `GATEWAY_DEVICE_ID` e.g. "qa-gateway1"

## Run this example with .NET CLI

To run this project execute the following commands in this directory:
```
dotnet restore
dotnet run
```

## Run this example with Docker

Run the following commands in this directory:
```
docker build -t iotcommandlineclient .
```

To run the generated image execute the following command:
```
docker container run --name gateway -p 5000:80 iotcommandlineclient
```