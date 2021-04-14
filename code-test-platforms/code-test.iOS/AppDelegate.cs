using code_test.common;
using code_test.common.Services;
using code_test.iOS.Platform;
using Foundation;
using MvvmCross;
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
            Mvx.IoCProvider.RegisterSingleton<ISecureStorageFacade>(new IOSSecureStorageImpl());
            return new MvxSidebarPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
        }
    }
}