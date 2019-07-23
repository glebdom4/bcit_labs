using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab4
{
    internal interface ISearchService
    {
        string Word { get; set; }
        string ElapsedTime { get; }
        string MaxDistance { get; set; }
        ObservableCollection<string> FoundWordsList { get; }
        void FindWords(ObservableCollection<string> wordsList, Func<string, int, List<string>, List<Tuple<string, int>>> search);
    }
}