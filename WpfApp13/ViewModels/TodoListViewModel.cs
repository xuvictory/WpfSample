using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using WpfApp13.Events;
using WpfApp13.Models;

namespace WpfApp13.ViewModels
{
    public class TodoListViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private ObservableCollection<TodoItem> _todos = new();
        private DelegateCommand<TodoItem> _removeTodoCommand;

        public TodoListViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<TodoAddedEvent>().Subscribe(OnTodoAdded);
            _eventAggregator.GetEvent<TodoRemovedEvent>().Subscribe(OnTodoRemoved);
            LoadSampleData();
        }

        public ObservableCollection<TodoItem> Todos
        {
            get => _todos;
            set => SetProperty(ref _todos, value);
        }

        public string StatsText => $"总计：{Todos.Count} 项，已完成：{Todos.Count(t => t.IsCompleted)} 项";

        public DelegateCommand<TodoItem> RemoveTodoCommand =>
            _removeTodoCommand ??= new DelegateCommand<TodoItem>(ExecuteRemoveTodo);

        private void ExecuteRemoveTodo(TodoItem todo)
        {
            if (todo == null) return;

            // 弹窗确认
            var result = MessageBox.Show($"确定要删除“{todo.Title}”吗？", "确认删除", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;

            Todos.Remove(todo);
            _eventAggregator.GetEvent<TodoRemovedEvent>().Publish(todo);
            RaisePropertyChanged(nameof(StatsText));
        }

        private void OnTodoAdded(TodoItem todo)
        {
            Todos.Add(todo);
            // 订阅该待办项的属性变更，以便更新统计
            todo.PropertyChanged += OnTodoPropertyChanged;
            RaisePropertyChanged(nameof(StatsText));
        }

        private void OnTodoRemoved(TodoItem todo)
        {
            // 取消订阅
            if (todo != null)
                todo.PropertyChanged -= OnTodoPropertyChanged;
            RaisePropertyChanged(nameof(StatsText));
        }

        private void OnTodoPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TodoItem.IsCompleted))
                RaisePropertyChanged(nameof(StatsText));
        }

        private void LoadSampleData()
        {
            var items = new[]
            {
                new TodoItem { Title = "学习Prism框架", IsCompleted = false },
                new TodoItem { Title = "写一篇Prism教程", IsCompleted = false },
                new TodoItem { Title = "完成待办事项应用", IsCompleted = true }
            };
            foreach (var item in items)
            {
                Todos.Add(item);
                item.PropertyChanged += OnTodoPropertyChanged;
            }
        }
    }
}
