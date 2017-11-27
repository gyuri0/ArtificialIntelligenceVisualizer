using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemCities
{
    public class CitiesHeuristic : IHeuristic<CitiesState>
    {
        private static Dictionary<string, double> HeuristicValues;

        static CitiesHeuristic()
        {
            CitiesHeuristic.HeuristicValues = new Dictionary<string, double>();
            CitiesHeuristic.HeuristicValues.Add("S", 100);
            CitiesHeuristic.HeuristicValues.Add("A", 4);
            CitiesHeuristic.HeuristicValues.Add("B", 2);
            CitiesHeuristic.HeuristicValues.Add("C", 4);
            CitiesHeuristic.HeuristicValues.Add("D", 4.5);
            CitiesHeuristic.HeuristicValues.Add("E", 2);
            CitiesHeuristic.HeuristicValues.Add("F", 0);
        }

        public double GetHeuristicValue(CitiesState state)
        {
            return CitiesHeuristic.HeuristicValues[state.Name];
        }
    }
}
