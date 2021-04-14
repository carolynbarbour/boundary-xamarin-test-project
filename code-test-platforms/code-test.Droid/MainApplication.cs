using System;
using Android.App;
using Android.Runtime;
using code_test.common;
using code_test.common.Services;
using code_test.Droid.Platform;
using MvvmCross;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.ViewModels;

namespace code_test.Droid
{
    [Application(Theme = "@style/AppTheme")]
    public class MainApplication : MvxAndroidApplication
    {
        public MainApplication() : base()
        {
        }

        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }

    public class Setup : MvxAndroidSetup
    {
        protected override IMvxApplication CreateApp() {
        
            var app = new CodeTestApp();
            
            Mvx.IoCProvider.RegisterSingleton<ISecureStorageFacade>(new DroidSecureStorageImpl());

            return app;
        }
    }
}