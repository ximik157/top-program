using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace top_project
{
    class DataToColorConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString().Length == 0
                ? new SolidColorBrush(Colors.Red)
                : new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
