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
    public class FavoriteViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<Item> Favorites = new ObservableCollection<Item>();

        public ICommand LoadFavoritesCommand { get; }
        public ICommand RemoveFavoriteCommand { get; }

        public ObservableCollection<Item> FavortesItems
        {
            get => Favorites;
            set
            {
                Favorites = value;
                OnPropertyChanged(nameof(FavortesItems));
            }
        }

        public FavoriteViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadFavoritesCommand = CreateAsyncCommand(LoadFavoritesAsync);
            RemoveFavoriteCommand = CreateAsyncCommand(RemoveFavoriteAsync); 

            LoadFavoritesAsync();
        }

        private async Task LoadFavoritesAsync()
        {
            try
            {
                FavortesItems.Clear();

                var carts = await _unitOfWork.Favorites.GetAll();

                var items = carts.Where(c => c.UserId == CurrentUser.UserId).Select(x => x.ItemId).ToList();

                var allItems = await _unitOfWork.Items.GetAll();

                var filteredItems = allItems.Where(item => items.Contains(item.Id)).ToList();

                foreach (var item in filteredItems)
                {
                    if (item.Name != null)
                    {
                        FavortesItems.Add(item);
                    }

                }

                OnPropertyChanged(nameof(FavortesItems));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private async Task RemoveFavoriteAsync(object parameter)
        {
            if (parameter is Item itemToRemove)
            {
                var carts = await _unitOfWork.Favorites.GetAll();

                var cartToRemove = carts.FirstOrDefault(c => c.ItemId == itemToRemove.Id && c.UserId == CurrentUser.UserId);

                if (cartToRemove != null)
                {
                    await _unitOfWork.Favorites.Remove(cartToRemove);

                    FavortesItems.Remove(itemToRemove);

                    await _unitOfWork.CompleteAsync();
                }
            }
        }
    }

}
