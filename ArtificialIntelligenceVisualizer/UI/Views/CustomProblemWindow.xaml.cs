using System.Windows;
using Microsoft.Win32;
using ArtificialIntelligenceVisualizer.Searches;
using ArtificialIntelligenceVisualizer.ProblemLoader;
using ArtificialIntelligenceVisualizer.UI.ViewModels;

namespace ArtificialIntelligenceVisualizer.UI.Views
{
    /// <summary>
    /// Interaction logic for CustomProblemWindow.xaml
    /// </summary>
    public partial class CustomProblemWindow : Window
    {
        public CustomProblemWindow()
        {
            InitializeComponent();
            this.DataContext = new CustomProblemViewModel(new NavigationService(this), new FileDialogFilePathSelector());
        }
    }
}
