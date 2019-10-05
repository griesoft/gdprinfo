using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Samples.ViewModels;

namespace Samples
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
