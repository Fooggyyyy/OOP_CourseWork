using System.Windows;
using System.Windows.Input;
using OOP_CourseWork.ViewModel;
using OOP_CourseWork.DataBase.Pattern.UnitOfWork;

namespace OOP_CourseWork.View
{
    public partial class PersonalAccountView : Window
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonalAccountView(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            DataContext = new PersonalAccountViewModel(unitOfWork);

            this.Cursor = new Cursor("C:\\Users\\user\\source\\repos\\OOP_CourseWork\\OOP_CourseWork\\Recources\\BUSY.cur");
        }

        private void NavigateToMain(object sender, MouseButtonEventArgs e)
        {
            var mainWindow = new MainWindow(_unitOfWork);
            mainWindow.Show();
            this.Hide();
        }

        private void NavigateToShopMainWindow(object sender, MouseButtonEventArgs e)
        {
            var shopMainWindow = new ShopMainWindow(_unitOfWork);
            shopMainWindow.Show();
            this.Hide();
        }

        private void NavigateToOrders(object sender, MouseButtonEventArgs e)
        {
            var ordersWindow = new OrdersWindow(_unitOfWork);
            ordersWindow.Show();
            this.Hide();
        }

        private void NavigateToHistory(object sender, MouseButtonEventArgs e)
        {
            var historyWindow = new HistoryWindow(_unitOfWork);
            historyWindow.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KillProcess.FormClosing(sender, e);
        }
    }
} 