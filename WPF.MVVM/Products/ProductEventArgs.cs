using System;

namespace WPF.MVVM.Products
{
    public class ProductEventArgs : EventArgs
    {
        public Product Product { get; set; }
    }
}
