using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizerLibrary
{
    /// <summary>
    /// Egy mesterséges intelligencia problémát reprezentál.
    /// </summary>
    /// <typeparam name="StateType"></typeparam>
    public class Problem<StateType> where StateType : IState
    {
        /// <summary>
        /// A probléma kezdő állapota.
        /// </summary>
        public StateType StartState { get; private set; }

        /// <summary>
        /// A problémához tartozó operátorok.
        /// </summary>
        public List<Operator<StateType>> Operators { get; private set; }
        
        public IGoalStateChecker<StateType> GoalStateChecker { get; private set; }

        public IHeuristic<StateType> Heuristic { get; private set; }

        public bool HasHeuristic
        {
            get
            {
                return this.Heuristic != null;
            }
        }

        public Problem(
            StateType startState, 
            List<Operator<StateType>> operators, 
            IGoalStateChecker<StateType> goalStateChecker,
            IHeuristic<StateType> heuristic = null)
        {
            this.StartState = startState;
            this.Operators = operators;
            this.GoalStateChecker = goalStateChecker;
            this.Heuristic = heuristic;
        }
    }
}
