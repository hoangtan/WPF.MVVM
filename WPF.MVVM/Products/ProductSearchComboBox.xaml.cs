using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WPF.MVVM.Search;

namespace WPF.MVVM.Products
{
    /// <summary>
    /// Interaction logic for ProductSearchComboBox.xaml
    /// </summary>
    public partial class ProductSearchComboBox : UserControl
    {
        #region Events

        /// <summary>
        /// Raised when a product is selected.
        /// </summary>
        public event EventHandler OnProductSelected = delegate { };

        #endregion

        public ProductSearchComboBox(ObservableCollection<Product> products)
        {
            InitializeComponent();

            var searchViewModel = new ProductSearchViewModel(products);
            searchViewModel.OnSearchFinished += (sender, args) =>
            {
                var search = sender as ISearchViewModel<Product>;

            };
            ProductSearchControl.DataContext = searchViewModel;
            ProductListControl.DataContext = new ProductListViewModel(searchViewModel.SearchResults);
        }

        #region IView Members

        public FrameworkElement GetUIView()
        {
            return this;
        }

        public string ViewName
        {
            get;
            set;
        }

        public RoutedEventHandler ViewLoading
        {
            get { return null; }
            set { }
        }

        public RoutedEventHandler ViewUnloading
        {
            get { return null; }
            set { }
        }

        public void ExecuteNamedCommand(string commandName) { }

        #endregion
    }
}
