using code_test.common.ViewModels;
using code_test.iOS.Views.Base;
using MvvmCross.Plugin.Sidebar;

namespace code_test.iOS.Views
{
    [MvxSidebarPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true, MvxSplitViewBehaviour.Master)]
    public partial class MainViewController : BaseMenuViewController<MainViewModel>
    {
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            ViewModel.ShowUsersViewModelCommand.Execute();
        }
    }
}