using code_test.common.ViewModels;
using code_test.iOS.Views.Base;
using MvvmCross.Plugin.Sidebar;

namespace code_test.iOS.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.PopToRoot, false)]
    public partial class SingleUserViewController : BaseViewController<SingleViewUserViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            NavigationItem.Title = "Single User";

            var set = CreateBindingSet();
            set.Bind(UserNameLabel).To(vm => vm.CurrentUser.DisplayName);
            set.Apply();
        }  
    }
}