using Android.OS;
using Android.Runtime;
using Android.Views;
using code_test.common.ViewModels;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;

namespace code_test.Droid.Views
{
    [MvxFragmentPresentation(typeof(LoginViewModel), Resource.Id.content_frame, true)]
    [Register("code_test.droid.views.SignUpView")]
    public class SignUpView : MvxFragment<SignUpViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.SignUpView, null);
            return view;
        }
    }
}