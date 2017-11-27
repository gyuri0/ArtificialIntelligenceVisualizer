using ArtificialIntelligenceVisualizer.UI.ViewModels;
using System.Windows;

namespace ArtificialIntelligenceVisualizer.UI.Views
{
    /// <summary>
    /// Interaction logic for ProblemTypeSelectionWindow.xaml
    /// </summary>
    public partial class ProblemTypeSelectionWindow : Window
    {
        public ProblemTypeSelectionWindow()
        {
            InitializeComponent();
            this.DataContext = new ProblemTypeSelectionViewModel(new NavigationService(this));
        }
    }
}
