using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApp9
{
    public class MyCommand : ICommand
    {
        Action executeAction;

        public MyCommand(Action action)
        {
            executeAction = action;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            executeAction();
        }
    }
}
