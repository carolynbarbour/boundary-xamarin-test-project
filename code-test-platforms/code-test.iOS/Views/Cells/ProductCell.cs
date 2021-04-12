using System;
using code_test.common.Models;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;

namespace code_test.iOS.Views.Cells
{
    public partial class ProductCell : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("ProductCell");
        public static readonly UINib Nib = UINib.FromName("ProductCell", NSBundle.MainBundle);

        public ProductCell()
        {
            BindView();
        }

        protected ProductCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
            BindView();
        }

        void BindView()
        {
            this.DelayBind(() =>
            {
                var bindings = this.CreateBindingSet<ProductCell, Product>();
                bindings.Bind(NameLabel).To(vm => vm.DisplayName);
                bindings.Bind(CostLabel).To(vm => vm.Cost);
                bindings.Apply();
            });
        }
    }
}
