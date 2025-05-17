using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OOP_CourseWork.ViewModel
{
    public class ContactViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;

        private string _name;
        private string _email;
        private string _description;

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string Description
        {
            get => _description;
            set { _description = value; OnPropertyChanged(nameof(Description)); }
        }

        public ICommand SubmitContactCommand { get; }

        public ObservableCollection<Contact> SentContacts { get; set; } = new ObservableCollection<Contact>();

        public ContactViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            SubmitContactCommand = CreateAsyncCommand(SubmitContactAsync);
        }

        private async Task SubmitContactAsync()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Description))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            try
            {
                var contact = new Contact
                {
                    Name = Name,
                    Email = Email,
                    Description = Description
                };

                await _unitOfWork.Contacts.Add(contact); 
                await _unitOfWork.CompleteAsync();

                SentContacts.Add(contact);

                Name = string.Empty;
                Email = string.Empty;
                Description = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отправке: {ex.Message}");
            }
        }
    }
}
