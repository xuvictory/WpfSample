using System;
using System.Collections.Generic;
using System.Text;
using WpfApp12.Messages;

namespace WpfApp12.ViewModels
{
    public class MainRegionViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IDialogService _dialogService;

        private DelegateCommand<string> _navigateCommand;

        public MainRegionViewModel(IRegionManager regionManager, IEventAggregator eventAggregator, IDialogService dialogService)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
        }

        public DelegateCommand<string> NavigateCommand =>
            _navigateCommand ??= new DelegateCommand<string>(ExecuteNavigate);

        private void ExecuteNavigate(string viewName)
        {
            _regionManager.RequestNavigate("ContentRegion", viewName);

            //发布消息
            _eventAggregator.GetEvent<MessageEvent>().Publish($"我是：{viewName}");
        }

        private DelegateCommand _showDialogCommand;
        public DelegateCommand ShowDialogCommand =>
            _showDialogCommand ??= new DelegateCommand(ExecuteShowDialog);

        private void ExecuteShowDialog()
        {
            var parameters = new DialogParameters
            {
                { "message", "操作成功！" }
            };
            _dialogService.ShowDialog("NotificationDialog", parameters);
        }
    }
}
