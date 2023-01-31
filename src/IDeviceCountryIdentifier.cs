namespace GdprInfo
{
    /// <summary>
    /// The purpose of this interface is to be able to fetch the ISO country code of the current device.
    /// Network and Sim data should be always prioritized if available.
    /// </summary>
    public interface IDeviceCountryIdentifier
    {
        /// <summary>
        /// Try to get the ISO uppercase country code of the current device.
        /// </summary>
        /// <returns>ISO uppercase country code or null if not found.</returns>
        string? TryGetDeviceCountryCode();
    }
}
