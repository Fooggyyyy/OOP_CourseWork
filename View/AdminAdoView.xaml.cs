using OOP_CourseWork.DataBase.ADO;
using OOP_CourseWork.DataBase.ADO.Repositories;
using OOP_CourseWork.ViewModel;
using System.Windows;

namespace OOP_CourseWork.View
{
    public partial class AdminAdoView : Window
    {
        public AdminAdoView()
        {
            InitializeComponent();
            try
            {
                var dbContext = new AdminDbContext();
                var repository = new AdminRepository(dbContext);
                DataContext = new AdminAdoViewModel(repository, this);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (DataContext is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
} 