using System.Collections.ObjectModel;
using System.Threading.Tasks;
using code_test.common.Models;
using code_test.common.Services;
using MvvmCross;
using MvvmCross.ViewModels;

namespace code_test.common.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public UsersViewModel(IUsersService usersService) : base(usersService)
        {
            System.Diagnostics.Debug.WriteLine("CTor...");
            
            Users = new ObservableCollection<User>
            {
                new User(1, "Peter", "Lockett", "peter@boundary.co.uk"),
                new User(2, "Paul", "Walton", "paul@boundary.co.uk")
            };
        }

        public override void Prepare()
        {
            base.Prepare();
            
            System.Diagnostics.Debug.WriteLine("Preparing...");
        }
    }
}