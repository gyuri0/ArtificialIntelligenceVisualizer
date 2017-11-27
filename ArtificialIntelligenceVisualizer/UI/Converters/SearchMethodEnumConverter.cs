using ArtificialIntelligenceVisualizer.ProblemLoader;
using ArtificialIntelligenceVisualizer.Searches;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ArtificialIntelligenceVisualizer.UI.Converters
{
    public class SearchMethodEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SearchMethod)
            {
                SearchMethod searchMethod = (SearchMethod)value;
                switch (searchMethod)
                {
                    case SearchMethod.HillClimbing:
                        return "Hegymászó módszer";
                    case SearchMethod.TrialAndError:
                        return "Próba-hiba módszer";
                    case SearchMethod.BackTrack:
                        return "BackTrack";
                    case SearchMethod.BreadthFirstSearch:
                        return "Szélességi kereső";
                    case SearchMethod.DepthFirstSearch:
                        return "Mélységi kereső";
                    case SearchMethod.OptimalSearch:
                        return "Optimális kereső";
                    case SearchMethod.AStar:
                        return "A* kereső";
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
