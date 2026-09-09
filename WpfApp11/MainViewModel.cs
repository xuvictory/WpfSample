using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WpfApp11
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _newTodoTitle = string.Empty;

        [ObservableProperty]
        private ObservableCollection<TodoItem> _todos = new();

        [RelayCommand]
        private void AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoTitle))
            {
                Todos.Add(new TodoItem { Title = NewTodoTitle });
                NewTodoTitle = string.Empty;
            }
        }

        [RelayCommand]
        private void RemoveTodo(TodoItem todo)
        {
            Todos.Remove(todo);
        }

        [RelayCommand]
        public async Task LoadTodosAsync()
        {
            await Task.Delay(1000); // 模拟加载
            Todos.Add(new TodoItem { Title = "学习 MVVM Toolkit", IsCompleted = false });
            Todos.Add(new TodoItem { Title = "写一篇公众号文章", IsCompleted = false });
        }
    }
}
