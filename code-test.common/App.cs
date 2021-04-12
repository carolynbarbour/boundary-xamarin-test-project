using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace code_test.common
{
    public class CodeTestApp : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            
            RegisterAppStart<ViewModels.MainViewModel>();
        }
    }
}