using Microsoft.EntityFrameworkCore;
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
    public ICommand ChangeOrderStatusCommand { get; }
    public ICommand OnBlockUser1 {  get; }

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

    public ObservableCollection<Order> Orders { get; } = new();

    private Order _selectedOrder;
    public Order SelectedOrder
    {
        get => _selectedOrder;
        set
        {
            _selectedOrder = value;
            OnPropertyChanged(nameof(SelectedOrder));
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
        ChangeOrderStatusCommand = CreateAsyncCommand(ChangeOrderStatusAsync);
        OnBlockUser1 = CreateAsyncCommand(OnBlockUser);

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

        Orders.Clear();
        var orders = await _unitOfWork.Orders.GetAll();
        foreach (var order in orders)
            Orders.Add(order);

    }

    private async Task AddItemAsync(object parameter)
    {
        if (parameter is not Item item)
        {
            MessageBox.Show("Не выбран товар");
            return;
        }

        // Проверка заполнения всех полей
        if (string.IsNullOrWhiteSpace(item.Name))
        {
            MessageBox.Show("Название товара не может быть пустым");
            return;
        }

        if (item.Price <= 0)
        {
            MessageBox.Show("Цена должна быть больше 0");
            return;
        }

        if (string.IsNullOrWhiteSpace(item.Description))
        {
            MessageBox.Show("Описание товара не может быть пустым");
            return;
        }

        if (string.IsNullOrWhiteSpace(item.PhotoPath))
        {
            MessageBox.Show("Не указан путь к изображению");
            return;
        }

        // Проверка enum-полей (хотя они всегда имеют значение по умолчанию)
        if (!Enum.IsDefined(typeof(OOP_CourseWork.Model.Size), item.Size))
        {
            MessageBox.Show("Указан недопустимый размер");
            return;
        }

        if (!Enum.IsDefined(typeof(Color), item.Color))
        {
            MessageBox.Show("Указан недопустимый цвет");
            return;
        }

        if (!Enum.IsDefined(typeof(TypeWear), item.Type))
        {
            MessageBox.Show("Указан недопустимый тип одежды");
            return;
        }

        try
        {
            await _unitOfWork.Items.Add(item);
            await _unitOfWork.CompleteAsync();
            Items.Add(item);
            MessageBox.Show("Товар успешно добавлен");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
        }
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
            MessageBox.Show("Не выбран товар для обновления");
            return;
        }

        // Те же проверки, что и для добавления
        if (string.IsNullOrWhiteSpace(item.Name))
        {
            MessageBox.Show("Название товара не может быть пустым");
            return;
        }

        if (item.Price <= 0)
        {
            MessageBox.Show("Цена должна быть больше 0");
            return;
        }

        if (string.IsNullOrWhiteSpace(item.Description))
        {
            MessageBox.Show("Описание товара не может быть пустым");
            return;
        }

        if (string.IsNullOrWhiteSpace(item.PhotoPath))
        {
            MessageBox.Show("Не указан путь к изображению");
            return;
        }

        if (!Enum.IsDefined(typeof(OOP_CourseWork.Model.Size), item.Size))
        {
            MessageBox.Show("Указан недопустимый размер");
            return;
        }

        if (!Enum.IsDefined(typeof(Color), item.Color))
        {
            MessageBox.Show("Указан недопустимый цвет");
            return;
        }

        if (!Enum.IsDefined(typeof(TypeWear), item.Type))
        {
            MessageBox.Show("Указан недопустимый тип одежды");
            return;
        }

        try
        {
            await _unitOfWork.Items.Update(item);
            await _unitOfWork.CompleteAsync();
            MessageBox.Show("Товар успешно обновлен");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при обновлении товара: {ex.Message}");
        }
    }

    private async Task DeleteUserAsync(object parameter)
    {
        try
        {
            if (parameter is not User user)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }

            user.Block = true; // помечаем как заблокированного
            _unitOfWork.Users.Update(user); // обновляем пользователя
            await _unitOfWork.CompleteAsync();

            MessageBox.Show("Пользователь успешно заблокирован.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}\n\n{ex.InnerException?.Message}");
        }
    }

    private async Task OnBlockUser(object parameter)
    {
        try
        {
            if (parameter is not User user)
            {
                MessageBox.Show("Пользователь не найден.");
                return;
            }

            user.Block = false; // помечаем как заблокированного
            _unitOfWork.Users.Update(user); // обновляем пользователя
            await _unitOfWork.CompleteAsync();

            MessageBox.Show("Пользователь успешно заблокирован.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}\n\n{ex.InnerException?.Message}");
        }
    }

    private async Task ChangeOrderStatusAsync(object parameter)
    {
        if (SelectedOrder == null)
        {
            MessageBox.Show("Выберите заказ для изменения статуса.");
            return;
        }

        SelectedOrder.Status = SelectedOrder.Status switch
        {
            Status.Processing => Status.Shipped,
            Status.Shipped => Status.Delivered,
            Status.Delivered => Status.Delivered,
            _ => SelectedOrder.Status
        };

        await _unitOfWork.Orders.Update(SelectedOrder);
        await _unitOfWork.CompleteAsync();

        OnPropertyChanged(nameof(Orders));
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
