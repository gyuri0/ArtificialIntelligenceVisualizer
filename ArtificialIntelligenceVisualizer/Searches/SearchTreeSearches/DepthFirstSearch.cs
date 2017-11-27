using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Searches.SearchTreeSearches
{
    public class DepthFirstSearch<StateType> : SearchTreeSearch<StateType> where StateType : class, IState
    {
        private Stack<SearchTreeNode<StateType>> elementToProcess = new Stack<SearchTreeNode<StateType>>();

        public DepthFirstSearch(Problem<StateType> problem) : base(problem)
        {
        }

        public override bool IsCostSearch => false;

        public override bool IsHeuristicSearch => false;

        protected override SearchTreeNode<StateType> GetNextNodeToExpand()
        {
            return this.elementToProcess.Pop();
        }

        protected override bool HasNextNodeToExpand()
        {
            return this.elementToProcess.Count > 0;
        }

        protected override void NodeFound(SearchTreeNode<StateType> node)
        {
            if (this.GetNodeForState(node.State) == null) // ha még nem létezett
            {
                this.elementToProcess.Push(node);
                this.AddNewNode(node);
            }
        }
    }
}
