using System.Threading.Tasks;
using MvvmCross.Commands;

namespace code_test.common.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ShowUsersViewModelCommand = new MvxAsyncCommand(OnShowUsersViewModelCommandExecute);
            ShowMenuViewModelCommand = new MvxAsyncCommand(OnShowMenuViewModelCommandExecute);
        }
        
        public IMvxAsyncCommand ShowUsersViewModelCommand { get; }
        public IMvxAsyncCommand ShowMenuViewModelCommand { get; }

        private async Task OnShowUsersViewModelCommandExecute()
        {
            await NavigationService.Navigate<UsersViewModel>();
        }
        
        private async Task OnShowMenuViewModelCommandExecute()
        {
            await NavigationService.Navigate<MenuViewModel>();
        }
    }
}