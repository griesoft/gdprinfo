using System.Globalization;
using CoreTelephony;
using Foundation;
using MvvmCross;
using MvvmCross.Logging;

namespace GdprInfo.Platforms.Ios
{
    /// <summary>
    /// This has the simple function of optaining the country code of the current device that we are running on.
    /// </summary>
    public sealed class DeviceCountryIdentifier : IDeviceCountryIdentifier
    {
        private readonly IMvxLog _log;
        private readonly CTTelephonyNetworkInfo _telephonyManager;

        private DeviceCountryIdentifier(IMvxLogProvider mvxLogProvider)
        {
            _log = mvxLogProvider.GetLogFor<DeviceCountryIdentifier>();
            _telephonyManager = new CTTelephonyNetworkInfo();

            _log.Debug(_telephonyManager == null ? $"{nameof(CTTelephonyNetworkInfo)} is null" : $"{nameof(CTTelephonyNetworkInfo)} is not null");
        }

        internal static DeviceCountryIdentifier CreateDeviceCountryIdentifier()
        {
            var log = Mvx.IoCProvider.Resolve<IMvxLogProvider>();
            return new DeviceCountryIdentifier(log);
        }

        /// <inheritdoc />
        public string? TryGetDeviceCountryCode()
        {
            if (!TryGetSimBasedCountryCode(out string? code))
            {
                _log.Debug("Couldn't receive the country code from sim.");

                _ = TryGetLocalCountryCode(out code);

                _log.Debug($"Local country code is: {code}");
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
