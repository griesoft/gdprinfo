# GdprInfo

A .NET MAUI package for Android and iOS with the main purpose of detecting if the current device is in the EEA, which would make it subject to the GDPR regulation. 

[![Build Status](https://dev.azure.com/griesingersoftware/GDPRInfo%20Plugin/_apis/build/status/GdprInfo%20CI%20Pipeline?branchName=master)](https://dev.azure.com/griesingersoftware/GDPRInfo%20Plugin/_build/latest?definitionId=11&branchName=master)
[![NuGet](https://badgen.net/nuget/v/GdprInfo)](https://www.nuget.org/packages/GdprInfo)
[![GitHub Release](https://badgen.net/github/release/griesoft/gdprinfo)](https://github.com/griesoft/gdprinfo/releases)

## Installation

Install via [NuGet](https://www.nuget.org/packages/GdprInfo/) using:

``PM> Install-Package GdprInfo``

## Usage

### Registration
Register the service in your `MauiProgram` file.

```csharp
using GdprInfo;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            // Other services before...
            .ConfigureGdprInfo()
            // Other service after...
            ;

        return builder.Build();
    }
}
```

### Consumption:

Inject the service via dependency injection in the constructor of the depending class.

```csharp
private readonly IGdprInfoService _gdprInfoService;

public MyConstructor(IGdprInfoService gdprInfoService)
{
    _gdprInfoService = gdprInfoService;
}
```

Check if device is in European Economic Area (EEA):

```csharp
bool result = _gdprInfoService.IsDeviceInEeaOrUnknow;
```

You can also get the ISO country code of the current device
```csharp
string? isoCode = _gdprInfoService.IsoCountryCode;
```
If the ISO code is not null and is part of the EEA, you can also get additional information about the country like this:
```csharp
string? countryName = _gdprInfoService.CountryName;
string? countryNumber = _gdprInfoService.CountryNumber;
string? longCountryCode = _gdprInfoService.LongCountryCode;
```

## How does it work

The service first tries to get the ISO country code via the device telemetry data i.e. network and SIM provider information. If we can't get it from there we look it up from the device's current local setting. Reasons for why we couldn't receive it from telemetry data could be for example that the device is in Flight Mode or that the device has no SIM card inserted at all.

In case that we couldn't receive the ISO code (unknown), we always have to assume that the device owner is in the EEA. So if the ISO code is unknown, ``IsDeviceInEeaOrUnknow`` will return ``true``.

## Project State

The project is kind of archived. I do occasional updates as I require them for personal use, but to be honest, in the mean time there are much better ways of doing what this package was trying to do.
