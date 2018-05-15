using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF.MVVM.Products
{
    /// <summary>
    /// Interaction logic for ProductListView.xaml
    /// </summary>
    public partial class ProductListView : UserControl
    {
        #region Events

        /// <summary>
        /// Raised when a product is selected.
        /// </summary>
        public event EventHandler OnProductSelected = delegate { };

        #endregion

        public ProductListView()
        {
            DataContext = new ObservableCollection<Product>();
            InitializeComponent();
        }

        private void ProductsControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var parent = sender as ItemsControl;
            var product = GetProductFromElementDataContext(parent, e.GetPosition(parent));
            if (product != null)
            {
                DragDrop.DoDragDrop(parent, product, DragDropEffects.Copy);
                if (OnProductSelected != null)
                {
                    OnProductSelected(this, new ProductEventArgs { Product = product as Product });
                }
            }
        }

        private object GetProductFromElementDataContext(ItemsControl source, Point point)
        {
            var element = source.InputHitTest(point) as FrameworkElement;
            if (element == null) return null;

            var product = element.DataContext as Product;
            if (product == null) return null;

            return product;
        }
    }
}
