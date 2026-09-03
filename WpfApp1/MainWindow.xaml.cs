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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty AbsNameProperty =
            DependencyProperty.Register(nameof(AbsName), typeof(string), typeof(MainWindow),
                new PropertyMetadata("你好", new PropertyChangedCallback(PropertyChangedHandle),
                                            new CoerceValueCallback(CoerceValueHandle)),
                new ValidateValueCallback(ValidateValueHandle));
        public string AbsName
        {
            get { return  (string)GetValue(AbsNameProperty); }
            set { SetValue(AbsNameProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            string newValue = $"{random.Next(1,100)}";

            this.AbsName = newValue;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.AbsName);
        }

        private static void PropertyChangedHandle(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }

        private static object CoerceValueHandle(DependencyObject d, object baseValue)
        {
            if(baseValue.ToString() == "你好3")
            {
                return "你好4";
            }

            return (object)baseValue;
        }

        private static bool ValidateValueHandle(object value)
        {
            return true;
        }
    }
}