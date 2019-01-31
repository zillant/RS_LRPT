using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Windows;

namespace MkoComparison.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            OriginalFileName = "Не выбран";
            ReceivedFileName = "Не выбран";
        }

        private string _originalFileName;
        public string OriginalFileName
        {
            get => _originalFileName;
            set
            {
                _originalFileName = value;
                RaisePropertyChanged(nameof(OriginalFileName));
            }
        }

        private string _receivedFileName;
        public string ReceivedFileName
        {
            get => _receivedFileName;
            set
            {
                _receivedFileName = value;
                RaisePropertyChanged(nameof(ReceivedFileName));
            }
        }

        public RelayCommand<int> OpenFileCommand
        {
            get
            {
                return new RelayCommand<int>((e) =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog
                    {
                        Title = "Выбор файла",
                        FilterIndex = 1
                    };

                    switch (e)
                    {
                        case 0: openFileDialog.Filter = "Mko files (*.mko)|*.mko"; break;
                        case 1: openFileDialog.Filter = "Txt files (*.txt)|*.txt"; break;
                        default: break;
                    }
                    
                    bool? dialogOK = openFileDialog.ShowDialog();

                    if (dialogOK == true)
                    {
                        switch (e)
                        {
                            case 0: OriginalFileName = openFileDialog.SafeFileName; break;
                            case 1: ReceivedFileName = openFileDialog.SafeFileName; break;
                            default: break;
                        }
                    }
                });
            }
        }

        public RelayCommand<CancelEventArgs> ClosingProgramCommand
        {
            get
            {
                return new RelayCommand<CancelEventArgs>((e) =>
                {
                    var result = MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                });
            }
        }
    }
}