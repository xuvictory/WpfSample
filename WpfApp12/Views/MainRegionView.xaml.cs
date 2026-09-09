using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp12.Messages;

namespace WpfApp12.Views
{
    /// <summary>
    /// MainRegionView.xaml 的交互逻辑
    /// </summary>
    public partial class MainRegionView : Window
    {
        private readonly IEventAggregator _eventAggregator;
        public MainRegionView(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<MessageEvent>().Subscribe(ToDoEvent);
        }

        private void ToDoEvent(string message)
        {
            MessageBox.Show(message);
        }
    }
}
