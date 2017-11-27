using ArtificialIntelligenceVisualizer.Searches;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ArtificialIntelligenceVisualizer.UI.ViewModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private ISearch search;

        public ISearch Search
        {
            get
            {
                return this.search;
            }
            set
            {
                this.search = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchStatus"));
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LogicCore"));
            }
        }

        public GXLogicCore LogicCore
        {
            get
            {
                if (this.Search != null)
                {
                    return new GXLogicCore(this.SelectedLayout, this.Search.Graph);
                }
                else
                {
                    return null;
                }
            }
        }

        public SearchStatus SearchStatus
        {
            get
            {
                if (this.Search != null)
                {
                    return this.Search.Status;
                }
                else
                {
                    return SearchStatus.InProgress;
                }
            }
        }

        public List<LayoutType> LayoutTypeList { get; private set; }

        private LayoutType selectedLayout;

        public LayoutType SelectedLayout
        {
            get
            {
                return this.selectedLayout;
            }
            set
            {
                this.selectedLayout = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LogicCore"));
            }
        }

        public SearchViewModel()
        {
        }

        public SearchViewModel(ISearch search, INavigationService navigationService)
        {
            this.search = search;
            this.NextStepCommand = new SimpleCommand( () => this.NextStep(), () => this.Search.Status == SearchStatus.InProgress);
            this.NewProblemCommand = new SimpleCommand( () => navigationService.NavigateToProblemTypeSelection(), () => true);
            this.LayoutTypeList = Enum.GetValues(typeof(LayoutType)).Cast<LayoutType>().ToList();
        }

        private void NextStep()
        {
            this.Search.NextStep();
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchStatus"));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LogicCore"));
            this.NextStepCommand.OnCanExecuteChange();
        }

        public SimpleCommand NextStepCommand { get; set; }

        public ICommand NewProblemCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
