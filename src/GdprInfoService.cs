using System.Globalization;

namespace GdprInfo
{
    /// <summary>
    /// Provides information about whether the current device is in the European Economic Area (EEA) or not. 
    /// If it is, the app should ask for user consent if personal information is collected and 
    /// processed by the app or other third party apps to comply with the GDPR regulation.
    /// </summary>
    public sealed class GdprInfoService : IGdprInfoService
    {
        private readonly IDeviceCountryIdentifier _countryDeviceIdentifier;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="countryDeviceIdentifier"></param>
        public GdprInfoService(IDeviceCountryIdentifier countryDeviceIdentifier)
        {
            _countryDeviceIdentifier = countryDeviceIdentifier;
        }

        /// <inheritdoc />
        public bool IsDeviceInEeaOrUnknow
        {
            get
            {
                var currentCountryCode = _countryDeviceIdentifier.TryGetDeviceCountryCode();

                // If null, country code was not found
                if (string.IsNullOrEmpty(currentCountryCode))
                {
                    return true;
                }

                // If any match is found, request location is in EEA
                return GdprCountries.IsoCountryCodes.Any(code => code.ToUpper(CultureInfo.InvariantCulture) == currentCountryCode);
            }
        }

        /// <inheritdoc />
        public string? IsoCountryCode => _countryDeviceIdentifier.TryGetDeviceCountryCode();

        /// <inheritdoc />
        public string? CountryName => GdprCountries.Countries.SingleOrDefault(country => country.IsoCountryCode == IsoCountryCode)?.Name;

        /// <inheritdoc />
        public string? CountryNumber => GdprCountries.Countries.SingleOrDefault(country => country.IsoCountryCode == IsoCountryCode)?.Number;

        /// <inheritdoc />
        public string? LongCountryCode => GdprCountries.Countries.SingleOrDefault(country => country.IsoCountryCode == IsoCountryCode)?.LongCountryCode;
    }
}
