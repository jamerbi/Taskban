using System;
using System.Windows.Input;

namespace Taskban.WPF.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _executeAction;

        private readonly Func<object, bool> _canExecuteFunc;

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            _executeAction = executeAction;
            _canExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteFunc.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}