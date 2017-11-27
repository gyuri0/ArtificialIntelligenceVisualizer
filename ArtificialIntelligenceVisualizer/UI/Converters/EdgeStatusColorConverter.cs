using ArtificialIntelligenceVisualizer.Graph;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ArtificialIntelligenceVisualizer.UI.Converters
{
    public class EdgeStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is EdgeStatus)
            {
                EdgeStatus vertexStatus = (EdgeStatus)value; 
                switch (vertexStatus)
                {
                    case EdgeStatus.Marked:
                        return Brushes.Red;
                    case EdgeStatus.Simple:
                        return Brushes.Black;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
