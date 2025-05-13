using Microsoft.Extensions.Logging;
using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using OOP_CourseWork.Model.CurrentUser;
using OOP_CourseWork.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace OOP_CourseWork.ViewModel
{
    public class ShopMainViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<Item> Items { get; } = new();

        public Size? SelectedSize { get; set; }
        public Color? SelectedColor { get; set; }
        public TypeWear? SelectedType { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public double? MinRating { get; set; }

        public ICommand LoadAllItemsCommand { get; }
        public ICommand OpenItemPageCommand { get; }
        public ICommand ApplyFilterCommand { get; }

        public ShopMainViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            LoadAllItemsCommand = CreateAsyncCommand(LoadAllItemsAsync);
            OpenItemPageCommand = CreateCommand(OpenItemPage);
            ApplyFilterCommand = CreateAsyncCommand(ApplyFilterAsync);

            LoadAllItemsCommand.Execute(null);
        }

        private async Task LoadAllItemsAsync()
        {
            Items.Clear();
            var allItems = await _unitOfWork.Items.GetAll();
            foreach (var item in allItems)
                Items.Add(item);
        }

        private void OpenItemPage(object parameter)
        {
            if (parameter is Item item)
            {
                var window = new ShopItemWindow(_unitOfWork, item);
                var viewModel = (ShopItemViewModel)window.DataContext;
                viewModel.SelectedItem = item;
                window.Show();
            }
        }
        private async Task ApplyFilterAsync()
        {
            var filteredItems = await _unitOfWork.Items.GetAll();

            if (SelectedSize.HasValue)
                filteredItems = filteredItems.Where(item => item.Size == SelectedSize.Value).ToList();

            if (SelectedColor.HasValue)
                filteredItems = filteredItems.Where(item => item.Color == SelectedColor.Value).ToList();

            if (SelectedType.HasValue)
                filteredItems = filteredItems.Where(item => item.Type == SelectedType.Value).ToList();

            if (MinPrice.HasValue)
                filteredItems = filteredItems.Where(item => item.Price >= MinPrice.Value).ToList();

            if (MaxPrice.HasValue)
                filteredItems = filteredItems.Where(item => item.Price <= MaxPrice.Value).ToList();

            if (MinRating.HasValue)
                filteredItems = filteredItems.Where(item => item.Rating >= MinRating.Value).ToList();

            Items.Clear();
            foreach (var item in filteredItems)
                Items.Add(item);
        }

    }

    public static class SizeEnum
    {
        public static Array Values => Enum.GetValues(typeof(Size));
    }
    public static class ColorEnum
    {
        public static Array Values => Enum.GetValues(typeof(Color));
    }
    public static class TypeWearEnum
    {
        public static Array Values => Enum.GetValues(typeof(TypeWear));
    }
}
