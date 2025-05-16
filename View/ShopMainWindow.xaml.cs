using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using OOP_CourseWork.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OOP_CourseWork.View
{
    /// <summary>
    /// Логика взаимодействия для ShopMainWindow.xaml
    /// </summary>
    public partial class ShopMainWindow : Window
    {

        private readonly IUnitOfWork _unitOfWork;
        public ShopMainWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            DataContext = new ShopMainViewModel(unitOfWork);

            
            this.Cursor = new Cursor("C:\\Users\\user\\source\\repos\\OOP_CourseWork\\OOP_CourseWork\\Recources\\BUSY.cur");

        }


        private void NavigateToHelp(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new HelpWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToShopMainWindow(object sender, MouseButtonEventArgs e)
        {
            ShopMainWindow shopWindow = new ShopMainWindow(_unitOfWork);
            shopWindow.Show();
            this.Hide();
        }

        private void NavigateToContact(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new ContactWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToActivePlace(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new ActivePlaceWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            KillProcess.FormClosing(sender, e);
        }

        private void NavigateToMain(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new MainWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }
        private void NavigateToSign(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new SignWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }
        private void NavigateToOrders(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new OrdersWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToLastView(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new LastViewWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToHistory(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new HistoryWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToBonus(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new BonusWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToFavorite(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new FavoriteWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }

        private void NavigateToCart(object sender, MouseButtonEventArgs e)
        {
            var newWindow = new CartWindow(_unitOfWork);
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


        private void Item_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Border border && border.DataContext is Item item)
            {
                var viewModel = (ShopMainViewModel)DataContext;
                viewModel.OpenItemPageCommand.Execute(item);
            }
        }
    }
}
