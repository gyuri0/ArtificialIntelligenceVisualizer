using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemCities
{
    public class CitiesState : IState
    {
        public string Name { get; set; }

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
    }
}
