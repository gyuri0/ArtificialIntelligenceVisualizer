using ArtificialIntelligenceVisualizerLibrary;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemNQueen
{
    public class FourQueenProblemCreator : IProblemCreator<FourQueenState>
    {
        public Problem<FourQueenState> CreateProblem()
        {
            return new Problem<FourQueenState>(new FourQueenState(), FourQueenOperator.GetAllOperators(), new FourQueenGoalStateChecker());
        }
    }
}
