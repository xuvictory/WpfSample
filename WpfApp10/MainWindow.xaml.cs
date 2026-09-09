using CommunityToolkit.Mvvm.Messaging;
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

namespace WpfApp10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window//, IRecipient<MessageModel>
    {
        public MainWindow()
        {
            InitializeComponent();


            MainViewModel_X model = new MainViewModel_X();
            this.DataContext = model;

            WeakReferenceMessenger.Default.Register<MainWindow, MessageModel, string>(this, GlobalToken.MessageToken, (m, n) =>
            {
                MessageBox.Show($"收到：{n.Data}");

            });
        }
    }
}