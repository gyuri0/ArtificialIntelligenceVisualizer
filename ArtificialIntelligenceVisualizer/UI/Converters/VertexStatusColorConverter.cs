using ArtificialIntelligenceVisualizer.Graph;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ArtificialIntelligenceVisualizer.UI.Converters
{
    public class VertexStatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is VertexStatus)
            {
                VertexStatus vertexStatus = (VertexStatus)value;
                switch (vertexStatus)
                {
                    case VertexStatus.Simple:
                        return Brushes.Gray;
                    case VertexStatus.Marked:
                        return Brushes.Black;
                    case VertexStatus.GoalState:
                        return Brushes.Green;
                    case VertexStatus.SelectedToExpand:
                        return Brushes.Yellow;
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
