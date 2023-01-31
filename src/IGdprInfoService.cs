namespace GdprInfo
{
    /// <summary>
    /// Service for looking up country information of the current device and if it is in the
    /// European Economic Area / subject to the GDPR regulation or not. 
    /// </summary>
    public interface IGdprInfoService
    {
        /// <summary>
        /// Check if the request location of the current device is in the European Economic Area / EEA or unknown.
        /// </summary>
        /// <remarks>
        /// If the location of the current device is unknown this will return true, because we have 
        /// to assume that the device might be in the European Economic Area.
        /// </remarks>
        bool IsDeviceInEeaOrUnknow { get; }

        /// <summary>
        /// Get the ISO country code of the current device. Null in case that no country information
        /// could be retrieved from the current device for what ever reason.
        /// </summary>
        string? IsoCountryCode { get; }

        /// <summary>
        /// Get the country name of the current device. Null if <see cref="IsoCountryCode"/> is not in EEA.
        /// </summary>
        /// <remarks>
        /// The <see cref="GdprCountries"/> collection only contains detailed information about countries in the EEA.
        /// So in case that <see cref="IsoCountryCode"/> isn't included in the collection, this will return null.
        /// </remarks>
        string? CountryName { get; }

        /// <summary>
        /// Get the country number of the current device. Null if <see cref="IsoCountryCode"/> is not in EEA.
        /// </summary>
        /// <remarks>
        /// The <see cref="GdprCountries"/> collection only contains detailed information about countries in the EEA.
        /// So in case that <see cref="IsoCountryCode"/> isn't included in the collection, this will return null.
        /// </remarks>
        string? CountryNumber { get; }

        /// <summary>
        /// Get the long country code of the current device. Null if <see cref="IsoCountryCode"/> is not in EEA.
        /// </summary>
        /// <remarks>
        /// The <see cref="GdprCountries"/> collection only contains detailed information about countries in the EEA.
        /// So in case that <see cref="IsoCountryCode"/> isn't included in the collection, this will return null.
        /// </remarks>
        string? LongCountryCode { get; }
    }
}
