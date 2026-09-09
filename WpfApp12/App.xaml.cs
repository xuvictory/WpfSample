using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp12.ViewModels;
using WpfApp12.Views;

namespace WpfApp12
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication //Application
    {
        protected override Window CreateShell()
        {
            // 启动时显示MainWindow
            return Container.Resolve<MainRegionView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //// 注册服务
            //containerRegistry.Register<ITodoService, TodoService>();

            //// 注册页面用于导航
            //containerRegistry.RegisterForNavigation<MainWindow>();
            //containerRegistry.RegisterForNavigation<DetailView>();

            containerRegistry.RegisterForNavigation<TodoListView, TodoListViewModel>();
            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();

            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
        }


    }
}
