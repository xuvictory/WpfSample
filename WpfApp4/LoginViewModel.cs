using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp4
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void PropertyChangedNotify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private LoginModel _model = new LoginModel();

		public LoginModel Model
		{
			get { return _model; }
            set
            {
                _model = value;
                PropertyChangedNotify(nameof(Model));
            }
		}

	}
}
