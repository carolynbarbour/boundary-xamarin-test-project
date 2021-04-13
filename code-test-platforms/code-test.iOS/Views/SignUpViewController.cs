using System;
using code_test.common.ViewModels;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace code_test.iOS.Views
{
    [MvxChildPresentation]
    public partial class SignUpViewController : MvxViewController<SignUpViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            var set = CreateBindingSet();
            set.Bind(FirstNameLabel).To(vm => vm.FirstName);
            set.Bind(SecondNameLabel).To(vm => vm.SecondName);
            set.Bind(UsernameLabel).To(vm => vm.Username);
            set.Bind(EmailAddressLabel).To(vm => vm.EmailAddress);
            set.Bind(PasswordLabel).To(vm => vm.Password);
            set.Bind(SignUpButton).To(vm => vm.SignUpCommand);
            set.Apply();
        }
    }
}