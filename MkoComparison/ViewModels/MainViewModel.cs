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

        }

        public RelayCommand OpenFileCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();

                    openFileDialog.Title = "Выбор файла";
                    openFileDialog.Filter = "Files (*.dat)|*.dat";
                    openFileDialog.FilterIndex = 1;
                    bool? dialogOK = openFileDialog.ShowDialog();

                    if (dialogOK == true)
                    {

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