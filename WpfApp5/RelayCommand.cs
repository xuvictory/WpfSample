using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfApp5
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _canExecute;
        private readonly Action _execute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }


        public event EventHandler? CanExecuteChanged
        {
            add 
            {
                if(_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove 
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public bool CanExecute(object? parameter)
        {
            if(_canExecute != null)
            {
                return _canExecute();
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if(_execute != null)
                _execute();
        }
    }
}
