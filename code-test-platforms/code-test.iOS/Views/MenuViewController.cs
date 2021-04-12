using code_test.common.ViewModels;
using code_test.iOS.Views.Base;
using code_test.iOS.Views.Cells;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Plugin.Sidebar;

namespace code_test.iOS.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Left, MvxPanelHintType.PushPanel, false)]
    public partial class MenuViewController : BaseViewController<MenuViewModel> 
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var source = new MvxSimpleTableViewSource(TableView, MenuCell.Key, MenuCell.Key);
            TableView.Source = source;

            var set = CreateBindingSet();
            set.Bind(source).For(v => v.ItemsSource).To(vm => vm.MenuItems);
            set.Bind(source).For(v => v.SelectionChangedCommand).To(vm => vm.SelectMenuItemCommand);
            set.Apply();
        }
    }
}