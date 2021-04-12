using System;
using code_test.common.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace code_test.iOS.Views.Cells
{
    public partial class MenuCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MenuCell");
        public static readonly UINib Nib = UINib.FromName("MenuCell", NSBundle.MainBundle);

        public MenuCell()
        {
            BindView();
        }

        protected MenuCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            BindView();
        }

        void BindView()
        {
            this.DelayBind(() =>
            {
                var bindings = this.CreateBindingSet<MenuCell, MenuItem>();
                bindings.Bind(Title).To(vm => vm.Title);
                bindings.Apply();
            });
        }
    }
}