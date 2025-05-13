using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model.CurrentUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OOP_CourseWork.ViewModel
{
    public class BonusViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private int _bonus;
        public int Bonus
        {
            get => _bonus;
            set => Set(ref _bonus, value);
        }

        public ICommand LoadBonusCommand { get; }

        public BonusViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            LoadBonusCommand = CreateAsyncCommand(LoadBonusAsync);
        }

        private async Task LoadBonusAsync()
        {
            var userId = CurrentUser.UserId;
            var user = await _unitOfWork.Users.Get(userId);

            if (user != null)
            {
                Bonus = user.Bonus;
            }
        }
    }
}
