using System.Collections.Generic;
using System.Linq;

namespace ArtificialIntelligenceVisualizerLibrary
{
    /// <summary>
    /// Egy célállapot validátort reprezenetál, melynek felsorolással adjuk meg az összes célállapot.
    /// </summary>
    /// <typeparam name="StateType"></typeparam>
    public class ListingGoalStateChecker<StateType> : IGoalStateChecker<StateType> where StateType : IState
    {
        private IEnumerable<StateType> goalStates;

        /// <summary>
        /// Létrehoz egy új felsorolásos cél állapot validátort.
        /// </summary>
        /// <param name="goalStates">Az összes célállapot felsorolása</param>
        public ListingGoalStateChecker(IEnumerable<StateType> goalStates)
        {
            this.goalStates = goalStates;
        }

        /// <summary>
        /// Meghatározza, hogy a megadott állapot célállapot-e.
        /// </summary>
        /// <param name="state">az állapot melyet validálni szeretnénk</param>
        /// <returns>True, ha célállapot, False, ha nem</returns>
        public bool IsGoalState(StateType state)
        {
            return this.goalStates.Contains(state);
        }
    }
}
