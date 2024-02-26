using System;
using System.Windows.Input;

namespace Explorer.ViewModels;

public partial class MainViewModel
{
    public class DeligateCommand : ICommand
    {
        private readonly Action<object> _open;

        public DeligateCommand(Action<object> open) 
        {
            _open = open;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _open?.Invoke(parameter);
        }
    }

}
