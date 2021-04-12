using System;
using code_test.common.ViewModels;
using code_test.iOS.Views.Base;
using code_test.iOS.Views.Cells;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Plugin.Sidebar;
using UIKit;

namespace code_test.iOS.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, false)]
    public partial class UsersViewController : BaseMenuViewController<UsersViewModel>
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.Title = "Users";

            var source = new MvxSimpleTableViewSource(TableView, UserCell.Key, UserCell.Key);
            TableView.Source = source;

            var set = CreateBindingSet();
            set.Bind(source).For(v => v.ItemsSource).To(vm => vm.Users);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.UserSelectedCommand);
            set.Apply();
        }
    }
}

