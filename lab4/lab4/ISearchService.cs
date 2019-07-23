using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab4
{
    internal interface ISearchService
    {
        string Word { get; set; }
        string ElapsedTime { get; }
        ObservableCollection<string> FoundWordsList { get; }
        void FindWords(ObservableCollection<string> wordsList, Func<string, List<string>, List<string>> search);
    }
}