# GdprInfo
A cross platform Xamarin MvvmCross plugin, with the main purpose of detecting if the current device is in the EEA, which would make it subject to the GDPR regulation. 

## Installation

Install via [NuGet](https://www.nuget.org/packages/) using:

``PM> Install-Package ``

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

The plugin first tries to get the ISO country code via the device telemetry data i.e. network and sim provider information. If we can't get it from there we look it up from the device's current local setting. Reasons for why we couldn't receive it from telemetry data could be for example that the device is in Flight Mode or that the device has no sim card insertd at all.

In case that we couldn't receive ISO code (unknown), we always have to assume that the device owner is in the EEA. So if the ISO code is unknown, ``IsDeviceInEeaOrUnknow`` will return ``true``.

## Future Plans

I had thoughts about adding features like user consent storaging and pre-made dialogs for asking the user for consent. This dialogs would need to be modifiable ofc. Also an option for looking up local information from GPS if not found by telemetry data would be nice. This would be optional, because it requires location permission.

But it depends on my time and ofc also on public intrest. It could be even a better solution to create just a plugin on it's own for some of the features mentioned above.

## Contribution

Everyone is welcome to contribute to the project, but please contact @jooni91 first before starting the development of a new feature. Also in terms of bug fixes it would be good to open a issue first.
