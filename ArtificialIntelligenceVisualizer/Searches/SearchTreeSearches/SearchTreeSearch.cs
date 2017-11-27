using ArtificialIntelligenceVisualizer.Graph;
using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Searches.SearchTreeSearches
{
    public abstract class SearchTreeSearch<StateType> : ISearch where StateType : class, IState
    {
        public DisplayGraph Graph { get; private set; }

        public SearchStatus Status { get; private set; }

        public abstract bool IsCostSearch { get; }

        public abstract bool IsHeuristicSearch { get; }

        private Problem<StateType> Problem { get; set; }

        private Dictionary<StateType, DisplayGraphVertex> stateVertexDictionary;

        private Dictionary<StateType, SearchTreeNode<StateType>> stateNodeDictionary;

        private SearchTreeNode<StateType> selectedNodeToExpand;

        public SearchTreeSearch(Problem<StateType> problem)
        {
            this.Status = SearchStatus.InProgress;
            this.Problem = problem;
            this.Graph = new DisplayGraph();
            this.stateVertexDictionary = new Dictionary<StateType, DisplayGraphVertex>();
            this.stateNodeDictionary = new Dictionary<StateType, SearchTreeNode<StateType>>();

            SearchTreeNode<StateType> startNode = new SearchTreeNode<StateType>(problem.StartState, null);
            this.NodeFound(startNode);
        }

        public void NextStep()
        {
            if (this.selectedNodeToExpand == null)
            {
                this.selectedNodeToExpand = this.GetNextNodeToExpand();
                this.stateVertexDictionary[this.selectedNodeToExpand.State].VertexStatus = VertexStatus.SelectedToExpand;

                return;
            }

            foreach (var op in Problem.Operators)
            {
                if (op.Usable(this.selectedNodeToExpand.State))
                {
                    StateType newState = op.Apply(this.selectedNodeToExpand.State);
                    var newNode = new SearchTreeNode<StateType>(newState, this.selectedNodeToExpand);

                    if (this.IsCostSearch)
                    {
                        newNode.Cost = this.selectedNodeToExpand.Cost + op.GetCost(this.selectedNodeToExpand.State);
                    }

                    if (this.IsHeuristicSearch)
                    {
                        newNode.HeuristicValue = this.Problem.Heuristic.GetHeuristicValue(newState);
                    }

                    this.NodeFound(newNode);
                }
            }

            if (this.Problem.GoalStateChecker.IsGoalState(this.selectedNodeToExpand.State))
            {
                this.stateVertexDictionary[this.selectedNodeToExpand.State].VertexStatus = VertexStatus.GoalState;
                this.Status = SearchStatus.SolutionFound;
            }
            else
            {
                this.stateVertexDictionary[this.selectedNodeToExpand.State].VertexStatus = VertexStatus.Marked;
            }

            this.selectedNodeToExpand = null;

            if (!this.HasNextNodeToExpand())
            {
                this.Status = SearchStatus.Finished;
            }
        }

        protected SearchTreeNode<StateType> GetNodeForState(StateType state)
        {
            if (this.stateNodeDictionary.ContainsKey(state))
            {
                return this.stateNodeDictionary[state];
            }

            return null;
        }

        protected void AddNewNode(SearchTreeNode<StateType> node)
        {
            string nodeText = node.State.TextRepresentation;

            if (this.IsCostSearch)
            {
                nodeText += "\nKöltség: " + node.Cost;
            }

            if (this.IsHeuristicSearch)
            {
                nodeText += "\nHeurisztikus érték: " + node.HeuristicValue;
            }

            if (this.IsCostSearch && this.IsHeuristicSearch)
            {
                nodeText += "\nBecsült költség: " + node.EstimatedCost;
            }

            DisplayGraphVertex vertex = new DisplayGraphVertex(nodeText);
            this.Graph.AddVertex(vertex);

            if (node.Parent != null)
            {
                DisplayGraphEdge edge;
                if (this.IsCostSearch)
                {
                    string edgeLabel = (node.Cost - node.Parent.Cost).ToString();
                    edge = new DisplayGraphEdge(this.stateVertexDictionary[node.Parent.State], vertex, edgeLabel);
                }
                else
                {
                    edge = new DisplayGraphEdge(this.stateVertexDictionary[node.Parent.State], vertex);
                }

                this.Graph.AddEdge(edge);
            }

            this.stateVertexDictionary.Add(node.State, vertex);
            this.stateNodeDictionary.Add(node.State, node);
        }

        protected void RemoveNode(SearchTreeNode<StateType> node)
        {
            var vertex = this.stateVertexDictionary[node.State];
            this.Graph.RemoveVertex(vertex);
            this.stateVertexDictionary.Remove(node.State);
            this.stateNodeDictionary.Remove(node.State);
        }


        protected abstract bool HasNextNodeToExpand();

        protected abstract SearchTreeNode<StateType> GetNextNodeToExpand();

        protected abstract void NodeFound(SearchTreeNode<StateType> node);
    }
}
