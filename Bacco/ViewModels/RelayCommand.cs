using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private Action<object> execute;
    private Func<object, bool> canExecute;

    public RelayCommand(Action<object> exec, Func<object, bool> canExec = null)
    {
        execute = exec;
        canExecute = canExec;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter) => canExecute == null || canExecute(parameter);

    public void Execute(object parameter) => execute(parameter);
}
