using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Samples.ViewModels;

namespace Samples.iOS.Views
{
    [MvxFromStoryboard("main")]
    [MvxRootPresentation]
    public partial class MainView : MvxViewController<MainViewModel>
    {
        public MainView()
        {
        }

        public MainView(IntPtr intPtr) : base(intPtr) { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Bind(isInEea_lbl).To(vm => vm.IsInEea);
            set.Bind(isoCountryCode_lbl).To(vm => vm.CountryISO);
            set.Bind(countryName_lbl).To(vm => vm.CountryName);
            set.Bind(countryNumber_lbl).To(vm => vm.CountryNumber);
            set.Bind(longCountryCode_lbl).To(vm => vm.LongCountryCode);
            set.Apply();
        }
    }
}
