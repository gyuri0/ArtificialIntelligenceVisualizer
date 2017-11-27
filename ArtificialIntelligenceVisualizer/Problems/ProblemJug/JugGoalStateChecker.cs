using ArtificialIntelligenceVisualizerLibrary;
using System.Linq;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemJug
{
    public class JugGoalStateChecker : IGoalStateChecker<JugState>
    {
        public bool IsGoalState(JugState state)
        {
            return state.Values.Contains(4);
        }
    }
}
