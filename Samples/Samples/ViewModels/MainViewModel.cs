using GdprInfo;
using MvvmCross;
using MvvmCross.ViewModels;

namespace Samples.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel(IGdprInfoService gdprInfoService)
        {
            GdprInfoService = gdprInfoService;
        }

        public IGdprInfoService GdprInfoService { get; }

        public string IsInEea => GdprInfoService.IsDeviceInEeaOrUnknow ? "Yes" : "No";

        public string CountryISO => GdprInfoService?.IsoCountryCode ?? "Not found";

        public string CountryName => GdprInfoService?.CountryName ?? "Not found";

        public string CountryNumber => GdprInfoService?.CountryNumber ?? "Not found";

        public string LongCountryCode => GdprInfoService.LongCountryCode ?? "Not found";
    }
}
