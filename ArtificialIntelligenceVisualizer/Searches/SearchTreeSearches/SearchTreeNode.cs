using ArtificialIntelligenceVisualizerLibrary;

namespace ArtificialIntelligenceVisualizer.Searches.SearchTreeSearches
{
    public class SearchTreeNode<StateType> where StateType : IState
    {
        public StateType State { get; private set; }

        public SearchTreeNode<StateType> Parent { get; private set; }

        public double Cost { get; set; }

        public double HeuristicValue { get; set; }

        public double EstimatedCost
        {
            get
            {
                return this.Cost + HeuristicValue;
            }
        }

        public SearchTreeNode(StateType state, SearchTreeNode<StateType> parent)
        {
            this.State = state;
            this.Parent = parent;
        }

        public override bool Equals(object obj)
        {
            SearchTreeNode<StateType> otherNode = obj as SearchTreeNode<StateType>;

            if (otherNode == null)
            {
                return false;
            }

            return this.State.Equals(otherNode.State);
        }

        public override int GetHashCode()
        {
            return this.State.GetHashCode();
        }
    }
}
