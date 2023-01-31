using System.Globalization;
using CoreTelephony;
using Foundation;

namespace GdprInfo.Platforms.iOS
{
    /// <summary>
    /// This has the simple function of obtaining the country code of the current device that we are running on.
    /// </summary>
    public sealed class DeviceCountryIdentifier : IDeviceCountryIdentifier
    {
        private readonly CTTelephonyNetworkInfo _telephonyManager;

        private DeviceCountryIdentifier()
        {
            _telephonyManager = new CTTelephonyNetworkInfo();
        }

        internal static DeviceCountryIdentifier CreateDeviceCountryIdentifier()
        {
            return new DeviceCountryIdentifier();
        }

        /// <inheritdoc />
        public string? TryGetDeviceCountryCode()
        {
            if (!TryGetSimBasedCountryCode(out string? code))
            {
                // Couldn't receive the country code from SIM.

                _ = TryGetLocalCountryCode(out code);
            }

            return string.IsNullOrEmpty(code) ? null : code!.ToUpper(CultureInfo.InvariantCulture);
        }

        private bool TryGetSimBasedCountryCode(out string? code)
        {
            return !string.IsNullOrEmpty(code = _telephonyManager.SubscriberCellularProvider?.IsoCountryCode);
        }

        private bool TryGetLocalCountryCode(out string code)
        {
            return !string.IsNullOrEmpty(code = NSLocale.CurrentLocale.CountryCode);
        }
    }
}
