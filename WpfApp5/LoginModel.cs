using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp5
{
    public class LoginModel
    {
        private string _userName = string.Empty;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
            }
        }
    }
}
