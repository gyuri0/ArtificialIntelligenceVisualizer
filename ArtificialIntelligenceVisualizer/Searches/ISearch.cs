using ArtificialIntelligenceVisualizer.Graph;
namespace ArtificialIntelligenceVisualizer.Searches
{
    /// <summary>Egy keresőt reprezentál egy konkrét mesterséges intelligencia problémán.</summary>
    public interface ISearch
    {
        /// <summary>
        /// A keresési problémához tartozó gráf.
        /// </summary>
        DisplayGraph Graph { get; }

        SearchStatus Status { get; }

        /// <summary>Végrehajtja a keresés következő lépését.</summary>
        void NextStep();

        bool IsCostSearch { get; }

        bool IsHeuristicSearch { get; }
    }
}
