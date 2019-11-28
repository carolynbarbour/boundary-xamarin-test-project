using code_test.common.Services;
using code_test.common.Services.ProductsService;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace code_test.common.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected IUsersService UsersService { get; }
        
        protected IProductsService ProductsService { get; }
        
        protected IMvxNavigationService NavigationService { get; }

        protected BaseViewModel(IUsersService usersService = null, IProductsService productsService = null, IMvxNavigationService navService = null)
        {
            UsersService = usersService ?? Mvx.IoCProvider.Resolve<IUsersService>();
            ProductsService = productsService ?? Mvx.IoCProvider.Resolve<IProductsService>();
            NavigationService = navService ?? Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }
    }

    public abstract class BaseViewModel<TParam> : MvxViewModel<TParam> where TParam : class
    {
        protected IUsersService UsersService { get; }
        protected IMvxNavigationService NavigationService { get; }

        protected BaseViewModel(IUsersService usersService = null, IMvxNavigationService navigationService = null)
        {
            UsersService = usersService;
            NavigationService = navigationService;
        }
    }

    public abstract class BaseViewModel<TParam, TResult> : MvxViewModel<TParam, TResult>
        where TParam : class where TResult : class
    {
        protected IUsersService UsersService { get; }
        
        protected IMvxNavigationService NavigationService { get; }
        
        protected BaseViewModel(IUsersService usersService = null, IMvxNavigationService navigationService = null)
        {
            UsersService = usersService ?? Mvx.IoCProvider.Resolve<IUsersService>();
            NavigationService = navigationService ?? Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }
    }
}