using System;
using System.Threading.Tasks;
using code_test.common.Services;
using code_test.common.Services.AuthService;
using MvvmCross;
using MvvmCross.Commands;
using Xamarin.Essentials;

namespace code_test.common.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private IAuthService _authService;
        private ISecureStorageFacade _secureStorageFacade;
        
        public LoginViewModel(IAuthService authService = null, ISecureStorageFacade secureStorageFacade = null)
        {
            _authService = authService ?? Mvx.IoCProvider.Resolve<IAuthService>();
            _secureStorageFacade = secureStorageFacade ?? Mvx.IoCProvider.Resolve<ISecureStorageFacade>();
            
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
            try
            {
                // Get AuthToken?
                var authResponse = await _authService.Login(Username, Password);

                await _secureStorageFacade.SetKeyValue("auth_token", authResponse.AccessToken);
                
                
                await NavigationService.Navigate<MainViewModel>();
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("There was a problem logging in!");
                throw;
            }
        }

        private async Task OnSignUpCommandExecute()
        {
            await NavigationService.Navigate<SignUpViewModel>();
        }
    }
}
