using System;
using System.Globalization;
using System.Windows.Data;

namespace Taskban.WPF.Converters
{
    public class CountToWidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && (int) value > 0) return 200;
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}