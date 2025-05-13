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
using System.Windows.Navigation;
using OOP_CourseWork.View;
using System.Windows;

namespace OOP_CourseWork.ViewModel
{
    public class ShopItemViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<Item> Items { get; } = new();
        public ObservableCollection<Comment> Comments { get; } = new();

        private Item _selectedItem;
        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(); 
            }
        }

        public ICommand LoadItemCommand { get; }
        public ICommand LoadCommentsCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand NavigateToSizeHelpCommand { get; }

        public ShopItemViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadItemCommand = CreateAsyncCommand(LoadItemAsync);
            LoadCommentsCommand = CreateAsyncCommand(LoadCommentAsync);
            AddToCartCommand = CreateAsyncCommand(AddToCartAsync);
            NavigateToSizeHelpCommand = CreateCommand(NavigateToSizeHelp);
        }

        private async Task LoadItemAsync()
        {
            Items.Clear();

            var itemId = CurrentItem.ItemId;
            var favorites = await _unitOfWork.Items.Find(f => f.Id == itemId);

            foreach (var fav in favorites)
            {
                Items.Add(fav);
            }
        }

        private async Task LoadCommentAsync()
        {
            Comments.Clear();

            var itemId = CurrentItem.ItemId;
            var favorites = await _unitOfWork.Comments.Find(f => f.ItemId == itemId);

            foreach (var fav in favorites)
            {
                Comments.Add(fav);
            }
        }

        private async Task AddToCartAsync()
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Товар не выбран.");
                return;
            }

            if (CurrentUser.UserId == 0)
            {
                MessageBox.Show("Вы не авторизованы.");
                return;
            }

            var userId = CurrentUser.UserId;
            var itemId = SelectedItem.Id;

            var existing = await _unitOfWork.Carts.Find(c => c.UserId == userId && c.ItemId == itemId);
            if (existing.Any())
            {
                MessageBox.Show("Этот товар уже в корзине.");
            }

            var cartItem = new Cart
            {
                UserId = userId,
                ItemId = itemId
            };

            await _unitOfWork.Carts.Add(cartItem);
            await _unitOfWork.CompleteAsync();

        }

        private void NavigateToSizeHelp(object parameter)
        {
            if (parameter is Item item)
            {
                CurrentItem.ItemId = item.Id;

                var itemWindow = new SizeHelpWindow();
                itemWindow.Show();
            }
        }
    }
}
