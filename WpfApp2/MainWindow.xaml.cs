using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private string _userName = string.Empty;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                //PropertyChangedNotify(nameof(UserName));
                PropertyChangedNotify();
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                //PropertyChangedNotify(nameof(Password));
                PropertyChangedNotify();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        //private void PropertyChangedNotify(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        private void PropertyChangedNotify([CallerMemberName]string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UserName == "wpf" && Password == "666")
            {
                Index index = new Index();
                index.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");

                this.UserName = "";
                this.Password = "";
            }
        }
    }
}