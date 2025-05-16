using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
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
    public partial class PaymentWindow : Window
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentWindow(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            DataContext = new PaymentViewModel(unitOfWork);


            this.Cursor = new Cursor("C:\\Users\\user\\source\\repos\\OOP_CourseWork\\OOP_CourseWork\\Recources\\BUSY.cur");
        }


        private void NavigateToMain(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow(_unitOfWork);
            newWindow.Show();
            this.Hide();
        }
    }
}
