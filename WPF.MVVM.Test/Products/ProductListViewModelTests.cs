using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.MVVM.Products;

namespace WPF.MVVM.Test.Products
{
    [TestClass]
    public class ProductListViewModelTests
    {
        [TestMethod]
        public void NotifiesPropertyChangedForItemsAdded()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            var viewModel = new ProductListViewModel(productsToSearch);

            var notifiedPropertyChanged = false;
            viewModel.Items.CollectionChanged += (sender, args) =>
            {
                notifiedPropertyChanged = true;
            };

            // Act
            viewModel.Items.Add(new Product { Name = "The Fallen" });

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }

        [TestMethod]
        public void NotifiesPropertyChangedForItemsCleared()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            var viewModel = new ProductListViewModel(productsToSearch);

            var notifiedPropertyChanged = false;
            viewModel.Items.CollectionChanged += (sender, args) =>
            {
                notifiedPropertyChanged = true;
            };

            // Act
            viewModel.Items.Clear();

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }

        [TestMethod]
        public void NotifiesPropertyChangedForItemsRemoved()
        {
            // Arrange
            var productsToSearch = new ObservableCollection<Product>
            {
                new Product { Name = "The Lost Flowers of Alice Hart" },
                new Product { Name = "The Yellow House" },
                new Product { Name = "The Woman In The Window" }
            };
            var viewModel = new ProductListViewModel(productsToSearch);

            var notifiedPropertyChanged = false;
            viewModel.Items.CollectionChanged += (sender, args) =>
            {
                notifiedPropertyChanged = true;
            };

            // Act
            viewModel.Items.RemoveAt(0);

            // Assert
            Assert.AreEqual(true, notifiedPropertyChanged);
        }
    }
}
