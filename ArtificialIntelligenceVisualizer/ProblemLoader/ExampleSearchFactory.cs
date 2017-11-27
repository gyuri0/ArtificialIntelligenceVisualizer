using ArtificialIntelligenceVisualizer.Problems.ProblemCities;
using ArtificialIntelligenceVisualizer.Problems.ProblemHanoiTower;
using ArtificialIntelligenceVisualizer.Problems.ProblemJug;
using ArtificialIntelligenceVisualizer.Problems.ProblemNQueen;
using ArtificialIntelligenceVisualizer.Searches;
using ArtificialIntelligenceVisualizer.Searches.Backtrack;
using ArtificialIntelligenceVisualizer.Searches.NonModifiable;
using ArtificialIntelligenceVisualizer.Searches.SearchTreeSearches;
using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.ProblemLoader
{
    public class ExampleSearchFactory
    {
        public static ISearch CreateSearch(ExampleProblem exampleProblem, SearchMethod searchMethod)
        {
            switch (exampleProblem)
            {
                case ExampleProblem.Jug:
                    var problemCreator = new JugProblemCreator();
                    return GetSearch(searchMethod, problemCreator.CreateProblem());
                case ExampleProblem.Queen4:
                    var problemCreator2 = new FourQueenProblemCreator();
                    return GetSearch(searchMethod, problemCreator2.CreateProblem());
                case ExampleProblem.HanoiTower:
                    var problemCreator3 = new HanoiTowerProblemCreator();
                    return GetSearch(searchMethod, problemCreator3.CreateProblem());
                case ExampleProblem.Cities:
                    var problemCreator4 = new CitiesProblemCreator();
                    return GetSearch(searchMethod, problemCreator4.CreateProblem());
            }

            return null;
        }

        private static ISearch GetSearch<T>(SearchMethod searchMethod, Problem<T> problem) where T : class, IState
        {
            switch (searchMethod)
            {
                case SearchMethod.BreadthFirstSearch:
                    return new BreadthFirstSearch<T>(problem);
                case SearchMethod.DepthFirstSearch:
                    return new DepthFirstSearch<T>(problem);
                case SearchMethod.BackTrack:
                    return new BackTrack<T>(problem);
                case SearchMethod.OptimalSearch:
                    return new OptimalSearch<T>(problem);
                case SearchMethod.AStar:
                    return new AStar<T>(problem);
                case SearchMethod.TrialAndError:
                    return new TrialAndError<T>(problem);
                case SearchMethod.HillClimbing:
                    return new HillClimbing<T>(problem);
            }

            return null;
        }

        public static List<SearchMethod> GetAvailableSearchMethodsForProblem(ExampleProblem problem)
        {
            switch (problem)
            {
                case ExampleProblem.Jug:
                case ExampleProblem.Queen4:
                case ExampleProblem.HanoiTower:
                    return new List<SearchMethod>()
                    {
                        SearchMethod.TrialAndError,
                        SearchMethod.BreadthFirstSearch,
                        SearchMethod.DepthFirstSearch,
                        SearchMethod.BackTrack,
                        SearchMethod.OptimalSearch
                    };
                case ExampleProblem.Cities:
                    return new List<SearchMethod>()
                    {
                        SearchMethod.TrialAndError,
                        SearchMethod.BreadthFirstSearch,
                        SearchMethod.DepthFirstSearch,
                        SearchMethod.BackTrack,
                        SearchMethod.OptimalSearch,
                        SearchMethod.HillClimbing,
                        SearchMethod.AStar
                    };
            }

            return new List<SearchMethod>();
        }
    }
}
