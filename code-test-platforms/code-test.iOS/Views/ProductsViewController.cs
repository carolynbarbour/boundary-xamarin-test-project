using code_test.common.ViewModels;
using code_test.iOS.Views.Base;
using code_test.iOS.Views.Cells;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Plugin.Sidebar;

namespace code_test.iOS.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PushPanel, false)]
    public partial class ProductsViewController : BaseMenuViewController<ProductsViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.Title = "Products";

            var source = new MvxSimpleTableViewSource(TableView, ProductCell.Key, ProductCell.Key);
            TableView.Source = source;
        }
    }
}