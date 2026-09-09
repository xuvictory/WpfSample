using System;
using System.Collections.Generic;
using System.Text;
using WpfApp13.Events;
using WpfApp13.Models;

namespace WpfApp13.ViewModels
{
    public class AddTodoViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private string _newTodoTitle;
        private string _message;
        private DelegateCommand _addTodoCommand;

        public AddTodoViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public string NewTodoTitle
        {
            get => _newTodoTitle;
            set => SetProperty(ref _newTodoTitle, value);
        }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand AddTodoCommand =>
            _addTodoCommand ??= new DelegateCommand(ExecuteAddTodo, CanAddTodo)
                .ObservesProperty(() => NewTodoTitle);

        private void ExecuteAddTodo()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoTitle))
            {
                var todo = new TodoItem { Title = NewTodoTitle, IsCompleted = false };
                _eventAggregator.GetEvent<TodoAddedEvent>().Publish(todo);
                Message = $"✅ 已添加：{NewTodoTitle}";
                NewTodoTitle = string.Empty;
            }
        }

        private bool CanAddTodo()
        {
            return !string.IsNullOrWhiteSpace(NewTodoTitle);
        }
    }
}
