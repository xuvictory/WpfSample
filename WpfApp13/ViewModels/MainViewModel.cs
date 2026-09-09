using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp13.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private DelegateCommand<string> _navigateCommand;

        public MainViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            // 默认显示待办列表
            _regionManager.RequestNavigate("ContentRegion", "TodoListView");
        }

        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ??= new DelegateCommand<string>(ExecuteNavigate);

        private void ExecuteNavigate(string viewName)
        {
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }
    }
}
