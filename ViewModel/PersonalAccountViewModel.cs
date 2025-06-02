using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using System.Linq;
using OOP_CourseWork.Model;
using System.Threading.Tasks;
using System.Windows;
using OOP_CourseWork.Model.CurrentUser;

namespace OOP_CourseWork.ViewModel
{
    public class PersonalAccountViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private string _userName;
        private int _bonus;
        private string _selectedTheme;
        private string _selectedLanguage;
        private User _currentUser;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public int Bonus
        {
            get => _bonus;
            set
            {
                _bonus = value;
                OnPropertyChanged();
            }
        }

        public string SelectedTheme
        {
            get => _selectedTheme;
            set
            {
                if (_selectedTheme != value)
                {
                    _selectedTheme = value;
                    ThemeManager.Instance.SetTheme(value);
                    OnPropertyChanged();
                }
            }
        }

        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    // Здесь будет реализация смены языка
                    OnPropertyChanged();
                }
            }
        }

        public List<string> AvailableThemes => ThemeManager.Instance.GetAvailableThemes();

        public List<string> AvailableLanguages => new List<string> { "English", "Русский" };

        public ICommand SaveChangesCommand { get; }
        public ICommand LoadDataCommand { get; }

        public PersonalAccountViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            SaveChangesCommand = CreateAsyncCommand(SaveChangesAsync);
            LoadDataCommand = CreateAsyncCommand(LoadDataAsync);
            
            // Установка темы и языка по умолчанию
            _selectedTheme = "Optimistic";
            _selectedLanguage = "Русский";

            // Загрузка данных
            LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                if (!CurrentUser.IsLoggedIn)
                {
                    MessageBox.Show("Пожалуйста, войдите в систему");
                    return;
                }

                var users = await _unitOfWork.Users.GetAll();
                _currentUser = users.FirstOrDefault(u => u.Id == CurrentUser.UserId);

                if (_currentUser != null)
                {
                    UserName = _currentUser.Name;
                    Bonus = _currentUser.Bonus;
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private async Task SaveChangesAsync()
        {
            try
            {
                if (_currentUser == null)
                {
                    MessageBox.Show("Пользователь не найден");
                    return;
                }

                _currentUser.Name = UserName;
                _currentUser.Bonus = Bonus;

                await _unitOfWork.Users.Update(_currentUser);
                await _unitOfWork.CompleteAsync();

                // Обновляем данные в CurrentUser
                CurrentUser.SetUser(_currentUser.Id, _currentUser.Bonus);

                MessageBox.Show("Изменения сохранены успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}");
            }
        }
    }
} 