using System.Windows.Input;

namespace ArtificialIntelligenceVisualizer.UI.ViewModels
{
    public class ProblemTypeSelectionViewModel
    {
        public ICommand NavigateToExampleProblemCommand { get; set; }

        public ICommand NavigateToCustomProblemCommand { get; set; }

        public ProblemTypeSelectionViewModel()
        {
        }

        public ProblemTypeSelectionViewModel(INavigationService navigationService)
        {
            this.NavigateToExampleProblemCommand = new SimpleCommand(() => navigationService.NavigateToExampleProblem(), () => true);
            this.NavigateToCustomProblemCommand = new SimpleCommand(() => navigationService.NavigateToCustomProblem(), () => true);
        }
    }
}
