using ArtificialIntelligenceVisualizerLibrary;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemHanoiTower
{
    public class HanoiTowerGoalStateChecker : IGoalStateChecker<HanoiTowerState>
    {
        public bool IsGoalState(HanoiTowerState state)
        {
            return state.Rods[state.N - 1].Count == state.N;
        }
    }
}
