using ArtificialIntelligenceVisualizerLibrary;

namespace CustomProblemExample2
{
    public class CitiesProblemCreator : IProblemCreator<CitiesState>
    {
        public Problem<CitiesState> CreateProblem()
        {
            return new Problem<CitiesState>(new CitiesState("S"), CitiesOperator.GetAllOperators(), new CitiesGoalStateChecker());
        }
    }
}
