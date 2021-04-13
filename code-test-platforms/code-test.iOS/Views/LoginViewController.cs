using System;
using code_test.common.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace code_test.iOS.Views
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class LoginViewController : MvxViewController<LoginViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var set = CreateBindingSet();
            set.Bind(UsernameLabel).To(vm => vm.Username);
            set.Bind(PasswordLabel).To(vm => vm.Password);
            set.Bind(LogInButton).To(vm => vm.LoginCommand);
            set.Bind(SignUpButton).To(vm => vm.SignUpCommand);
            set.Apply();
        }

    }
}