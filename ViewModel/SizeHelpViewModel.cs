using OOP_CourseWork.DataBase.Pattern.UnitOfWork;
using OOP_CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OOP_CourseWork.ViewModel
{
    public class SizeHelpViewModel : ViewModelBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }

        private double _weight;
        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        private OOP_CourseWork.Model.Size? _recommendedSize;
        public OOP_CourseWork.Model.Size? RecommendedSize
        {
            get => _recommendedSize;
            set
            {
                _recommendedSize = value;
                OnPropertyChanged();
            }
        }

        public ICommand RecommendSizeCommand { get; }

        public SizeHelpViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RecommendSizeCommand = CreateAsyncCommand(RecommendSize);
        }

        private async Task RecommendSize()
        {
            try
            {
                if (double.IsNaN(Height) || Height <= 0 || Height > 220)
                    throw new ArgumentException("Рост должен быть положительным числом не более 220 см.");

                if (double.IsNaN(Weight) || Weight <= 0 || Weight > 200)
                    throw new ArgumentException("Вес должен быть положительным числом не более 200 кг.");

                var helper = new SizeHelp(Height, Weight);
                RecommendedSize = helper.DetermineSize();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
