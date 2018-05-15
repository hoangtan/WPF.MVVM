using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WPF.MVVM.Services;

namespace WPF.MVVM.Search
{
    public interface ISearchViewModel<T> : INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        /// Raised after the search has been cleared and all results discarded.
        /// </summary>
        event EventHandler OnCleared;

        /// <summary>
        /// Raised when a search has been initiated, before any items have been evaluated.
        /// </summary>
        event EventHandler OnSearchStarted;

        /// <summary>
        /// Raised when a search has finished, after all items have been evaluated.
        /// </summary>
        event EventHandler OnSearchFinished;

        #endregion

        #region Properties

        bool HasSearchTerm { get; }

        /// <summary>
        /// Tip for the user how the search functions.
        /// </summary>
        string HelpText { get; set; }

        /// <summary>
        /// Items which are to be searched. Subscribe to ObservableCollection.CollectionChanged to be notified of changes.
        /// </summary>
        ObservableCollection<T> ItemsToSearch { get; }

        /// <summary>
        /// Results populated following a search. Subscribe to ObservableCollection.CollectionChanged to be notified of changes.
        /// </summary>
        ObservableCollection<T> SearchResults { get; }

        /// <summary>
        /// Most recently used search term.
        /// </summary>
        string SearchTerm { get; set; }

        /// <summary>
        /// Minimum length of a search term before a search will be performed.
        /// </summary>
        int SearchTermMinimumLength { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Clears the search.
        /// </summary>
        RelayCommand ClearCommand { get; }

        /// <summary>
        /// Performs the search.
        /// </summary>
        RelayCommand SearchCommand { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Clears the current search term and any results.
        /// </summary>
        void Clear();

        /// <summary>
        /// Searches for any items matching the given keyword and populates the search results.
        /// </summary>
        void Search();

        #endregion
    }
}
