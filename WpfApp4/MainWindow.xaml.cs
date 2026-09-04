using System.ComponentModel;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginViewModel _loginViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _loginViewModel = new LoginViewModel();

            this.DataContext = _loginViewModel;
        }

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this._loginViewModel.Model.UserName == "wpf" && this._loginViewModel.Model.Password == "666")
            {
                Index index = new Index();
                index.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("用户名或密码错误");

                this._loginViewModel.Model.UserName = "";
                this._loginViewModel.Model.Password = "";

                this._loginViewModel.Model = this._loginViewModel.Model; //这块要重新赋值下
            }
        }
    }

    //public class LoginModel : INotifyPropertyChanged
    //{
    //    private string _userName = string.Empty;
    //    public string UserName
    //    {
    //        get { return _userName; }
    //        set
    //        {
    //            _userName = value;
    //            PropertyChangedNotify(nameof(UserName));
    //        }
    //    }

    //    private string _password = string.Empty;
    //    public string Password
    //    {
    //        get { return _password; }
    //        set
    //        {
    //            _password = value;
    //            PropertyChangedNotify(nameof(Password));
    //        }
    //    }

    //    public event PropertyChangedEventHandler? PropertyChanged;

    //    private void PropertyChangedNotify(string propertyName)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
    //        }
    //    }

    //}
}