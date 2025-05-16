using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model.CurrentUser;
using OOP_CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace OOP_CourseWork.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<Item> Orders = new ObservableCollection<Item>();

        public ICommand LoadOrdersCommand { get; }

        public ObservableCollection<Item> OrdersItems
        {
            get => Orders;
            set
            {
                Orders = value;
                OnPropertyChanged(nameof(OrdersItems));
            }
        }

        public OrdersViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadOrdersCommand = CreateAsyncCommand(LoadOrdersAsync);

            LoadOrdersAsync();
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                OrdersItems.Clear();

                var allOrders = await _unitOfWork.Orders.GetAll();
                var userOrders = allOrders
                    .Where(x => x.UserId == CurrentUser.UserId &&
                                (x.Status == Status.Processing || x.Status == Status.Shipped))
                    .ToList();

                var allItems = await _unitOfWork.Items.GetAll();

                var itemWithStatusList = userOrders
                    .Join(allItems,
                          order => order.ItemId,
                          item => item.Id,
                          (order, item) => new
                          {
                              item.PhotoPath,
                              item.Name,
                              item.Price,
                              item.Size,
                              order.Status
                          })
                    .ToList();

                foreach (var x in itemWithStatusList)
                {
                    OrdersItems.Add(new Item
                    {
                        Name = $"{x.Name} ({x.Status})",
                        PhotoPath = x.PhotoPath,
                        Price = x.Price,
                        Size = x.Size
                    });
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
