using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Help;
using OOP_CourseWork.Model.CurrentUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using OOP_CourseWork.View;

namespace OOP_CourseWork.ViewModel
{
    public class SignViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private string _username;
        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public ICommand SignInCommand { get; }

        public SignViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            SignInCommand = CreateAsyncCommand(SignInAsync, CanSignIn);
        }

        private bool CanSignIn()
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private async Task SignInAsync()
        {
            var users = await _unitOfWork.Users.Find(u => u.Name == Username);
            var user = users.FirstOrDefault();

            if (user == null || !HashHelper.Verify(Password, user.Password))
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
                return;
            }

            if (user.Block)
            {
                MessageBox.Show("Вы заблокированы");
                return;
            }

            if (Username == "Admin" && Password == "Admin")
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    var adminWindow = new AdminWindow(_unitOfWork);
                    adminWindow.Show();

                    Application.Current.Windows.OfType<SignWindow>().FirstOrDefault()?.Hide();

                });
                return;
            }

            CurrentUser.SetUser(user.Id, user.Bonus); 

            MessageBox.Show($"Добро пожаловать, {user.Name}!");

        }
    }
}
