using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using OOP_CourseWork.Model.CurrentUser;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

public class PaymentViewModel : ViewModelBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ObservableCollection<Item> CartItems { get; } = new();
    public ICommand PayCommand { get; }
    public ICommand LoadPaymentDataCommand { get; }

    private bool _useBonus;
    public bool UseBonus
    {
        get => _useBonus;
        set
        {
            _useBonus = value;
            OnPropertyChanged(nameof(UseBonus));
            OnPropertyChanged(nameof(TotalPrice));
        }
    }

    public int RawTotalPrice => CartItems.Sum(i => i.Price);

    public int TotalPrice
    {
        get
        {
            if (!UseBonus)
                return RawTotalPrice;

            if (RawTotalPrice < 10000 || CurrentUser.Bonus == 0)
                return RawTotalPrice;

            int maxBonuses = Math.Min(CurrentUser.Bonus, 10);
            double discount = 0.05 * maxBonuses; 
            return (int)(RawTotalPrice * (1 - discount));
        }
    }

    public PaymentViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        LoadPaymentDataCommand = CreateAsyncCommand(LoadDataAsync);
        PayCommand = CreateAsyncCommand(ExecutePaymentAsync);

        LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        CartItems.Clear();
        var carts = await _unitOfWork.Carts.GetAll();
        var items = carts
            .Where(c => c.UserId == CurrentUser.UserId)
            .Select(c => c.Item)
            .ToList();

        foreach (var item in items)
            CartItems.Add(item);

        OnPropertyChanged(nameof(TotalPrice));
    }

    private async Task ExecutePaymentAsync(object? obj)
    {
        if (CartItems.Count == 0)
        {
            MessageBox.Show("Корзина пуста");
            return;
        }

        int rawTotal = RawTotalPrice;
        int userBonus = CurrentUser.Bonus;

        var users = await _unitOfWork.Users.Find(x => x.Id == CurrentUser.UserId);
        var user = users.FirstOrDefault();
        if (user == null)
        {
            MessageBox.Show("Пользователь не найден");
            return;
        }

        foreach (var item in CartItems)
        {
            var order = new Order
            {
                UserId = CurrentUser.UserId,
                ItemId = item.Id,
                Price = item.Price,
                ActiveBonus = UseBonus,
                Status = Status.Processing
            };
            await _unitOfWork.Orders.Add(order);
        }

        if (UseBonus && rawTotal >= 10000 && userBonus > 0)
        {
            int bonusesUsed = Math.Min(userBonus, 10);
            user.Bonus -= bonusesUsed;
        }
        else if (!UseBonus && rawTotal >= 8000)
        {
            int extra = rawTotal - 8000;
            int bonusEarned = extra / 500;
            user.Bonus += bonusEarned;
        }

        await _unitOfWork.Users.Update(user);

        var allCarts = await _unitOfWork.Carts.GetAll();
        var userCarts = allCarts.Where(c => c.UserId == CurrentUser.UserId).ToList();
        foreach (var cart in userCarts)
        {
            await _unitOfWork.Carts.Remove(cart);
        }

        await _unitOfWork.CompleteAsync();

        CurrentUser.Bonus = user.Bonus;
        CartItems.Clear();
        OnPropertyChanged(nameof(TotalPrice));

        MessageBox.Show("Оплата прошла успешно");
    }
}
