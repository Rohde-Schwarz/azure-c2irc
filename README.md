# Azure C2IRC

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

## License

The all code in this repository is licensed under the GPL-3.0 license. For more information see LICENSE.

Copyright © 2020-present Rohde &amp; Schwarz GmbH &amp; Co. KG. All rights reserved.