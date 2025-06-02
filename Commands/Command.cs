using System;
using System.Threading.Tasks;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Func<Task> _asyncExecute;
    private readonly Func<object, Task> _asyncExecuteWithParam;
    private readonly Func<bool> _canExecute;
    private readonly Func<object, bool> _canExecuteWithParam;

    private readonly Action<object> _syncExecuteWithParam;

    private bool _isExecuting;

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public RelayCommand(Func<Task> execute, Func<bool> canExecute = null)
    {
        _asyncExecute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public RelayCommand(Func<object, Task> execute, Func<object, bool> canExecute = null)
    {
        _asyncExecuteWithParam = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecuteWithParam = canExecute;
    }

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _syncExecuteWithParam = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecuteWithParam = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        if (_canExecute != null)
            return !_isExecuting && _canExecute();

        if (_canExecuteWithParam != null)
            return !_isExecuting && _canExecuteWithParam(parameter);

        return !_isExecuting;
    }

    public async void Execute(object parameter)
    {
        if (_asyncExecute != null)
        {
            await ExecuteAsync(_asyncExecute);
        }
        else if (_asyncExecuteWithParam != null)
        {
            await ExecuteAsync(() => _asyncExecuteWithParam(parameter));
        }
        else if (_syncExecuteWithParam != null)
        {
            _syncExecuteWithParam(parameter);
        }
    }

    private async Task ExecuteAsync(Func<Task> execute)
    {
        try
        {
            _isExecuting = true;
            RaiseCanExecuteChanged();
            await execute();
        }
        finally
        {
            _isExecuting = false;
            RaiseCanExecuteChanged();
        }
    }

    public void RaiseCanExecuteChanged() =>
        CommandManager.InvalidateRequerySuggested();
}