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

        private string _maxDistance;
        public string MaxDistance
        {
            get { return _maxDistance; }
            set
            {
                _maxDistance = value;
                OnPropertyChanged("MaxDistance");
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

        public void FindWords(ObservableCollection<string> wordsList, Func<string, int, List<string>, List<Tuple<string, int>>> search)
        {
            if (wordsList == null)
            {
                throw new ArgumentNullException(nameof(wordsList));
            }

            try
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                List<Tuple<string, int>> tmp = search(this._word, int.Parse(this._maxDistance), new List<string>(wordsList));

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                this._elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);

                OnPropertyChanged("ElapsedTime");

                _foundWordsList.Clear();

                // Создание строк "Слово (расстояние = число)" и сохранение их с список
                foreach (var item in tmp)
                {
                    string temp = item.Item1 + " (расстояние = " + item.Item2.ToString() + ")";
                    _foundWordsList.Add(temp);
                }

                OnPropertyChanged("FoundWordsList");
            }
            catch (Exception ex)
            {
                throw new Exception("Необходимо выбрать файл и ввести слово для поиска, " +
                    "а также указать максимальное расстояние для поиска в пределах от 1 до 5.");
            }
        }

        public SearchService()
        {
            this._word = String.Empty;
            this._maxDistance = String.Empty;
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
