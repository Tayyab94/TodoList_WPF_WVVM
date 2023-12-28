using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.ViewModels;

namespace TodoList.Helpers
{
    public class AddCommand : ICommand
    {
        private readonly TodoViewModel _todoViewModel;
        public event EventHandler? CanExecuteChanged;

        public AddCommand(TodoViewModel vm)
        {
            this._todoViewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            this._todoViewModel.AddTodo();
        }
    }
}
