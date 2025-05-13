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
    public class FavoriteViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<Favorite> Favorites { get; } = new();

        public ICommand LoadFavoritesCommand { get; }
        public ICommand RemoveFavoriteCommand { get; }

        public FavoriteViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadFavoritesCommand = CreateAsyncCommand(LoadFavoritesAsync);
            RemoveFavoriteCommand = CreateAsyncCommand(RemoveFavoriteAsync); 
        }

        private async Task LoadFavoritesAsync()
        {
            Favorites.Clear();

            var userId = CurrentUser.UserId;
            var favorites = await _unitOfWork.Favorites.Find(f => f.UserId == userId);

            foreach (var fav in favorites)
            {
                Favorites.Add(fav);
            }
        }

        private async Task RemoveFavoriteAsync(object parameter)
        {
            if (parameter is Favorite favorite)
            {
                await _unitOfWork.Favorites.Remove(favorite);
                await _unitOfWork.CompleteAsync();
                Favorites.Remove(favorite);
            }
        }
    }

}
