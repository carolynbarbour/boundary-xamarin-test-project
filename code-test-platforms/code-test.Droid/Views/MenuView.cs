using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using code_test.common.ViewModels;
using MvvmCross.Platforms.Android.Views.Fragments;
using Google.Android.Material.Navigation;

namespace code_test.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("code_test.droid.views.MenuView")]
    public class MenuView : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;

        private IMenuItem _prevItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.MenuView, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_users).SetChecked(true);
            // Set the Users menu item to be checked as it will be the first ViewModel navigated to.
            
            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem menuItem)
        {
            _prevItem?.SetChecked(false);

            menuItem.SetCheckable(true);
            menuItem.SetChecked(true);

            _prevItem = menuItem;

            Task.Run(() => HandleNavRequest(menuItem.ItemId));

            return true;
        }

        private async Task HandleNavRequest(int itemResourceId)
        {
            ((MainView)Activity).DrawerLayout.CloseDrawers();
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (itemResourceId)
            {
                case Resource.Id.nav_users:
                {
                    ViewModel.ShowUsersCommand.Execute(null);
                    break;
                }

                case Resource.Id.nav_products:
                {
                    ViewModel.ShowProductsCommand.Execute(null);
                    break;
                }

                case Resource.Id.nav_purchases:
                {
                    ViewModel.ShowPurchasesCommand.Execute(null);
                    break;
                }
            }

        }
    }
}