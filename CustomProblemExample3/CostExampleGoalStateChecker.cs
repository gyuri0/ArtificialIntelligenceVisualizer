using ArtificialIntelligenceVisualizerLibrary;

namespace CustomProblemExample3
{
    public class CostExampleGoalStateChecker : IGoalStateChecker<CostExampleState>
    {
        public bool IsGoalState(CostExampleState state)
        {
            return state.StateId == 2;
        }
    }
}
