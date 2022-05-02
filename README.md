# GdprInfo

A cross platform Xamarin MvvmCross plugin, with the main purpose of detecting if the current device is in the EEA, which would make it subject to the GDPR regulation. 

[![Build Status](https://dev.azure.com/griesingersoftware/GDPRInfo%20Plugin/_apis/build/status/GdprInfo%20CI?branchName=master)](https://dev.azure.com/griesingersoftware/GDPRInfo%20Plugin/_build/latest?definitionId=34&branchName=master)
[![NuGet](https://badgen.net/nuget/v/GdprInfo)](https://www.nuget.org/packages/GdprInfo)
[![GitHub Release](https://badgen.net/github/release/griesoft/gdprinfo)](https://github.com/griesoft/gdprinfo/releases)

## Installation

Install via [NuGet](https://www.nuget.org/packages/GdprInfo/) using:

``PM> Install-Package GdprInfo``

## Usage

Resolve it:

``var gdprInfoService = Mvx.Resolve<IGdprInfoService>();``

**OR**

Use Dependency Injection:

```
private readonly IGdprInfoService _gdprInfoService;

public MyConstructor(IGdprInfoService gdprInfoService)
{
    _gdprInfoService = gdprInfoService;
}
```

**AND**

Check if device is in European Economic Area (EEA):

```
bool result = _gdprInfoService.IsDeviceInEeaOrUnknow;
```

You can also get the ISO country code of the current device
```
string? isoCode = _gdprInfoService.IsoCountryCode;
```
If the ISO code is not null and is part of the EEA, you can also get additional information about the country like this:
```
string? countryName = _gdprInfoService.CountryName;
string? countryNumber = _gdprInfoService.CountryNumber;
string? longCountryCode = _gdprInfoService.LongCountryCode;
```

## How does it work

The plugin first tries to get the ISO country code via the device telemetry data i.e. network and sim provider information. If we can't get it from there we look it up from the device's current local setting. Reasons for why we couldn't receive it from telemetry data could be for example that the device is in Flight Mode or that the device has no sim card inserted at all.

In case that we couldn't receive the ISO code (unknown), we always have to assume that the device owner is in the EEA. So if the ISO code is unknown, ``IsDeviceInEeaOrUnknow`` will return ``true``.

## Future Plans

I had thoughts about adding features like user consent storaging and pre-made dialogs for asking the user for consent. 
Also a feature for looking up ISO county code information from GPS if not found by telemetry data would be nice. This would have to be optional, because it requires location permission and might be suitable only for apps that anyways make use of that permission.

Please give me feedback and ideas on what you think could be improved or would make a good new addition to the project.

## Contribution

Everyone is welcome to contribute to the project. But please contact [@jooni91](https://github.com/jooni91) first, before starting the development of a new feature. Also in terms of bug fixes it would be good to open an issue first.

Adding support for more platforms is very welcome. :wink:
