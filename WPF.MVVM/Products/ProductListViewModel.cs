using System.Collections.ObjectModel;
using WPF.MVVM.Services;

namespace WPF.MVVM.Products
{
    public class ProductListViewModel : BindableBase
    {
        protected ObservableCollection<Product> _items;

        /// <summary>
        /// Products to be listed. Subscribe to ObservableCollection.CollectionChanged to be notified of changes.
        /// </summary>
        public ObservableCollection<Product> Items
        {
            get
            {
                return _items;
            }
            set
            {
                SetProperty(ref _items, value, "Items");
            }
        }

        public ProductListViewModel()
        {
            Items = new ObservableCollection<Product>();
        }

        public ProductListViewModel(ObservableCollection<Product> items)
        {
            Items = items;
        }
    }
}
