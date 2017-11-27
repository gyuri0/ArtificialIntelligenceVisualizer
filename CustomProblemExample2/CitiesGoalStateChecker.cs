using ArtificialIntelligenceVisualizerLibrary;

namespace CustomProblemExample2
{
    public class CitiesGoalStateChecker : IGoalStateChecker<CitiesState>
    {
        public bool IsGoalState(CitiesState state)
        {
            return state.Name == "F";
        }
    }
}
