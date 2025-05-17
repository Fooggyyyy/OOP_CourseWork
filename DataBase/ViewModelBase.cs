using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    protected ICommand CreateAsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        => new RelayCommand(execute, canExecute);

    protected ICommand CreateAsyncCommand(Func<object, Task> execute, Func<object, bool> canExecute = null)
        => new RelayCommand(execute, canExecute);

    protected ICommand CreateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        => new RelayCommand(execute, canExecute);
}
