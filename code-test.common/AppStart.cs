using System;
using System.Threading.Tasks;
using code_test.common.ViewModels;
using MvvmCross.Exceptions;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace code_test.common
{
    public class CustomAppStart : MvxAppStart
    {
        public CustomAppStart(IMvxApplication mvxApplication, IMvxNavigationService navigationService) : base(mvxApplication, navigationService)
        {
            
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            try
            {
                return NavigationService.Navigate<MainViewModel>();
            }
            catch (Exception exception)
            {
                throw exception.MvxWrap("Problem Navigation to ViewModel");
            }
        }
    }
}