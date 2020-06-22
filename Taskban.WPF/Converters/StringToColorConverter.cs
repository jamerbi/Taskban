using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Taskban.WPF.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (string) value switch
            {
                "High" => new SolidColorBrush(Colors.IndianRed),
                "Medium" => new SolidColorBrush(Colors.Goldenrod),
                "Low" => new SolidColorBrush(Colors.ForestGreen),
                _ => new SolidColorBrush(Colors.LightGray)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}