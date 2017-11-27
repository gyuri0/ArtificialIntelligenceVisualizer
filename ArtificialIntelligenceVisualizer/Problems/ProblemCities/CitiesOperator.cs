using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemCities
{
    public class CitiesOperator : Operator<CitiesState>
    {
        private string goalName;
        private Dictionary<string, double> costs;

        public CitiesOperator(string goalName, Dictionary<string, double> costs)
        {
            this.goalName = goalName;
            this.costs = costs;
        }

        public override CitiesState Apply(CitiesState state)
        {
            return new CitiesState(this.goalName);
        }

        public override double GetCost(CitiesState state)
        {
            return this.costs[state.Name];
        }

        public override bool Usable(CitiesState state)
        {
            return this.costs.ContainsKey(state.Name);
        }

        public static List<Operator<CitiesState>> GetAllOperators()
        {
            var allOperators = new List<Operator<CitiesState>>();

            var costs = new Dictionary<string, double>
            {
                { "A", 1.5 },
                { "D", 4.5 }
            };
            allOperators.Add(new CitiesOperator("S", costs));

            costs = new Dictionary<string, double>
            {
                { "S", 1.5 },
                { "B", 2 }
            };
            allOperators.Add(new CitiesOperator("A", costs));

            costs = new Dictionary<string, double>
            {
                { "A", 2 },
                { "C", 3 }
            };
            allOperators.Add(new CitiesOperator("B", costs));

            costs = new Dictionary<string, double>
            {
                { "B", 3 },
                { "F", 4 }
            };
            allOperators.Add(new CitiesOperator("C", costs));

            costs = new Dictionary<string, double>
            {
                { "S", 4.5 },
                { "E", 3 }
            };
            allOperators.Add(new CitiesOperator("D", costs));

            costs = new Dictionary<string, double>
            {
                { "D", 3 },
                { "F", 2 }
            };
            allOperators.Add(new CitiesOperator("E", costs));

            costs = new Dictionary<string, double>
            {
                { "E", 2 },
                { "C", 4 }
            };
            allOperators.Add(new CitiesOperator("F", costs));

            return allOperators;
        }
    }
}
