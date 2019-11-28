using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using code_test.common.ViewModels;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace code_test.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("code_test.droid.views.ProductsView")]
    public class ProductsView : BaseFragment<ProductsViewModel>
    {
        protected override int FragmentId => Resource.Layout.ProductsView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            ParentActivity.SupportActionBar.Title = "Products";

            var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.products_recycler_view);
            if (recyclerView != null)
            {
                recyclerView.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerView.SetLayoutManager(layoutManager);
            }

            return view;
        }
    }
}