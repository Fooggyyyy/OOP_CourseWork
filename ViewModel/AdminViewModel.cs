using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

public class AdminViewModel : ViewModelBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ObservableCollection<Item> Items { get; } = new();
    public ObservableCollection<User> Users { get; } = new();

    public ICommand AddItem { get; }
    public ICommand DeleteItem { get; }
    public ICommand UpdateItem { get; }
    public ICommand DeleteUser { get; }
    public ICommand LoadAdminDataCommand { get; }

    private Item _selectedItem;

    public Item SelectedItem
    {
        get => _selectedItem;
        set
        {
            _selectedItem = value;
            OnPropertyChanged(nameof(SelectedItem));
        }
    }

    private User _selectedUser;

    public User SelectedUser
    {
        get => _selectedUser;
        set
        {
            _selectedUser = value;
            OnPropertyChanged(nameof(SelectedUser));
        }
    }


    public AdminViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        LoadAdminDataCommand = CreateAsyncCommand(LoadDataAsync);
        AddItem = CreateAsyncCommand(AddItemAsync);
        DeleteItem = CreateAsyncCommand(DeleteItemAsync);
        UpdateItem = CreateAsyncCommand(UpdateItemAsync);
        DeleteUser = CreateAsyncCommand(DeleteUserAsync);

        LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        Items.Clear();
        var items = await _unitOfWork.Items.GetAll();
        foreach (var item in items)
            Items.Add(item);

        Users.Clear();
        var users = await _unitOfWork.Users.GetAll();
        foreach (var user in users)
            Users.Add(user);
    }

    private async Task AddItemAsync(object parameter)
    {
        if (parameter is not Item item)
        {
            MessageBox.Show("No item selected");
            return;
        }

        await _unitOfWork.Items.Add(item);
        await _unitOfWork.CompleteAsync();
        Items.Add(item);
    }

    private async Task DeleteItemAsync(object parameter)
    {
        if (parameter is not Item item)
        {
            MessageBox.Show("No item selected");
            return;
        }

        await _unitOfWork.Items.Remove(item);
        await _unitOfWork.CompleteAsync();
        Items.Remove(item);
    }

    private async Task UpdateItemAsync(object parameter)
    {
        if (parameter is not Item item)
        {
            MessageBox.Show("No item selected");
            return;
        }

        MessageBox.Show("Выполняется");
        await _unitOfWork.Items.Update(item);
        await _unitOfWork.CompleteAsync();
    }

    private async Task DeleteUserAsync(object parameter)
    {

        if (parameter is not User user)
        {
            MessageBox.Show("Нет");
            return;
        }

            MessageBox.Show("Выполняется");
        await _unitOfWork.Users.Remove(user);
        await _unitOfWork.CompleteAsync();
        Users.Remove(user);
    }
}

public static class SizeEnum
{
    public static Array Values => Enum.GetValues(typeof(OOP_CourseWork.Model.Size));
}
public static class ColorEnum
{
    public static Array Values => Enum.GetValues(typeof(Color));
}
public static class TypeWearEnum
{
    public static Array Values => Enum.GetValues(typeof(TypeWear));
}
