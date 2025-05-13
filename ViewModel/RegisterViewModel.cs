using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using OOP_CourseWork.Help;

namespace OOP_CourseWork.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private string _username;
        private string _password;

        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ICommand RegisterCommand { get; }

        public RegisterViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RegisterCommand = CreateAsyncCommand(RegisterAsync, CanRegister);
        }

        private bool CanRegister() =>
            !string.IsNullOrWhiteSpace(Username) &&
            !string.IsNullOrWhiteSpace(Password);

        private async Task RegisterAsync()
        {
            var existing = await _unitOfWork.Users.Find(u => u.Name == Username);
            if (existing.Any())
            {
                MessageBox.Show("Пользователь с таким именем уже существует.");
                return;
            }

            var newUser = new User(Username, HashHelper.Hash(Password));

            await _unitOfWork.Users.Add(newUser);
            await _unitOfWork.CompleteAsync();

            MessageBox.Show("Регистрация успешна!");
        }
    }
}
