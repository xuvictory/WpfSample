using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using Prism.Commands;

namespace WpfApp12.ViewModels
{
    public class NotificationDialogViewModel : BindableBase, IDialogAware
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private DelegateCommand _closeCommand;

        public DelegateCommand CloseCommand =>
            _closeCommand ??= new DelegateCommand(() =>
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK)));

        public string Title => "提示";

        DialogCloseListener IDialogAware.RequestClose => throw new NotImplementedException();

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
        }
    }
}
