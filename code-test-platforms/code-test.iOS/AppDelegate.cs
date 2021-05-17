using code_test.common;
using code_test.common.Services;
using code_test.iOS.Platform;
using Foundation;
using MvvmCross;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Platforms.Ios.Presenters;
using MvvmCross.Plugin.Sidebar;
using UIKit;
//using InstabugLib;

namespace code_test.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate<Setup, CodeTestApp>
    {
        [Export("window")]
        public UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            InitialiseInstabug();

            return base.FinishedLaunching(application, launchOptions);
        }

        void InitialiseInstabug()
        {
            var instabugId = "c801f0d3fcaeba7e6c5de494efd23343";

            //Instabug.StartWithToken(instabugId, IBGInvocationEvent.Shake);
            //Instabug.StartWithToken(instabugId, IBGInvocationEvent.FloatingButton);
            //Instabug.StartWithToken(instabugId, IBGInvocationEvent.Shake);
        }
    }

    public class Setup : MvxIosSetup<CodeTestApp>
    {
        protected override IMvxIosViewPresenter CreateViewPresenter()
        {
            Mvx.IoCProvider.RegisterSingleton<ISecureStorageFacade>(new IOSSecureStorageImpl());
            return new MvxSidebarPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
        }
    }
}