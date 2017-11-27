using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ArtificialIntelligenceVisualizer.Searches.SearchTreeSearches
{
    public class OptimalSearch<StateType> : SearchTreeSearch<StateType> where StateType : class, IState
    {
        private List<SearchTreeNode<StateType>> elementsToProcess = new List<SearchTreeNode<StateType>>();

        private IComparer<SearchTreeNode<StateType>> comparer;

        public OptimalSearch(Problem<StateType> problem) : base(problem)
        {
            this.comparer = Comparer<SearchTreeNode<StateType>>.Create((x, y) => x.Cost.CompareTo(y.Cost));
        }

        public override bool IsCostSearch => true;

        public override bool IsHeuristicSearch => false;

        protected override SearchTreeNode<StateType> GetNextNodeToExpand()
        {
            this.elementsToProcess.Sort(this.comparer);

            var minCostNode = this.elementsToProcess.First();
            this.elementsToProcess.Remove(minCostNode);

            return minCostNode;
        }

        protected override bool HasNextNodeToExpand()
        {
            return this.elementsToProcess.Any();
        }

        protected override void NodeFound(SearchTreeNode<StateType> node)
        {
            var nodeInDataBase = this.GetNodeForState(node.State);

            if (nodeInDataBase != null && node.Cost < nodeInDataBase.Cost)
            {
                this.elementsToProcess.Remove(nodeInDataBase);
                this.RemoveNode(nodeInDataBase);
            }

            if (nodeInDataBase == null || nodeInDataBase.Cost > node.Cost)
            {
                this.elementsToProcess.Add(node);
                this.AddNewNode(node);
            }
        }
    }
}
