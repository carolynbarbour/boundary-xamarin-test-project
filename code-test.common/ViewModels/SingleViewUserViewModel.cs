using code_test.common.Models;
using code_test.common.Services;

namespace code_test.common.ViewModels
{
    public class SingleViewUserViewModel : BaseViewModel<User> 
    {
        private User _currentUser;

        public SingleViewUserViewModel(IUsersService usersService) : base(usersService)
        {
        }
        
        public override void Prepare(User parameter)
        {
            CurrentUser = parameter;
        }

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                RaisePropertyChanged(() => CurrentUser);
            }
        }
    }
}