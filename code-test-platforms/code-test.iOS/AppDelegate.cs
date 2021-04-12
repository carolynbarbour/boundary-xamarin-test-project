using code_test.common;
using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Plugin.Sidebar;
using UIKit;

namespace code_test.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, CodeTestApp>
    {
        [Export("window")]
        public UIWindow Window { get; set; }
    }

    public class Setup: MvxIosSetup<CodeTestApp>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            return new MvxSidebarPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
        }
    }
}