using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace OOP_CourseWork.Model
{
    internal class SizeHelp
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public SizeHelp() { }

        public SizeHelp(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public Size DetermineSize()
        {
            double heightInMeters = Height / 100;
            double bmi = Width / (heightInMeters * heightInMeters);

            if (bmi < 18.5)
                return Size.S;
            else if (bmi < 24.9)
                return Size.M;
            else if (bmi < 29.9)
                return Size.L;
            else if (bmi < 34.9)
                return Size.XL;
            else
                return Size.XXL;
        }
    }
}
