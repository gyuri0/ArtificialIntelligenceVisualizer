using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ArtificialIntelligenceVisualizer.Searches.NonModifiable
{
    public class HillClimbing<StateType> : NonModifiableSearch<StateType> where StateType : IState
    {
        public override bool IsCostSearch => false;

        public override bool IsHeuristicSearch => true;

        public HillClimbing(Problem<StateType> problem) : base(problem)
        {
        }

        protected override StateType GetNextState(StateType currentState)
        {
            var availableStates = new List<StateType>();

            foreach (var op in this.problem.Operators)
            {
                if (op.Usable(currentState))
                {
                    availableStates.Add(op.Apply(currentState));
                }
            }

            if (availableStates.Count == 0)
            {
                return default(StateType);
            }

            return availableStates.OrderBy(x => this.problem.Heuristic.GetHeuristicValue(x)).First();
        }
    }
}
