using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace code_test.common.ViewModels
{
    public class LandingPageViewModel : MvxViewModel
    {
        public IMvxCommand ShowUsersCommand { get; private set; }

        private IMvxNavigationService _navigationService;

        public LandingPageViewModel(IMvxNavigationService mvxNavigationService)
        {
            _navigationService = mvxNavigationService ?? Mvx.IoCProvider.Resolve<IMvxNavigationService>();
            
            SetupCommands();
        }

        private void SetupCommands()
        {
            ShowUsersCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<UsersViewModel>());
        }
        
    }
}