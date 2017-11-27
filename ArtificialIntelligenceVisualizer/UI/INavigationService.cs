using ArtificialIntelligenceVisualizer.Searches;

namespace ArtificialIntelligenceVisualizer.UI
{
    public interface INavigationService
    {
        void NavigateToProblemTypeSelection();

        void NavigateToExampleProblem();

        void NavigateToCustomProblem();

        void NavigateToSearch(ISearch search);
    }
}