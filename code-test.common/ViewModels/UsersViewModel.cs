using System;
using System.Threading.Tasks;
using code_test.common.Models;
using code_test.common.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace code_test.common.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private MvxObservableCollection<User> _users;

        public UsersViewModel(IUsersService usersService) : base(usersService)
        {
            UserSelectedCommand = new MvxAsyncCommand<User>(OnUserSelected);
        }

        public MvxObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }
        
        public IMvxCommand<User> UserSelectedCommand { get; }
        
        public override async Task Initialize()
        {
            var usersCollection = new MvxObservableCollection<User>();
            
            try
            {
                var result = await UsersService.GetAllUsers();

                usersCollection = new MvxObservableCollection<User>(result);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("Exception retrieving users");
                System.Diagnostics.Debug.WriteLine(exception.StackTrace);
                throw;
            }

            Users = usersCollection;
        }

        private async Task OnUserSelected(User selectedUser)
        {
            var result = await NavigationService.Navigate<SingleViewUserViewModel, User>(selectedUser);

            if (!result)
            {
                System.Diagnostics.Debug.WriteLine("Error occured");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Worked just fine.");
            }
        }
    }
}