using ArtificialIntelligenceVisualizerLibrary;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemNQueen
{
    public class FourQueenGoalStateChecker : IGoalStateChecker<FourQueenState>
    {
        public bool IsGoalState(FourQueenState state)
        {
            return state.Rows.Count == 4;
        }
    }
}
