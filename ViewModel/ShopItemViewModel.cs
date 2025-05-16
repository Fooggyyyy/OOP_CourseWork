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

        private string _newCommentText;
        public string NewCommentText
        {
            get => _newCommentText;
            set
            {
                _newCommentText = value;
                OnPropertyChanged();
            }
        }

        private int _newCommentRating = 1; 
        public int NewCommentRating
        {
            get => _newCommentRating;
            set
            {
                if (value < 1) value = 1;
                if (value > 5) value = 5;
                _newCommentRating = value;
                OnPropertyChanged();
            }
        }
        public Action? CloseAction { get; set; }

        public ICommand AddCommentCommand { get; }
        public ICommand BackToShopCommand { get; }

        public ICommand LoadItemCommand { get; }
        public ICommand LoadCommentsCommand { get; }
        public ICommand AddToCartCommand { get; }
        public ICommand AddToFavoriteCommand { get; }

        public ShopItemViewModel(IUnitOfWork unitOfWork,Item selectedItem)
        {
            _unitOfWork = unitOfWork;
            SelectedItem = selectedItem;
            LoadItemCommand = CreateAsyncCommand(LoadItemAsync);
            LoadCommentsCommand = CreateAsyncCommand(LoadCommentAsync);
            AddToCartCommand = CreateAsyncCommand(AddToCartAsync);
            AddToFavoriteCommand = CreateAsyncCommand(AddToFavoriteAsync);
            AddCommentCommand = CreateAsyncCommand(AddCommentAsync);
            BackToShopCommand =  CreateAsyncCommand(BackToShop);
        }

        public async Task InitializeAsync()
        {
            await LoadItemAsync();
            await LoadCommentAsync();
        }

        private async Task BackToShop()
        {
            var currentWindow = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.DataContext == this);


            var mainWindow = Application.Current.Windows.OfType<ShopMainWindow>().FirstOrDefault();

            if (mainWindow != null)
            {
                mainWindow.DataContext = new ShopMainViewModel(_unitOfWork);
                mainWindow.Title = "Магазин";
            }

            // Назначаем основное окно, чтобы закрытие текущего не завершило приложение
            Application.Current.MainWindow = mainWindow;


                mainWindow?.Show();
                currentWindow?.Hide();
            


        }
        private async Task LoadItemAsync()
        {
            Items.Clear();

            if (SelectedItem == null)
            {
                MessageBox.Show("SelectedItem == null, загрузка невозможна");
                return;
            }


            if (_unitOfWork.LastViews == null)
            {
                MessageBox.Show("LastViews репозиторий не инициализирован");
                return;
            }

            var itemId = CurrentItem.ItemId;

            try
            {
                if (CurrentUser.UserId != 0)
                {
                    var lastview = new LastView
                    {
                        UserId = CurrentUser.UserId,
                        ItemId = SelectedItem.Id,
                        TimeView = DateTime.Now
                    };
                    await _unitOfWork.LastViews.Add(lastview);
                    await _unitOfWork.CompleteAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении LastView: {ex.Message}");
                return;
            }

            var favorites = await _unitOfWork.Items.Find(f => f.Id == itemId);

            foreach (var fav in favorites)
            {
                Items.Add(fav);
            }
        }

        private async Task LoadCommentAsync()
        {
            Comments.Clear();

            var itemId = SelectedItem?.Id ?? 0;
            var favorites = await _unitOfWork.Comments.Find(f => f.ItemId == itemId);


            if (itemId == 0)
            {
                MessageBox.Show("SelectedItem не установлен, невозможно загрузить комментарии");
                return;
            }

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

        private async Task AddToFavoriteAsync()
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

            var existing = await _unitOfWork.Favorites.Find(c => c.UserId == userId && c.ItemId == itemId);
            if (existing.Any())
            {
                MessageBox.Show("Этот товар уже в избранном.");
            }

            var cartItem = new Favorite
            {
                UserId = userId,
                ItemId = itemId
            };

            await _unitOfWork.Favorites.Add(cartItem);
            await _unitOfWork.CompleteAsync();

        }

        private async Task UpdateItemRatingAsync(int itemId)
        {
            var comments = await _unitOfWork.Comments.Find(c => c.ItemId == itemId);
            if (comments.Any())
            {
                // Средний рейтинг
                double avgRating = comments.Average(c => c.Rating);
                // Загружаем сам товар
                var items = await _unitOfWork.Items.Find(i => i.Id == itemId);
                var item = items.FirstOrDefault();
                if (item != null)
                {
                    item.Rating = avgRating;
                    // Обновляем товар в базе
                    _unitOfWork.Items.Update(item);
                    await _unitOfWork.CompleteAsync();

                    // Обновляем выбранный элемент в VM, чтобы UI обновился
                    SelectedItem.Rating = avgRating;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private async Task AddCommentAsync()
        {
            if (string.IsNullOrWhiteSpace(NewCommentText))
            {
                MessageBox.Show("Комментарий не может быть пустым.");
                return;
            }

            if (NewCommentRating < 1 || NewCommentRating > 5)
            {
                MessageBox.Show("Рейтинг должен быть от 1 до 5.");
                return;
            }

            if (CurrentUser.UserId == 0)
            {
                MessageBox.Show("Только авторизованные пользователи могут оставлять комментарии.");
                return;
            }

            var comment = new Comment
            {
                Description = NewCommentText,
                UserId = CurrentUser.UserId,
                ItemId = SelectedItem.Id,
                Rating = NewCommentRating
            };

            await _unitOfWork.Comments.Add(comment);
            await _unitOfWork.CompleteAsync();

            // Обновляем рейтинг товара после добавления комментария
            await UpdateItemRatingAsync(SelectedItem.Id);

            NewCommentText = string.Empty;
            NewCommentRating = 1; // сброс рейтинга
            await LoadCommentAsync(); // Обновим список комментариев
        }

    }
}
