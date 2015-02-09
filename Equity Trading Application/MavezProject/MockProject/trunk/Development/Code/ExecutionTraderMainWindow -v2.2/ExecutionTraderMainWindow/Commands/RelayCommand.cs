using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ExecutionTraderMainWindow.Commands
{
    public class RelayCommand : ICommand
    {
        readonly Predicate<object> _canExecute;
        readonly Action<object> _execute;

        public RelayCommand(Action<object> execute) : this(null, execute) { }

        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");

            _canExecute = canExecute;
            _execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}

