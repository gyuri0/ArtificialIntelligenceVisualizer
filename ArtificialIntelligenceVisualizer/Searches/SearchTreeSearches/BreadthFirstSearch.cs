using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Searches.SearchTreeSearches
{
    public class BreadthFirstSearch<StateType> : SearchTreeSearch<StateType> where StateType : class, IState
    {
        private Queue<SearchTreeNode<StateType>> elementsToProcess = new Queue<SearchTreeNode<StateType>>();

        public override bool IsCostSearch => false;

        public override bool IsHeuristicSearch => false;

        public BreadthFirstSearch(Problem<StateType> problem) : base(problem)
        {
        }

        protected override SearchTreeNode<StateType> GetNextNodeToExpand()
        {
            if (this.elementsToProcess.Count == 0)
            {
                return null;
            }

            return elementsToProcess.Dequeue();
        }

        protected override bool HasNextNodeToExpand()
        {
            return this.elementsToProcess.Count > 0;
        }

        protected override void NodeFound(SearchTreeNode<StateType> node)
        {
            if (this.GetNodeForState(node.State) == null) // ha még nem létezett
            {
                this.elementsToProcess.Enqueue(node);
                this.AddNewNode(node);
            }
        }
    }
}
