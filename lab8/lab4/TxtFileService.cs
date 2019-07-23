using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace lab4
{
    class TxtFileService : IFileService, INotifyPropertyChanged
    {
        private static readonly char[] separators = {' ', '.', ',', '!', '?', '/', '\t', '\n'};

        private string _elapsedTime;
        public string ElapsedTime
        {
            get { return _elapsedTime; }
        }

        public List<string> Open(string filename)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<string> words = new List<string>();
            string text = File.ReadAllText(filename);
            string[] textArray = text.Split(separators);

            foreach (string strTemp in textArray)
            {
                string str = strTemp.Trim();
                if (!words.Contains(str)) words.Add(str);
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            this._elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            OnPropertyChanged("ElapsedTime");

            return words;
        }

        public void Save(string filename, string data)
        {
            File.AppendAllText(filename, data);
        }

        public TxtFileService()
        {
            this._elapsedTime = String.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
