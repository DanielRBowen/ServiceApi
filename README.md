# ServiceApi
A windows service with web api and signalr capabilities which need to access a COM object and run as x86. This is just an abstract simple example extracted from an actual project.

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

Publish as SelfContained win-x86 app isn't working correctly because on running it with the console argument will give this error:
```
C:\Daniel\Source\Repos\ServiceApi\ServiceApi\bin\Release\netcoreapp3.1\win-x86\publish>ServiceApi --console
Error:
  An assembly specified in the application dependencies manifest (ServiceApi.deps.json) was not found:
    package: 'Interop.Microsoft.Office.Core', version: '2.8.0.0'
    path: 'Interop.Microsoft.Office.Core.dll'
```
