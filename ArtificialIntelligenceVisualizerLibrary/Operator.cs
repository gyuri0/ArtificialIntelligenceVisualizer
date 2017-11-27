namespace ArtificialIntelligenceVisualizerLibrary
{
    /// <summary>
    /// Egy operátort reprezentál egy mesterséges intelligencia problémában.
    /// </summary>
    /// <typeparam name="StateType">Az állapotok típusa, melyre alkalmazható az operátor</typeparam>
    public abstract class Operator<StateType> where StateType : IState
    {
        /// <summary>
        /// Visszadja hogy az operátor teljesíti-e az operátor alkalmazási előfeltételeket.
        /// </summary>
        /// <param name="state">Az állapot melyre használni szeretnénk az operátort</param>
        /// <returns>True, ha az operátor használható; False ha nem.</returns>
        public abstract bool Usable(StateType state);

        /// <summary>
        /// Az operátort alkalmazva létrehoz egy új állapotot.
        /// </summary>
        /// <param name="state">az állapot amelyre alkalmazzuk az operátort</param>
        /// <returns>a létrejött új állapot</returns>
        public abstract StateType Apply(StateType state);

        /// <summary>
        /// Visszaadja az alkalmazandó operátor költségét.
        /// </summary>
        /// <param name="state">az állapot melyre az operátort alkalmazzuk</param>
        /// <returns>az operátor költége</returns>
        public virtual double GetCost(StateType state)
        {
            return 1;
        }
    }
}
