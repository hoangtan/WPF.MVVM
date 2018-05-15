using System;

namespace WPF.MVVM.Search
{
    public class SearchEventArgs : EventArgs
    {
        public string SearchTerm { get; set; }

        public int SearchResultsCount { get; set; }
    }
}
