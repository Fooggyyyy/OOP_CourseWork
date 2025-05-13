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

namespace OOP_CourseWork.ViewModel
{
    public class HistoryViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservableCollection<History> Historys { get; } = new();

        public ICommand LoadHistoryCommand { get; }
        public ICommand RemoveHistoryCommand { get; }

        public HistoryViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadHistoryCommand = CreateAsyncCommand(LoadHistoryAsync);
        }

        private async Task LoadHistoryAsync()
        {
            Historys.Clear();

            var userId = CurrentUser.UserId;
            var favorites = await _unitOfWork.Histories.Find(f => f.UserId == userId);

            foreach (var fav in favorites)
            {
                Historys.Add(fav);
            }
        }
    }
}
