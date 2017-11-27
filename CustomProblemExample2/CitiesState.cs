using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace CustomProblemExample2
{
    public class CitiesState : IState
    {
        public static Dictionary<string, double> Heuristics;

        static CitiesState()
        {
            CitiesState.Heuristics = new Dictionary<string, double>
            {
                { "S", 100 },
                { "A", 4 },
                { "B", 2 },
                { "C", 4 },
                { "D", 4.5 },
                { "E", 2 },
                { "F", 0 }
            };
        }

        public  string Name { get; set; }

        public string TextRepresentation => this.Name;

        public CitiesState(string name)
        {
            this.Name = name;
        }

        public override bool Equals(object other)
        {
            CitiesState otherAsState = other as CitiesState;

            if(otherAsState == null)
            {
                return false;
            }

            return this.Name == otherAsState.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public double GetHeuristic()
        {
            return CitiesState.Heuristics[this.Name];
        }
    }
}
