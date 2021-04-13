using System.Threading.Tasks;
using MvvmCross.Commands;

namespace code_test.common.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
        {
            SignUpCommand = new MvxAsyncCommand(OnSignUpCommandExecute);
        }

        private string _firstName;
        public string FirstName { get => _firstName; set => SetProperty(ref _firstName, value); }

        private string _secondName;
        public string SecondName { get => _secondName; set => SetProperty(ref _secondName, value); }

        private string _username;
        public string Username { get => _username; set => SetProperty(ref _username, value); }

        private string _emailAddress;
        public string EmailAddress { get => _emailAddress; set => SetProperty(ref _emailAddress, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        public IMvxAsyncCommand SignUpCommand { get; }

        private async Task OnSignUpCommandExecute()
        {
            // Sign up
            var successful = true;
            if (successful)
            {
                await NavigationService.Navigate<MainViewModel>();
            }
        }
    }
}
