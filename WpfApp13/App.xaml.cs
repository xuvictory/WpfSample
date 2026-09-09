using System.Configuration;
using System.Data;
using System.Windows;
using WpfApp13.ViewModels;
using WpfApp13.Views;

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TodoListView, TodoListViewModel>();
            containerRegistry.RegisterForNavigation<AddTodoView, AddTodoViewModel>();
            containerRegistry.RegisterForNavigation<AboutView, AboutViewModel>();
        }
    }

}
