using ArtificialIntelligenceVisualizer.ProblemLoader;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace ArtificialIntelligenceVisualizer.UI.ViewModels
{
    public class CustomProblemViewModel : INotifyPropertyChanged
    {
        private CustomProblemLoader customProblemLoader;

        public ICommand SelectFilePathCommand { get; set; }

        public ICommand CreateSearchCommand { get; set; }

        private string selectedFilePath;

        public string SelectedFilePath
        {
            get
            {
                return this.selectedFilePath;
            }
            set
            {
                this.selectedFilePath = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("SearchMethodList"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<SearchMethod> SearchMethodList
        {
            get
            {
                if (this.customProblemLoader == null)
                {
                    return null;
                }

                return this.customProblemLoader.GetAvailableSearchMethods();
            }
        }

        public SearchMethod SelectedSearchMethod { get; set; }

        public CustomProblemViewModel()
        {
        }

        public CustomProblemViewModel(INavigationService navigationService, IFilePathSelector filePathSelector)
        {
            this.SelectFilePathCommand = new SimpleCommand(() => 
            {
                string filePath = filePathSelector.GetFilePath();
                try
                {
                    var customProblemLoader = new CustomProblemLoader(filePath);
                    this.customProblemLoader = customProblemLoader;
                    this.SelectedFilePath = filePath;
                }
                catch
                {
                }
            }
            , () => true);

            this.CreateSearchCommand = new SimpleCommand(() =>
            {
                if (this.customProblemLoader != null)
                {
                    navigationService.NavigateToSearch(this.customProblemLoader.CreateSearch(this.SelectedSearchMethod));
                }
            }
            , () => true);
        }
        
    }
}
