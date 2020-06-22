using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Taskban.WPF.Entities;

namespace Taskban.WPF.Converters
{
    public class SubTasksToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var subTasks = (ObservableCollection<SubTask>) value;
            return $"{subTasks!.Count(task => (task != null) && task.Completed)}/{subTasks.Count}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}