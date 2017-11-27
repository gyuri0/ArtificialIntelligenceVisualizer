using ArtificialIntelligenceVisualizerLibrary;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemJug
{
    public class JugProblemCreator : IProblemCreator<JugState>
    {
        public Problem<JugState> CreateProblem()
        {
            return new Problem<JugState>(new JugState(new int[] { 0, 0, 8 }), JugOperator.GetAllOperators(), new JugGoalStateChecker());
        }
    }
}
