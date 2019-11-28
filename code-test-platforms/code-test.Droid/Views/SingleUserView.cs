using Android.OS;
using Android.Runtime;
using Android.Views;
using code_test.common.ViewModels;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace code_test.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("code_test.droid.views.SingleUserView")]
    public class SingleUserView : BaseFragment<SingleViewUserViewModel>
    {
        protected override int FragmentId => Resource.Layout.SingleUserView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedBundleInstance)
        {
            var view = base.OnCreateView(inflater, container, savedBundleInstance);

            ParentActivity.SupportActionBar.Title = "Single User";

            return view;
        }
    }
}