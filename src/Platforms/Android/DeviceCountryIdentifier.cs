﻿using System.Globalization;
using Android.Telephony;

namespace GdprInfo.Platforms.Android
{
    public sealed class DeviceCountryIdentifier : IDeviceCountryIdentifier
    {
        private readonly TelephonyManager? _telephonyManager;

        private DeviceCountryIdentifier()
        {
            _telephonyManager = TelephonyManager.FromContext(global::Android.App.Application.Context);
        }

        internal static DeviceCountryIdentifier CreateDeviceCountryIdentifier()
        {
            return new DeviceCountryIdentifier();
        }

        /// <inheritdoc />
        public string? TryGetDeviceCountryCode()
        {
            if (!TryGetNetworkBasedCountryCode(out string? code))
            {
                if (!TryGetSimBasedCountryCode(out code))
                {
                    _ = TryGetLocalCountryCode(out code);
                }
            }

            return string.IsNullOrEmpty(code) ? null : code.ToUpper(CultureInfo.InvariantCulture);
        }

        private bool TryGetNetworkBasedCountryCode(out string? code)
        {
            if ((_telephonyManager?.PhoneType ?? PhoneType.None) == PhoneType.Gsm)
            {
                return !string.IsNullOrEmpty(code = _telephonyManager?.NetworkCountryIso);
            }

            code = "";
            return false;
        }

        private bool TryGetSimBasedCountryCode(out string? code)
        {
            return !string.IsNullOrEmpty(code = _telephonyManager?.SimCountryIso);
        }

        private bool TryGetLocalCountryCode(out string code)
        {
            return !string.IsNullOrEmpty(code = Java.Util.Locale.Default.Country);
        }
    }
}
