using System.Threading.Tasks;
using MvvmCross.Commands;

namespace code_test.common.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
            LoginCommand = new MvxAsyncCommand(OnLoginCommandExecute);
            SignUpCommand = new MvxAsyncCommand(OnSignUpCommandExecute);
        }

        private string _username;
        public string Username { get => _username; set => SetProperty(ref _username, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public IMvxAsyncCommand LoginCommand { get; }
        public IMvxAsyncCommand SignUpCommand { get; }

        private async Task OnLoginCommandExecute()
        {
            //Authenticate 
            var successful = true;

            if (successful)
            {
                await NavigationService.Navigate<MainViewModel>();
            }
        }

        private async Task OnSignUpCommandExecute()
        {
            await NavigationService.Navigate<SignUpViewModel>();
        }
    }
}
