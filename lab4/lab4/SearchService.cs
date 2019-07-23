using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace lab4
{
    class SearchService : ISearchService, INotifyPropertyChanged
    {

        private string _word;
        public string Word
        {
            get { return _word; }
            set
            {
                _word = value;
                OnPropertyChanged("Word");
            }
        }

        private string _elapsedTime;
        public string ElapsedTime
        {
            get { return _elapsedTime; }
        }

        private ObservableCollection<string> _foundWordsList;
        public ObservableCollection<string> FoundWordsList
        {
            get { return _foundWordsList; }
        }

        public void FindWords(ObservableCollection<string> wordsList, Func<string, List<string>, List<string>> search)
        {
            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                List<string> tmp = search(this._word, new List<string>(wordsList));

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                this._elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

                OnPropertyChanged("ElapsedTime");

                _foundWordsList = new ObservableCollection<string>(tmp);
                OnPropertyChanged("FoundWordsList");
            }
            catch (Exception)
            {
                throw new Exception("Необходимо выбрать файл и ввести слово для поиска.");
            }
        }

        public SearchService()
        {
            this._word = String.Empty;
            this._elapsedTime = String.Empty;
            _foundWordsList = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
