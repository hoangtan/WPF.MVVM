using System.Windows.Controls;
using System.Windows.Input;
using WPF.MVVM.Search;

namespace WPF.MVVM.Products
{
    /// <summary>
    /// Interaction logic for ProductSearchView.xaml
    /// </summary>
    public partial class ProductSearchView : UserControl
    {
        public ProductSearchView()
        {
            DataContext = new ProductSearchViewModel();
            InitializeComponent();
        }

        private void SearchTermTextBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            var viewModel = DataContext as ISearchViewModel<Product>;
            if (viewModel == null) return;

            e.Handled = true;

            if (textBox.Text.Contains(viewModel.HelpText)) textBox.Text = string.Empty;

            FocusManager.SetIsFocusScope(this, true);
        }

        private void SearchTermTextBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            var viewModel = DataContext as ISearchViewModel<Product>;
            if (viewModel == null) return;

            e.Handled = true;

            if (string.IsNullOrEmpty(textBox.Text)) textBox.Text = viewModel.HelpText;

            FocusManager.SetIsFocusScope(this, false);
        }
    }
}
