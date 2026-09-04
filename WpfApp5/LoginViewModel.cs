using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace WpfApp5
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private MainWindow _mainWindow;

        public LoginViewModel(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void PropertyChangedNotify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
                
        private LoginModel _model = new LoginModel();
                
        public string UserName
		{
			get { return _model.UserName; }
            set
            {
                _model.UserName = value;
                PropertyChangedNotify(nameof(UserName));
            }
		}

        public string Password
        {
            get { return _model.Password; }
            set
            {
                _model.Password = value;
                PropertyChangedNotify(nameof(Password));
            }
        }

        void LoginFunc()
        {
            if (UserName == "wpf" && Password == "666")
            {
                Index index = new Index();
                index.Show();

                _mainWindow.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");

                UserName = "";
                Password = "";
            }
        }

        bool CanLoginExecute()
        {
            return true;
        }

        public ICommand LoginAction
        {
            get { return new RelayCommand(LoginFunc, CanLoginExecute); }
        }

    }
}
