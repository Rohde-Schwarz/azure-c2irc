# Azure Cloud to Instrument Remote Control
This repository provides the middleware components for the architecture described in application note [Cloud to Instrument Remote Control - A simple concept with Azure Iot](https://www.rohde-schwarz.com/appnote/GFM319).

## Libraries

The solution contains three library projects, which are deployed to NuGet. More information about the projects can be found in the corresponding README in the project folder.

- [RohdeSchwarz.Iot.Middleware.Model](src/Middleware.Model/README.md)
- [RohdeSchwarz.Iot.Middleware.Gateway](src/Middleware.Gateway/README.md)
- [RohdeSchwarz.Iot.Middleware.IotClient](src/Middleware.IotClient/README.md)

### Requirements
To build any project you will need the [.NET Core SDK](https://dotnet.microsoft.com/download).

### Build the libraries

Run the following commands in this directory:
```
dotnet restore
dotnet build -c Release
```

## Examples
The solution also contains examples of how to use the libraries. More information about the projects can be found in the corresponding README in the project folder.

- [DeviceGatewayService](samples/Quickstarts/1_DeviceGatewayService/README.md): Service with graphical web interface to configure the gateway.
- [IotCommandLineClient](samples/Quickstarts/2_IotCommandLineClient/README.md): Remote control client example to execute an `*IDN?` request.
- [IotWebClient](samples/Quickstarts/3_IoTWebClient/README.md): Remote control web client to execute different commands to different instruments.

## License

The all code in this repository is licensed under the GPL-3.0 license. For more information see LICENSE.

Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.