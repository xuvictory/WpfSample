using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp13.Models
{
    public class TodoItem : BindableBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private bool isCompleted;

        public bool IsCompleted
        {
            get { return isCompleted; }
            set { SetProperty(ref isCompleted, value); }
        }

    }
}
