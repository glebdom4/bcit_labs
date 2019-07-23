using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace lab4
{
    class DefaultDialogService : IDialogService, INotifyPropertyChanged
    {
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set
            {
                _filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text documents(.txt)| *.txt"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _filePath = openFileDialog.FileName;
                OnPropertyChanged("FilePath");
                return true;
            }

            return false;
        }

        public bool SaveFileDialog()
        {
            string tempReportFileName = "Report_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss");

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = tempReportFileName,
                DefaultExt = ".txt",
                Filter = "Text documents(.txt)| *.txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _filePath = saveFileDialog.FileName;
                return true;
            }

            return false;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public DefaultDialogService()
        {
            this._filePath = String.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
