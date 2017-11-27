namespace ArtificialIntelligenceVisualizerLibrary
{
    public interface IProblemCreator<StateType> where StateType: IState
    {
        Problem<StateType> CreateProblem();
    }
}
