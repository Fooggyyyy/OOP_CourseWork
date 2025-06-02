using System;
using System.Globalization;
using System.Windows.Data;

namespace OOP_CourseWork.Converters
{
    public class BonusToNextLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double bonus)
            {
                var nextLevel = Math.Ceiling(bonus / 100.0) * 100;
                var remaining = nextLevel - bonus;
                return $"{remaining} бонусов";
            }
            return "0 бонусов";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 