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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NavigateToHelp(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new HelpWindow();
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToContact(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new ContactWindow();
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToActivePlace(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new ActivePlaceWindow();
            newWindow.Show();
            this.Hide();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KillProcess.FormClosing(sender, e);
        }

        private void NavigateToOrders(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new OrdersWindow();
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToLastView(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new LastViewWindow();
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToHistory(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new HistoryWindow();
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToBonus(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new BonusWindow();
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToSign(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new SignWindow();
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToFavorite(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new FavoriteWindow();
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToCart(object sender, MouseButtonEventArgs e)
        {
            popup.IsOpen = false;
            var newWindow = new CartWindow();
            newWindow.Show();
            this.Hide();
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