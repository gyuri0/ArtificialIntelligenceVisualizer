namespace ArtificialIntelligenceVisualizerLibrary
{
    /// <summary>
    /// Egy cél állapot validátort reprezántál.
    /// </summary>
    /// <typeparam name="StateType"></typeparam>
    public interface IGoalStateChecker<StateType> where StateType : IState
    {
        /// <summary>
        /// Visszadja, hogy a megadott állapot célállapot-e vagy sem.
        /// </summary>
        /// <param name="state">az állapot melyet validálni szeretnénk</param>
        /// <returns>True, ha célállapot, False, ha nem</returns>
        bool IsGoalState(StateType state);
    }
}
