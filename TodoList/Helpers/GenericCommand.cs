using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.ViewModels;

namespace TodoList.Helpers
{
    public class GenericCommand : ICommand
    {
        private readonly Action<object> _execute;
        public event EventHandler? CanExecuteChanged;

        public GenericCommand(Action<Object?> executeAction)
        {
            _execute = executeAction;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
