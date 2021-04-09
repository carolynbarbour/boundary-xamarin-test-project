using Android.Content.Res;
using Android.OS;
using Android.Views;
using MvvmCross.ViewModels;
using MvvmCross.Platforms.Android.Views.Fragments;
using MvvmCross.Platforms.Android.Views.AppCompat;
using MvvmCross.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using AndroidX.AppCompat.Widget;

namespace code_test.Droid.Views
{
    public abstract class BaseFragment : MvxFragment
    {
        private Toolbar _toolbar;
        private MvxActionBarDrawerToggle _drawerToggle;

        protected abstract int FragmentId { get; }
        
        public MvxActivity ParentActivity => (MvxActivity) Activity;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(FragmentId, null);
            _toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (_toolbar != null)
            {
                ParentActivity.SetSupportActionBar(_toolbar);
                ParentActivity.SupportActionBar.SetDisplayHomeAsUpEnabled(true);
                
                _drawerToggle = new MvxActionBarDrawerToggle(
                    Activity,                               // host Activity
                    ((MainView)ParentActivity).DrawerLayout,  // DrawerLayout object
                    _toolbar,                              // nav drawer icon to replace 'Up' caret
                    Resource.String.drawer_open,            // "open drawer" description
                    Resource.String.drawer_close            // "close drawer" description
                );
                
                _drawerToggle.DrawerOpened += OnDrawerToggleOnDrawerOpened;
                
                ((MainView)ParentActivity).DrawerLayout.AddDrawerListener(_drawerToggle);
            }

            return view;

        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (_toolbar != null)
            {
                _drawerToggle.OnConfigurationChanged(newConfig);
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (_toolbar != null)
            {
                _drawerToggle.SyncState();
            }
        }
        
        private void OnDrawerToggleOnDrawerOpened(object sender, ActionBarDrawerEventArgs e)
        {
            ((MainView)Activity)?.HideSoftKeyboard();
        }
    }

    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get => (TViewModel) base.ViewModel;
            set => base.ViewModel = value;
        }
    }
}