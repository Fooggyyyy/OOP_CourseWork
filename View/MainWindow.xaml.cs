using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Recources.Translate;
using OOP_CourseWork.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OOP_CourseWork
{
    public partial class MainWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            Application.Current.MainWindow = this;


            this.Cursor = new Cursor("C:\\Users\\user\\source\\repos\\OOP_CourseWork\\OOP_CourseWork\\Recources\\BUSY.cur");

        }

        private void NavigateToPersonalAccount(object sender, MouseButtonEventArgs e)
        {
            if (!Model.CurrentUser.CurrentUser.IsLoggedIn)
            {
                MessageBox.Show("Пожалуйста, войдите в систему");
                var signWindow = new SignWindow(_unitOfWork);
                signWindow.Show();
                this.Hide();
                return;
            }

            var personalAccountWindow = new PersonalAccountView(_unitOfWork);
            personalAccountWindow.Show();
            this.Hide();
        }

        private void NavigateToHelp(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new HelpWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToContact(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new ContactWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToActivePlace(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new ActivePlaceWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KillProcess.FormClosing(sender, e);
        }

        private void NavigateToShopMainWindow(object sender, MouseButtonEventArgs e)
        {
            ShopMainWindow shopWindow = new ShopMainWindow(_unitOfWork);
            shopWindow.Show();
            this.Hide();
        }

        private void NavigateToOrders(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new OrdersWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToLastView(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new LastViewWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToHistory(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new HistoryWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToBonus(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new BonusWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToSign(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new SignWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToFavorite(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new FavoriteWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToCart(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new CartWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void OnLanguageChanged(object sender, SelectionChangedEventArgs e)
        {
            var lang = (e.AddedItems[0] as ComboBoxItem)?.Tag?.ToString(); // "en" или "ru"
            LanguageManager.ChangeLanguage(lang);
        }


        private void ShopBurgerMenuOpen(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = true; 
        }

        private void CloseBurgerMenu(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
        }

        
    }
}