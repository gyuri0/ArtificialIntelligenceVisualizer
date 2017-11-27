using ArtificialIntelligenceVisualizerLibrary;
using System.Linq;

namespace CustomProblemExample
{
    public class JugGoalStateChecker : IGoalStateChecker<JugState>
    {
        public bool IsGoalState(JugState state)
        {
            return state.Values.Contains(4);
        }
    }
}
