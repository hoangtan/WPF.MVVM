using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MVVM.Products;
using WPF.MVVM.Search;

namespace WPF.MVVM.Test.Products
{
    [TestClass]
    public class ProductSearchViewModelTests
    {
        [TestMethod]
        public void DoesNotFindProductsWhenNoItemsToSearch()
        {
            // Arrange
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel();
            viewModel.SearchTerm = "a";
            viewModel.SearchTermMinimumLength = 0;

            // Act
            viewModel.Search();

            // Assert
            Assert.IsTrue(viewModel.SearchResults.Count == 0);
        }

        [TestMethod]
        public void DoesNotFindProductsWhenNoSearchTerm()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);
            viewModel.SearchTerm = string.Empty;
            viewModel.SearchTermMinimumLength = 0;

            // Act
            viewModel.Search();

            // Assert
            Assert.IsTrue(viewModel.SearchResults.Count == 0);
        }

        [TestMethod]
        public void DoesNotFindProductsWhenTooShortSearchTerm()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);
            viewModel.SearchTerm = "a";
            viewModel.SearchTermMinimumLength = 2;

            // Act
            viewModel.Search();

            // Assert
            Assert.IsTrue(viewModel.SearchResults.Count == 0);
        }

        [TestMethod]
        public void DoesNotFindProductsWhenUnknownSearchTerm()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);
            viewModel.SearchTerm = "zz";
            viewModel.SearchTermMinimumLength = 2;

            // Act
            viewModel.Search();

            // Assert
            Assert.IsTrue(viewModel.SearchResults.Count == 0);
        }

        [TestMethod]
        public void FindAnyProductsMatchingKnownSearchTerm()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);
            viewModel.SearchTerm = "wi";
            viewModel.SearchTermMinimumLength = 2;

            // Act
            viewModel.Search();

            // Assert
            Assert.IsTrue(viewModel.SearchResults.Count >= 1);
        }

        [TestMethod]
        public void FindOneProductsMatchingKnownSearchTerm()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);
            viewModel.SearchTerm = "yellow";
            viewModel.SearchTermMinimumLength = 1;

            // Act
            viewModel.Search();

            // Assert
            Assert.AreEqual(1, viewModel.SearchResults.Count);
        }

        [TestMethod]
        public void FindTwoProductsMatchingKnownSearchTerm()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);
            viewModel.SearchTerm = "i";
            viewModel.SearchTermMinimumLength = 1;

            // Act
            viewModel.Search();

            // Assert
            Assert.AreEqual(2, viewModel.SearchResults.Count);
        }

        [TestMethod]
        public void NotifiesPropertyChangedForHasSearchTerm()
        {
            // Arrange
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel();
            var notifiedPropertyChanged = false;
            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "HasSearchTerm")
                {
                    notifiedPropertyChanged = true;
                }
            };

            // Act
            viewModel.SearchTerm = "i";

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }

        [TestMethod]
        public void NotifiesPropertyChangedForItemsToSearchAdded()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);

            var notifiedPropertyChanged = false;
            viewModel.ItemsToSearch.CollectionChanged += (sender, args) =>
            {
                notifiedPropertyChanged = true;
            };

            // Act
            viewModel.ItemsToSearch.Add(new Product { Name = "Socket" });

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }

        [TestMethod]
        public void NotifiesPropertyChangedForItemsToSearchCleared()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);

            var notifiedPropertyChanged = false;
            viewModel.ItemsToSearch.CollectionChanged += (sender, args) =>
            {
                notifiedPropertyChanged = true;
            };

            // Act
            viewModel.ItemsToSearch.Clear();

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }

        [TestMethod]
        public void NotifiesPropertyChangedForItemsToSearchRemoved()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel(productsToSearch);

            var notifiedPropertyChanged = false;
            viewModel.ItemsToSearch.CollectionChanged += (sender, args) =>
            {
                notifiedPropertyChanged = true;
            };

            // Act
            viewModel.ItemsToSearch.RemoveAt(0);

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }

        [TestMethod]
        public void NotifiesPropertyChangedForSearchTerm()
        {
            // Arrange
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel();
            var notifiedPropertyChanged = false;
            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SearchTerm")
                {
                    notifiedPropertyChanged = true;
                }
            };

            // Act
            viewModel.SearchTerm = "i";

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }

        [TestMethod]
        public void NotifiesPropertyChangedForSearchTermMinimumLength()
        {
            // Arrange
            ISearchViewModel<Product> viewModel = new ProductSearchViewModel();
            var notifiedPropertyChanged = false;
            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SearchTermMinimumLength")
                {
                    notifiedPropertyChanged = true;
                }
            };

            // Act
            viewModel.SearchTermMinimumLength = viewModel.SearchTermMinimumLength + 1;

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }
    }
}
