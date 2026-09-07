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

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            #region 写法1
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Items.Add(new ListBoxItem()
            //    {

            //        Content = new TextBlock()
            //        {
            //            Text = i.ToString()
            //        }
            //    });
            //} 
            #endregion

            #region 写法3
            //List<int> datas = new List<int>();
            //for (int i = 0; i < 3; i++) {
            //    datas.Add(i);
            //}

            //List<DataModel> datas = new List<DataModel>()
            //{
            //    new DataModel(){ Name = "Red", Color = Brushes.Red },
            //    new DataModel(){ Name = "Green", Color = Brushes.Green },
            //    new DataModel(){ Name = "Blue", Color = Brushes.Blue },
            //};

            //this.list.ItemsSource = datas;
            #endregion

            #region 写法4

            List<DataModel> datas = new List<DataModel>()
            {
                new DataModel(){ Name = "Red", Color = Brushes.Red },
                new DataModel(){ Name = "Green", Color = Brushes.Green },
                new DataModel(){ Name = "Blue", Color = Brushes.Blue },
            };

            this.grid.ItemsSource = datas;

            #endregion
        }
    }

    public class DataModel
    {
        public string Name { get; set; }

        public Brush Color { get; set; }
    }
}