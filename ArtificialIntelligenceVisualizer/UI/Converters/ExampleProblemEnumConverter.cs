using ArtificialIntelligenceVisualizer.ProblemLoader;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ArtificialIntelligenceVisualizer.UI.Converters
{
    public class ExampleProblemEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ExampleProblem)
            {
                ExampleProblem exampleProblem = (ExampleProblem)value;
                switch (exampleProblem)
                {
                    case ExampleProblem.Jug:
                        return "Kancsó";
                    case ExampleProblem.Queen4:
                        return "Négykirálynő-probléma";
                    case ExampleProblem.HanoiTower:
                        return "Hanoi tornyai";
                    case ExampleProblem.Cities:
                        return "Városok";
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
