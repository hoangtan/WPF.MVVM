using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WPF.MVVM.Search;
using WPF.MVVM.Services;

namespace WPF.MVVM.Products
{
    public class ProductSearchViewModel : BindableBase, ISearchViewModel<Product>
    {
        #region Events

        /// <summary>
        /// Raised after the search has been cleared and all results discarded.
        /// </summary>
        public event EventHandler OnCleared = delegate { };

        /// <summary>
        /// Raised when a search has been initiated, before any items have been evaluated.
        /// </summary>
        public event EventHandler OnSearchStarted = delegate { };

        /// <summary>
        /// Raised when a search has finished, after all items have been evaluated.
        /// </summary>
        public event EventHandler OnSearchFinished = delegate { };

        #endregion

        #region Properties

        private bool _hasSearchTerm;
        public bool HasSearchTerm
        {
            get
            {
                return _hasSearchTerm;
            }
            private set
            {
                SetProperty(ref _hasSearchTerm, value, "HasSearchTerm");
            }
        }

        protected string _helpText;
        /// <summary>
        /// Tip for the user how the search functions.
        /// </summary>
        public string HelpText
        {
            get
            {
                return _helpText;
            }
            set
            {
                SetProperty(ref _helpText, value, "HelpText");
            }
        }

        protected ObservableCollection<Product> _itemsToSearch;
        public ObservableCollection<Product> ItemsToSearch
        {
            get
            {
                return _itemsToSearch;
            }
            private set
            {
                SetProperty(ref _itemsToSearch, value, "ItemsToSearch");
            }
        }

        protected ObservableCollection<Product> _searchResults;
        public ObservableCollection<Product> SearchResults
        {
            get
            {
                return _searchResults;
            }
            private set
            {
                SetProperty(ref _searchResults, value, "SearchResults");
            }
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get
            {
                return _searchTerm;
            }

            set
            {
                SetProperty(ref _searchTerm, value, "SearchTerm");

                if (!string.IsNullOrEmpty(value) && value != HelpText)
                {
                    HasSearchTerm = true;
                }
                else
                {
                    HasSearchTerm = false;
                }

                Search();
            }
        }

        protected int _searchTermMinimumLength;
        /// <summary>
        /// Minimum length of a search term before a search will be performed.
        /// </summary>
        public int SearchTermMinimumLength
        {
            get
            {
                return _searchTermMinimumLength;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Search term minimum length must be greater than zero.");
                }
                SetProperty(ref _searchTermMinimumLength, value, "SearchTermMinimumLength");
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Clears the search.
        /// </summary>
        public RelayCommand ClearCommand { get; private set; }

        /// <summary>
        /// Performs the search.
        /// </summary>
        public RelayCommand SearchCommand { get; private set; }

        #endregion

        public ProductSearchViewModel()
        {
            HelpText = "Search by product name or description";
            ItemsToSearch = new ObservableCollection<Product>();
            SearchTerm = HelpText;
            SearchTermMinimumLength = 3;
            SearchResults = new ObservableCollection<Product>();

            ClearCommand = new RelayCommand(c => Clear(), c => CanClear());
            SearchCommand = new RelayCommand(c => Search(), c => CanSearch());
        }

        public ProductSearchViewModel(ObservableCollection<Product> itemsToSearch)
            : this()
        {
            ItemsToSearch = itemsToSearch;
        }

        bool CanClear()
        {
            return !string.IsNullOrEmpty(SearchTerm) || SearchResults.Any();
        }

        bool CanSearch()
        {
            if (ItemsToSearch == null || !ItemsToSearch.Any() ||
                SearchTerm == HelpText || string.IsNullOrEmpty(SearchTerm) || SearchTerm.Trim().Length < SearchTermMinimumLength)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Clears the current search term and any results.
        /// </summary>
        public void Clear()
        {
            if (SearchResults != null && SearchResults.Any())
            {
                SearchResults.Clear();
            }
            SearchTerm = string.Empty;
            if (OnCleared != null)
            {
                OnCleared(this, new SearchEventArgs());
            }
        }

        /// <summary>
        /// Searches for any products matching the given keyword and populates the search results.
        /// </summary>
        public void Search()
        {
            if (!CanSearch())
            {
                if (SearchResults != null && SearchResults.Any())
                {
                    SearchResults.Clear();
                }
                return;
            }

            try
            {
                if (OnSearchStarted != null)
                {
                    OnSearchStarted(this, new SearchEventArgs { SearchTerm = SearchTerm });
                }

#if DEBUG
                System.Diagnostics.Debug.WriteLine(string.Format("Searching products for term '{0}'.", SearchTerm));
                var searchStopwatch = new System.Diagnostics.Stopwatch();
                searchStopwatch.Start();
#endif

                var invalidatedMatches = SearchResults.Where(p => !IsMatch(p, SearchTerm)).ToList();
                foreach (var match in invalidatedMatches)
                {
                    SearchResults.Remove(match);
                }

                var newMatches = ItemsToSearch
                    .Where(p => !SearchResults.Any(r => r.ProductID == p.ProductID) && IsMatch(p, SearchTerm))
                    .OrderBy(p => p.Name);

                foreach (var match in newMatches)
                {
                    SearchResults.Add(match);
                }

#if DEBUG
                searchStopwatch.Stop();
                System.Diagnostics.Debug.WriteLine(string.Format("Searchings products for term '{0}' finished in {1} millisecond(s) and return {2} result(s).", SearchTerm, searchStopwatch.ElapsedMilliseconds.ToString(), SearchResults.Count.ToString()));
#endif
            }
            catch
            {
            }
            finally
            {
                if (OnSearchFinished != null)
                {
                    OnSearchFinished(this, new SearchEventArgs { SearchTerm = SearchTerm, SearchResultsCount = SearchResults.Count });
                }
            }
        }

        /// <summary>
        /// Determines whether the product has a value that matches the search term(s).
        /// </summary>
        private static bool IsMatch(Product product, string searchTerm)
        {
            if (product == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(searchTerm))
            {
                return false;
            }

            searchTerm = searchTerm.Trim();
            searchTerm = searchTerm.ToLowerInvariant();
            while (searchTerm.Contains("  "))
            {
                searchTerm = searchTerm.Replace("  ", " ");
            }
            var searchTermWords = searchTerm.Split(' ');

            var productValues = new List<string>();
            if (!string.IsNullOrEmpty(product.Name))
            {
                productValues.Add(product.Name.Trim().ToLowerInvariant());
            }
            if (!string.IsNullOrEmpty(product.Description))
            {
                productValues.Add(product.Description.Trim().ToLowerInvariant());
            }

            var resultsFromSearchingValues = new Dictionary<string, bool>();
            foreach (var productValue in productValues)
            {
                var found = searchTermWords.All(w => productValue.Contains(w));
                if (!resultsFromSearchingValues.Any(r => r.Key == productValue))
                {
                    resultsFromSearchingValues.Add(productValue, found);
                }
            }

            return resultsFromSearchingValues.Any(r => r.Value == true);
        }
    }
}
