using System;
using System.Windows.Input;

namespace Weater_Application.ViewModels;

public class DeligateCommand : ICommand
{
    private readonly Action<object> _act;

    public DeligateCommand(Action<object> action)
    {
        _act = action;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _act?.Invoke(parameter);
    }
}

