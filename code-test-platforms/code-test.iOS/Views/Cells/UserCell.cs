using System;
using code_test.common.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace code_test.iOS.Views.Cells
{
    public partial class UserCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("UserCell");
        public static readonly UINib Nib = UINib.FromName("UserCell", NSBundle.MainBundle);

        public UserCell()
        {
            BindView();
        }

        protected UserCell(IntPtr handle) : base(handle)
        {
            BindView();
        }

        void BindView()
        {
            this.DelayBind(() =>
            {
                var bindings = this.CreateBindingSet<UserCell, User>();
                bindings.Bind(NameLabel).To(vm => vm.DisplayName);
                bindings.Apply();
            });
        }
    }
}
