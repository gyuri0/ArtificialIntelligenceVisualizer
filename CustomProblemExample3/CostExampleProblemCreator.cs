using ArtificialIntelligenceVisualizerLibrary;

namespace CustomProblemExample3
{
    public class CostExampleProblemCreator : IProblemCreator<CostExampleState>
    {
        public Problem<CostExampleState> CreateProblem()
        {
            return new Problem<CostExampleState>(new CostExampleState(), CostExampleOperator.GetAllOperators(), new CostExampleGoalStateChecker());
        }
    }
}
