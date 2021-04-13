using Android.App;
using Android.Content.PM;
using Android.OS;
using code_test.common.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace code_test.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Code Test", Theme = "@style/AppTheme", LaunchMode = LaunchMode.SingleTop, Name = "code_test.droid.view.LoginView")]
    public class LoginView : MvxActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.LoginView);
        }
    }
}