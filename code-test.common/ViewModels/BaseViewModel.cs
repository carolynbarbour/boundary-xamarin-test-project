using code_test.common.Services;
using MvvmCross;
using MvvmCross.ViewModels;

namespace code_test.common.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected IUsersService UsersService {  get; private set; }
        
        public BaseViewModel(IUsersService usersService)
        {
            this.UsersService = usersService ?? Mvx.IoCProvider.Resolve<IUsersService>();
        }
        
    }
}