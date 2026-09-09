using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp10
{
    public partial class MainViewModel_X : ObservableObject
    {
        [ObservableProperty]
        private string _title = "123";

        partial void OnTitleChanging(string value)
        {
            string data = $"OnTitleChanging：value={value}";
            this.SendMessage(data);
        }

        partial void OnTitleChanged(string value)
        {
            string data = $"OnTitleChanged：value={value}";
            this.SendMessage(data);
        }

        partial void OnTitleChanging(string? oldValue, string newValue)
        {
            string data = $"OnTitleChanging：oldValue={oldValue}，newValue={newValue}";
            this.SendMessage(data);
        }

        partial void OnTitleChanged(string? oldValue, string newValue)
        {
            string data = $"OnTitleChanged：oldValue={oldValue}，newValue={newValue}";
            this.SendMessage(data);
        }

        [RelayCommand]
        public void Click()
        {
            this.Title = DateTime.Now.ToString();
        }

        [RelayCommand]
        public void Get()
        {
            this.SendMessage(this.Title);
        }

        private void SendMessage(string data)
        {
            WeakReferenceMessenger.Default.Send(new MessageModel { Data = data }, GlobalToken.MessageToken);
        }
    }
}
