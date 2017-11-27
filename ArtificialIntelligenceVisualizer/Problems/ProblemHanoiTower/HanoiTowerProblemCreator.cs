using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemHanoiTower
{
    public class HanoiTowerProblemCreator : IProblemCreator<HanoiTowerState>
    {
        public Problem<HanoiTowerState> CreateProblem()
        {
            HanoiTowerState goalState = GenerateGoalState(3);
            var goalStateChecker = new ListingGoalStateChecker<HanoiTowerState>(new List<HanoiTowerState>() { goalState });

            return new Problem<HanoiTowerState>(new HanoiTowerState(3), HanoiTowerOperator.GetAllOperators(3), goalStateChecker);
        }

        private static HanoiTowerState GenerateGoalState(int n)
        {
            var rods = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                rods[i] = new List<int>();
            }

            for (int i = n; i > 0; i--)
            {
                rods[n-1].Add(i);
            }

            HanoiTowerState goalState = new HanoiTowerState(n, rods);
            return goalState;
        }
    }
}
