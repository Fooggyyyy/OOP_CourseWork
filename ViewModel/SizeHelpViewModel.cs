using OOP_CourseWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OOP_CourseWork.ViewModel
{
    public class SizeHelpViewModel : ViewModelBase
    {
        private double _height;
        private double _width;
        private Size _calculatedSize;

        public double Height
        {
            get => _height;
            set => Set(ref _height, value);
        }

        public double Width
        {
            get => _width;
            set => Set(ref _width, value);
        }

        public Size CalculatedSize
        {
            get => _calculatedSize;
            set => Set(ref _calculatedSize, value);
        }

        public ICommand CalculateSizeCommand { get; }

        public SizeHelpViewModel()
        {
            CalculateSizeCommand = CreateCommand(CalculateSize);
        }

        private void CalculateSize(object parameter)
        {
            var sizeHelp = new SizeHelp(Height, Width);
            CalculatedSize = sizeHelp.DetermineSize();
        }
    }
}
