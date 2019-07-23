using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace lab4
{
    class AppViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> _wordsList;
        public ObservableCollection<string> WordsList
        {
            get { return _wordsList; }
            set
            {
                _wordsList = value;
                OnPropertyChanged("WordsList");
            }
        }

        IFileService _fileService;
        public IFileService FileService
        {
            get { return _fileService; }
        }

        IDialogService _dialogService;
        public IDialogService DialogService
        {
            get { return _dialogService; }
        }

        ISearchService _searchService;
        public ISearchService SearchService
        {
            get { return _searchService; }
        }

        // команда открытия файла
        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                  (_openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (_dialogService.OpenFileDialog() == true)
                          {
                              _dialogService.ShowMessage("Файл открыт!");
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда чтения из файла
        private RelayCommand _readFileCommand;
        public RelayCommand ReadFileCommand
        {
            get
            {
                return _readFileCommand ??
                  (_readFileCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          this._wordsList = new ObservableCollection<string>(_fileService.Open(_dialogService.FilePath));
                          OnPropertyChanged("WordsList");
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда записи в файл (создание и сохранение отчёта)
        private RelayCommand _saveReportCommand;
        public RelayCommand SaveReportCommand
        {
            get
            {
                return _saveReportCommand ??
                  (_saveReportCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (_dialogService.SaveFileDialog() == true)
                          {
                              #region Создание отчёта

                              StringBuilder stringBuilder = new StringBuilder();

                              stringBuilder.AppendLine("Время чтения из файла: " + _fileService.ElapsedTime);
                              stringBuilder.AppendLine("Количество уникальных слов в файле: " + _wordsList.Count);
                              stringBuilder.AppendLine("Слово для поиска: " + _searchService.Word);
                              stringBuilder.AppendLine("Время чёткого поиска: " + _searchService.ElapsedTime);
                              stringBuilder.AppendLine("Результаты поиска:");

                              foreach (string str in _searchService.FoundWordsList)
                              {
                                  stringBuilder.AppendLine(str);
                              }

                              #endregion

                              #region Сохранение отчёта

                              _fileService.Save(_dialogService.FilePath, stringBuilder.ToString());
                              _dialogService.ShowMessage("Отчет сохранён. Файл: " + _dialogService.FilePath);

                              #endregion
                          }
                      }
                      catch (Exception ex)
                      {
                          _dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        // команда поиска слов в списке
        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                return _searchCommand ??
                    (_searchCommand = new RelayCommand(obj =>
                    {
                        try
                        {
                            _searchService.FindWords(this._wordsList, FuzzySearch.Search);
                        }
                        catch (Exception ex)
                        {
                            _dialogService.ShowMessage(ex.Message);
                        }
                    }));
            }
        }



        public AppViewModel(IDialogService dialogService, IFileService fileService, ISearchService searchService)
        {
            this._dialogService = dialogService;
            this._fileService = fileService;
            this._searchService = searchService;
            this._wordsList = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
