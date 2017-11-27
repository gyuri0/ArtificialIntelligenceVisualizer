using System;
using System.Globalization;
using System.Windows.Data;

namespace ArtificialIntelligenceVisualizer.UI.Converters
{
    public class LayoutTypeEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LayoutType)
            {
                LayoutType layoutType = (LayoutType)value;
                switch (layoutType)
                {
                    case LayoutType.TreeLayout:
                        return "Fa";
                    case LayoutType.GraphLayout:
                        return "Gráf";
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
