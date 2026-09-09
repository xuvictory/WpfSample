using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace WpfApp10
{
    public partial class MainViewModel_S : ObservableRecipient, IRecipient<MessageModel>   //ObservableObject
    {
        public MainViewModel_S()
        {
            //IsActive = true;//自动注册消息

            //Messenger.Register<MainViewModel_S, MessageModel>(this, (r, m) => Receive(m));

            Messenger.Register<MainViewModel_S, MessageModel, string>(this, GlobalToken.MessageToken, (r, m) => Receive(m));
        }

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
            //Messenger.Send(new MessageModel { Data = data });

            Messenger.Send(new MessageModel { Data = data }, GlobalToken.MessageToken);
        }

        public void Receive(MessageModel message)
        {
            MessageBox.Show(message.Data);
        }

    }
}

