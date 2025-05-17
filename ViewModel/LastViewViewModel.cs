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
    public class LastViewViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private ObservableCollection<Item> _LastViewItems = new ObservableCollection<Item>();

        public ICommand LoadLastViewCommand { get; }

        public LastViewViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadLastViewCommand = CreateAsyncCommand(LoadLastViewAsync);

            LoadLastViewCommand.Execute(null);
        }

        public ObservableCollection<Item> LastViewItems
        {
            get => _LastViewItems;
            set
            {
                _LastViewItems = value;
                OnPropertyChanged(nameof(LastViewItems));
            }
        }

        private async Task LoadLastViewAsync()
        {
            _LastViewItems.Clear();

            var lastViews = (await _unitOfWork.LastViews.GetAll())
                .Where(c => c.UserId == CurrentUser.UserId)
                .OrderByDescending(c => c.TimeView) 
                .Take(5)
                .ToList();

            var allItems = await _unitOfWork.Items.GetAll();

            var filteredItems = lastViews
                .Select(view => allItems.FirstOrDefault(item => item.Id == view.ItemId))
                .Where(item => item != null && item.Name != null)
                .ToList();

            foreach (var item in filteredItems)
            {
                _LastViewItems.Add(item);
            }

            OnPropertyChanged(nameof(LastViewItems));

        }
    }
}
