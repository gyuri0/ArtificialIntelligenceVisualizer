using ArtificialIntelligenceVisualizer.ProblemLoader;
using ArtificialIntelligenceVisualizer.Searches;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace ArtificialIntelligenceVisualizer.UI.ViewModels
{
    public class ExampleProblemViewModel : INotifyPropertyChanged
    {
        private INavigationService navigationService;

        public List<ExampleProblem> ExampleProblemList { get; set; }

        public List<SearchMethod> SearchMethodList
        {
            get
            {
                return ExampleSearchFactory.GetAvailableSearchMethodsForProblem(this.SelectedExampleProblem);
            }
        }

        public SearchMethod SelectedSearchMethod { get; set; }

        private ExampleProblem selectedExampleProblem;
        public ExampleProblem SelectedExampleProblem
        {
            get
            {
                return this.selectedExampleProblem;
            }
            set
            {
                this.selectedExampleProblem = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchMethodList"));
                this.SelectedSearchMethod = SearchMethodList.First();
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedSearchMethod"));
            }
        }

        public ICommand CreateSearchCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ExampleProblemViewModel()
        {
        }

        public ExampleProblemViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.ExampleProblemList = Enum.GetValues(typeof(ExampleProblem)).Cast<ExampleProblem>().ToList();
            this.CreateSearchCommand = new SimpleCommand(() => CreateSearchButtonClick(), () => true);
        }

        private void CreateSearchButtonClick()
        {
            ISearch search = ExampleSearchFactory.CreateSearch(this.selectedExampleProblem, this.SelectedSearchMethod);
            navigationService.NavigateToSearch(search);
        }
    }
}
