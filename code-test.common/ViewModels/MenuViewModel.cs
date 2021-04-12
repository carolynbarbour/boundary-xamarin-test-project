using System;
using System.Collections.Generic;
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
            SelectMenuItemCommand = new MvxAsyncCommand<MenuItem>(async item => await item.Command.ExecuteAsync());

            CreateMenuItems();
        }

        public IMvxAsyncCommand ShowUsersCommand { get; }
        public IMvxAsyncCommand ShowProductsCommand { get; }
        public IMvxAsyncCommand ShowPurchasesCommand { get; }
        public IMvxAsyncCommand<MenuItem> SelectMenuItemCommand { get; }

        List<MenuItem> _menuItems;
        public List<MenuItem> MenuItems { get => _menuItems; set => SetProperty(ref _menuItems, value); }

        private void CreateMenuItems()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem("Users", ShowUsersCommand),
                new MenuItem("Products", ShowProductsCommand),
                new MenuItem("Purchases", ShowPurchasesCommand)
            };
        }

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

    public class MenuItem
    {
        public string Title { get; private set; }
        public IMvxAsyncCommand Command { get; private set; }

        public MenuItem(string title, IMvxAsyncCommand command)
        {
            Title = title;
            Command = command;
        }
    }
}