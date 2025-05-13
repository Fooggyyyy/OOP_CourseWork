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

namespace OOP_CourseWork.ViewModel
{
    public class OrdersViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<Order> Orders { get; } = new();

        public ICommand LoadOrdersCommand { get; }

        public OrdersViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadOrdersCommand = CreateAsyncCommand(LoadOrdersAsync);
        }

        private async Task LoadOrdersAsync()
        {
            Orders.Clear();

            var userId = CurrentUser.UserId;
            var favorites = await _unitOfWork.Orders.Find(f => f.UserId == userId);

            foreach (var fav in favorites)
            {
                Orders.Add(fav);
            }
        }
    }
}
