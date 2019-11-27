using code_test.common.Services;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Navigation;

namespace code_test.common.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(IUsersService usersService) : base(usersService)
        {
            var navService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();

            navService.Navigate<UsersViewModel>();
        }
    }
}