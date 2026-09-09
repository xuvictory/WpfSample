using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace WpfApp10
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            ClickCommand = new RelayCommand(() => {

                this.Title = DateTime.Now.ToString();
            });

            GetCommand = new RelayCommand(() => {

                MessageBox.Show(this.Title);
            });
        }

        private string title = "123";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public RelayCommand ClickCommand { get; }

        public RelayCommand GetCommand { get; }

    }
}
