using ArtificialIntelligenceVisualizer.Searches;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ArtificialIntelligenceVisualizer.UI.Converters
{
    public class SearchStatusEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SearchStatus)
            {
                SearchStatus layoutType = (SearchStatus)value;
                switch (layoutType)
                {
                    case SearchStatus.InProgress:
                        return "Folyamatban";
                    case SearchStatus.Finished:
                        return "Befejeződött";
                    case SearchStatus.SolutionFound:
                        return "Megoldás megtalálva";
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
