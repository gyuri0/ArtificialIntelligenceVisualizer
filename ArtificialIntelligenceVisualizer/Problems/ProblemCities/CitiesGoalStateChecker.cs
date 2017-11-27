using ArtificialIntelligenceVisualizerLibrary;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemCities
{
    public class CitiesGoalStateChecker : IGoalStateChecker<CitiesState>
    {
        public bool IsGoalState(CitiesState state)
        {
            return state.Name == "F";
        }
    }
}
