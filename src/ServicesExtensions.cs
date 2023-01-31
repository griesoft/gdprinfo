#if ANDROID
using GdprInfo.Platforms.Android;
#elif IOS
using GdprInfo.Platforms.iOS;
#endif

namespace GdprInfo
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServicesExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder ConfigureGdprInfo(this MauiAppBuilder builder)
        {
#if ANDROID
            builder.Services.AddSingleton<IDeviceCountryIdentifier>(DeviceCountryIdentifier.CreateDeviceCountryIdentifier());
#elif IOS
            builder.Services.AddSingleton<IDeviceCountryIdentifier>(DeviceCountryIdentifier.CreateDeviceCountryIdentifier());
#endif

            builder.Services.AddTransient<IGdprInfoService, GdprInfoService>();

            return builder;
        }
    }
}
