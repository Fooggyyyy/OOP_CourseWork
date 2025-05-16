using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model.CurrentUser;
using OOP_CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows;

namespace OOP_CourseWork.ViewModel
{
    public class HistoryViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<Item> Orders = new ObservableCollection<Item>();

        public ICommand LoadHistoryCommand { get; }

        public ObservableCollection<Item> OrdersItems
        {
            get => Orders;
            set
            {
                Orders = value;
                OnPropertyChanged(nameof(OrdersItems));
            }
        }

        public HistoryViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadHistoryCommand = CreateAsyncCommand(LoadHistoryAsync);

            LoadHistoryAsync();
        }

        private async Task LoadHistoryAsync()
        {
            try
            {
                OrdersItems.Clear();

                var cart = await _unitOfWork.Orders.GetAll();
                var carts = cart.Where(x => x.Status == Status.Delivered).ToList();

                var items = carts.Where(c => c.UserId == CurrentUser.UserId).Select(x => x.ItemId).ToList();

                var allItems = await _unitOfWork.Items.GetAll();

                var filteredItems = allItems.Where(item => items.Contains(item.Id)).ToList();

                foreach (var item in filteredItems)
                {
                    if (item.Name != null)
                    {
                        OrdersItems.Add(item);
                    }

                }

                OnPropertyChanged(nameof(OrdersItems));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
