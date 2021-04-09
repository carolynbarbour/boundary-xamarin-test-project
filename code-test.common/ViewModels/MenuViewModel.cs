using System;
using System.Threading.Tasks;
using MvvmCross.Commands;

namespace code_test.common.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            ShowUsersCommand = new MvxAsyncCommand(OnShowUsersCommandExecute);
            ShowProductsCommand = new MvxAsyncCommand(OnShowProductsCommandExecute);
            ShowPurchasesCommand = new MvxAsyncCommand(OnShowPurchasesCommandExecute);
        }
        
        public IMvxAsyncCommand ShowUsersCommand { get; }
        public IMvxAsyncCommand ShowProductsCommand { get; }
        public IMvxAsyncCommand ShowPurchasesCommand { get; }

        private async Task OnShowUsersCommandExecute()
        {
            await NavigationService.Navigate<UsersViewModel>();
        }

        private async Task OnShowProductsCommandExecute()
        {
            await NavigationService.Navigate<ProductsViewModel>();
        }

        private async Task OnShowPurchasesCommandExecute()
        {
            throw new NotImplementedException("You should make this!");
        }
        
    }
    
}