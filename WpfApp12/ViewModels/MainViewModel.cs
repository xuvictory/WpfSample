using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfApp12.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string title="hello";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value);}
        }


        public MainViewModel()
        {
            GetCommand = new DelegateCommand(() => 
            {
                MessageBox.Show(Title);
            }, 
            () => { return true; });

            ClickCommand = new AsyncDelegateCommand(LoadDataAsync, () => { return true; }).Catch(ex => {

                // 处理其他任何异常

                

            });
        }

        public DelegateCommand GetCommand { get; }

        public AsyncDelegateCommand ClickCommand { get; }

        private async Task LoadDataAsync()
        {
            Title = DateTime.Now.ToString();

            // 耗时操作，界面不会卡顿
            await Task.Delay(2000);
            // 加载完成后按钮自动恢复可用

            
        }
    }
}
