using ArtificialIntelligenceVisualizer.Searches;
using ArtificialIntelligenceVisualizer.Searches.Backtrack;
using ArtificialIntelligenceVisualizer.Searches.NonModifiable;
using ArtificialIntelligenceVisualizer.Searches.SearchTreeSearches;
using ArtificialIntelligenceVisualizerLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ArtificialIntelligenceVisualizer.ProblemLoader
{
    public class CustomProblemLoader
    {
        private Type stateType;
        private Type problemCreatorType;
        private object problem;

        public CustomProblemLoader(string path)
        {
            Assembly assembly = Assembly.LoadFile(path);
            stateType = assembly.GetTypes().First(x => x.GetInterfaces().Contains(typeof(IState)));
            Type problemCreatorInterface1 = typeof(IProblemCreator<>).MakeGenericType(stateType);
            this.problemCreatorType = assembly.GetTypes().FirstOrDefault(
                x => x.GetInterfaces().Contains(problemCreatorInterface1)
                );
            object problemCreatorInstance = Activator.CreateInstance(problemCreatorType);
            MethodInfo mi = problemCreatorType.GetMethod("CreateProblem");

            problem = mi.Invoke(problemCreatorInstance, null);
        }

        public ISearch CreateSearch(SearchMethod searchMethod)
        {
            Type rawSearchType = GetRawSearchTypeForSearchMethod(searchMethod);
            Type searchType = rawSearchType.MakeGenericType(this.stateType);
            ISearch searchInstance = Activator.CreateInstance(searchType, problem) as ISearch;
            return searchInstance;
        }

        private Type GetRawSearchTypeForSearchMethod(SearchMethod searchMethod)
        {
            switch(searchMethod)
            {
                case SearchMethod.TrialAndError:
                    return typeof(TrialAndError<>);
                case SearchMethod.HillClimbing:
                    return typeof(HillClimbing<>);
                case SearchMethod.BreadthFirstSearch:
                    return typeof(BreadthFirstSearch<>);
                case SearchMethod.DepthFirstSearch:
                    return typeof(DepthFirstSearch<>);
                case SearchMethod.BackTrack:
                    return typeof(BackTrack<>);
                case SearchMethod.OptimalSearch:
                    return typeof(OptimalSearch<>);
                case SearchMethod.AStar:
                    return typeof(AStar<>);
            }

            return null;
        }

        public List<SearchMethod> GetAvailableSearchMethods()
        {
            bool hasHeuristic = (bool) problem.GetType().GetProperty(nameof(Problem<IState>.HasHeuristic)).GetValue(problem, null);

            var availableSearches = new List<SearchMethod>()
            {
                SearchMethod.TrialAndError,
                SearchMethod.BreadthFirstSearch,
                SearchMethod.DepthFirstSearch,
                SearchMethod.BackTrack,
                SearchMethod.OptimalSearch
            };

            if (hasHeuristic)
            {
                availableSearches.Add(SearchMethod.AStar);
                availableSearches.Add(SearchMethod.HillClimbing);
            }

            return availableSearches;
        }
    }
}
