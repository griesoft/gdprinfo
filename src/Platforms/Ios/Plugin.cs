using MvvmCross;
using MvvmCross.Plugin;

namespace GdprInfo.Platforms.Ios
{
    [MvxPlugin]
    [Preserve(AllMembers = true)]
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.IoCProvider.RegisterSingleton<IDeviceCountryIdentifier>(DeviceCountryIdentifier.CreateDeviceCountryIdentifier());
            Mvx.IoCProvider.RegisterType<IGdprInfoService, GdprInfoService>();
        }
    }
}
