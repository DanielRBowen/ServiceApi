# ServiceApi
A windows service with web api and signalr capabilities which need to access a COM object and run as x86.

Uses some bits of code from [here](https://www.stevejgordon.co.uk/running-net-core-generic-host-applications-as-a-windows-service) 

To run 32 bit COM objects you need to run it OutOfProcess to get it to work
So in the csproj file you need a property group similar to this.
```
<PropertyGroup>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <AspNetCoreHostingModel>OutOfProcess</AspNetCoreHostingModel>
    <RuntimeIdentifier>win-x86</RuntimeIdentifier>
  </PropertyGroup>
```

Also probably want to set EmbedInteropTypes to true and Private to true for the COM object.
