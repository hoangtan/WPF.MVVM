using System;
using System.Collections.ObjectModel;
using System.Windows;
using WPF.MVVM.Products;

namespace WPF.MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var products = new ObservableCollection<Product>()
            {
                new Product() { ProductID = Guid.NewGuid(), Name = "The Lost Flowers of Alice Hart", Description = "An enchanting and captivating novel, about how our untold stories haunt us - and the stories we tell ourselves in order to survive."},
                new Product() { ProductID = Guid.NewGuid(), Name = "The Yellow House", Description = "Ten-year-old Cub lives with her parents, older brother Cassie, and twin brother Wally on a lonely property bordering an abandoned cattle farm and knackery."},
                new Product() { ProductID = Guid.NewGuid(), Name = "The Woman In The Window", Description = "Get ready for the biggest thriller of 2018!."},
            };

            var searchControl = new Products.ProductSearchComboBox(products);

            mainContent.Children.Add(searchControl);
        }
    }
}
