# IoT Command Line Client

This example implements the library [RohdeSchwarz.Iot.Middleware.IotClient](../../../src/Middleware.IotClient/README.md) and executes an `*IDN?` request on an instrument connected to the gateway.

## Configure this example
to connect to the gateway via the hub the following three constants must be replaced in the file **Program.cs**:

- `IOT_HUB_CONNECTION_STRING` e.g. "HostName=..."
- `GATEWAY_DEVICE_ID` e.g. "qa-gateway1"
- `INSTRUMENT_CONNECTION` e.g. "TCPIP::192.168.0.100::INSTR"


## Run this example

To run this project execute the following commands in this directory:
```
dotnet restore
dotnet run
```