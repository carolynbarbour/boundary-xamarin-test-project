using Android;
using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace code_test.Droid
{
    [MvxActivityPresentation]
    [Activity(
        MainLauncher = true,
        Icon = "@mipmap/icon",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.Splashscreen)
        {
        }
    }
}