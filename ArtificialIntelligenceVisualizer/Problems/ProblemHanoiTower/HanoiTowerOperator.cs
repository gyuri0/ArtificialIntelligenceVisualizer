using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemHanoiTower
{
    public class HanoiTowerOperator : Operator<HanoiTowerState>
    {
        private int fromIndex;
        private int toIndex;
           
        public HanoiTowerOperator(int fromIndex, int toIndex)
        {
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
        }

        public override HanoiTowerState Apply(HanoiTowerState state)
        {
            int n = state.N;
            List<int>[] rods = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                rods[i] = new List<int>(state.Rods[i]);
            }

            rods[toIndex].Add(rods[fromIndex][rods[fromIndex].Count - 1]);
            rods[fromIndex].RemoveAt(rods[fromIndex].Count - 1);

            return new HanoiTowerState(n, rods);
        }

        public override bool Usable(HanoiTowerState state)
        {
            if(state.Rods[fromIndex].Count == 0)
            {
                return false;
            }

            if(state.Rods[toIndex].Count == 0)
            {
                return true;
            }

            int fromSize = state.Rods[fromIndex][state.Rods[fromIndex].Count - 1];
            int toSize = state.Rods[toIndex][state.Rods[toIndex].Count - 1];

            return fromSize < toSize;
        }

        public static List<Operator<HanoiTowerState>> GetAllOperators(int n)
        {
            var allOperators = new List<Operator<HanoiTowerState>>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    allOperators.Add(new HanoiTowerOperator(i, j));
                }
            }

            return allOperators;
        }
    }
}
