using ArtificialIntelligenceVisualizer.Searches;
using ArtificialIntelligenceVisualizer.UI.ViewModels;
using System.Windows;

namespace ArtificialIntelligenceVisualizer.UI.Views
{
    public partial class SearchWindow : Window
    {
        public SearchWindow(ISearch search)
        {
            InitializeComponent();
            this.DataContext = new SearchViewModel(search, new NavigationService(this));
        }
    }
}
