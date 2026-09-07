using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace WpfApp9
{
    public class MainViewModel : ViewModelBase //: INotifyPropertyChanged
    {

        public MainViewModel()
        {
            //MyCommand = new MyCommand(Show);

            MyCommand = new RelayCommand<string>(Show);
        }

        private string title;

		public string Title
		{
			get { return title; }
			set { title = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));

                RaisePropertyChanged();

            }
		}

		private string name;

        public string Name
		{
			get { return name; }
			set { name = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));

                RaisePropertyChanged();
            }
		}

        //public MyCommand MyCommand { get;};

        public RelayCommand<string> MyCommand { get; }

        //public event PropertyChangedEventHandler? PropertyChanged;

		public void Show(string message)
		{
            Title = "点击了Click";
            //Name = "点击了Click";

            //MessageBox.Show(Name);

            Messenger.Default.Send(message, "Token1");
		}
    }
}
