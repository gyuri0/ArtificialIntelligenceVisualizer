using ArtificialIntelligenceVisualizerLibrary;
using System;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Searches.NonModifiable
{
    public class TrialAndError<StateType> : NonModifiableSearch<StateType> where StateType : IState
    {
        private Random random;

        public override bool IsCostSearch => false;

        public override bool IsHeuristicSearch => false;

        public TrialAndError(Problem<StateType> problem) : base(problem)
        {
            this.random = new Random();
        }

        protected override StateType GetNextState(StateType currentState)
        {
            var usableOperators = new List<Operator<StateType>>();

            for (int i = 0; i < problem.Operators.Count; i++)
            {
                if (problem.Operators[i].Usable(currentState))
                {
                    usableOperators.Add(problem.Operators[i]);
                }
            }
            if (usableOperators.Count == 0)
            {
                return default(StateType);
            }

            int randomIndex = this.random.Next(0, usableOperators.Count);
            return usableOperators[randomIndex].Apply(currentState);
        }
    }
}
