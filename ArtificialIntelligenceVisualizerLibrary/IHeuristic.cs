namespace ArtificialIntelligenceVisualizerLibrary
{
    /// <summary>
    /// Egy heurisztikát reprezentál egy mesterséges intelligencia problémán.
    /// </summary>
    /// <typeparam name="StateType">Az állapotok típusa</typeparam>
    public interface IHeuristic<StateType>
    {
        /// <summary>
        /// Meghatározza egy állapot heurisztikus értékét.
        /// </summary>
        /// <param name="state">az állapot, amelynek a heurisztikus értékét szeretnénk meghatározni</param>
        /// <returns>a heurisztikus érték</returns>
        double GetHeuristicValue(StateType state);
    }
}
