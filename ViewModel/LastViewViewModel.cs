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
    public class LastViewViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<LastView> LastViews { get; } = new();

        public ICommand LoadLastViewCommand { get; }

        public LastViewViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadLastViewCommand = CreateAsyncCommand(LoadLastViewAsync);
        }

        private async Task LoadLastViewAsync()
        {
            LastViews.Clear();

            var userId = CurrentUser.UserId;
            var favorites = await _unitOfWork.LastViews.Find(f => f.UserId == userId);

            foreach (var fav in favorites)
            {
                LastViews.Add(fav);
            }
        }
    }
}
