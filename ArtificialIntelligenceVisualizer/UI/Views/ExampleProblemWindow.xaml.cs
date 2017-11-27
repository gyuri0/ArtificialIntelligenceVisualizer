using ArtificialIntelligenceVisualizer.UI.ViewModels;
using System.Windows;

namespace ArtificialIntelligenceVisualizer.UI.Views
{
    /// <summary>
    /// Interaction logic for ExampleProblemSelector.xaml
    /// </summary>
    public partial class ExampleProblemWindow : Window
    {
        public ExampleProblemWindow()
        {
            InitializeComponent();

            var viewModel = new ExampleProblemViewModel(new NavigationService(this));
            this.DataContext = viewModel;
        }
    }
}
