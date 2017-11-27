using ArtificialIntelligenceVisualizer.Searches;
using ArtificialIntelligenceVisualizer.UI.Views;
using System.Windows;

namespace ArtificialIntelligenceVisualizer.UI
{
    public class NavigationService : INavigationService
    {
        private Window currentWindow;

        public NavigationService(Window currentWindow)
        {
            this.currentWindow = currentWindow;
        }

        public void NavigateToCustomProblem()
        {
            this.ChangeWindow(new CustomProblemWindow());
        }

        public void NavigateToExampleProblem()
        {
            this.ChangeWindow(new ExampleProblemWindow());
        }

        public void NavigateToProblemTypeSelection()
        {
            this.ChangeWindow(new ProblemTypeSelectionWindow());
        }

        public void NavigateToSearch(ISearch search)
        {
            this.ChangeWindow(new SearchWindow(search));
        }

        private void ChangeWindow(Window newWindow)
        {
            newWindow.Show();
            this.currentWindow.Close();
        }
    }
}
