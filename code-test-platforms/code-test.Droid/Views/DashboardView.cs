using System.Reflection.Emit;
using Android.App;
using Android.OS;
using code_test.common.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace code_test.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Code Test Dashboard", MainLauncher = true)]
    public class DashboardView : MvxAppCompatActivity<DashboardViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DashboardView);
        }
    }
}