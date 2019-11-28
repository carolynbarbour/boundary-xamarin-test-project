using System;
using System.Threading.Tasks;
using code_test.common.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace code_test.common.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private MvxObservableCollection<Product> _products;

        public ProductsViewModel()
        {
            ProductSelectedCommand = new MvxAsyncCommand<Product>(OnProductSelectedCommandExecute);
        }

        public MvxObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged(() => Products);
            }
        }
        
        public IMvxCommand<Product> ProductSelectedCommand { get; }

        public override async Task Initialize()
        {
            var productCollection = new MvxObservableCollection<Product>();

            try
            {
                var result = await ProductsService.GetAllProducts();
                
                productCollection = new MvxObservableCollection<Product>(result);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception retrieving products");
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                throw;
            }

            Products = productCollection;
        }


        private async Task OnProductSelectedCommandExecute(Product selectedProduct)
        {
            throw new NotImplementedException("You Should Make This!");
        }
    }
}