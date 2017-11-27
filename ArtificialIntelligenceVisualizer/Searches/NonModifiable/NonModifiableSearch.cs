using ArtificialIntelligenceVisualizer.Graph;
using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Searches.NonModifiable
{
    public abstract class NonModifiableSearch<StateType> : ISearch where StateType : IState
    {
        private StateType currentState;

        private Dictionary<StateType, DisplayGraphVertex> stateVertexDictionary;

        protected Problem<StateType> problem;

        public DisplayGraph Graph { get; private set; }

        public SearchStatus Status { get; private set; }

        public abstract bool IsCostSearch { get; }

        public abstract bool IsHeuristicSearch { get; }

        public NonModifiableSearch(Problem<StateType> problem)
        {
            this.problem = problem;
            this.Graph = new DisplayGraph();
            this.stateVertexDictionary = new Dictionary<StateType, DisplayGraphVertex>();

            this.GenerateDisplayGraph(problem.StartState);
            this.currentState = problem.StartState;
            this.stateVertexDictionary[this.currentState].VertexStatus = VertexStatus.Marked;
        }

        /// <summary>
        /// Létrehozza az egész gráfot rekurzívan.
        /// </summary>
        /// <param name="state"></param>
        private void GenerateDisplayGraph(StateType state)
        {
            string nodeText = state.TextRepresentation;
            if (this.IsHeuristicSearch)
            {
                nodeText += "\nHeurisztikus érték: " + this.problem.Heuristic.GetHeuristicValue(state);
            }

            DisplayGraphVertex vertex = new DisplayGraphVertex(nodeText);

            this.Graph.AddVertex(vertex);
            this.stateVertexDictionary.Add(state, vertex);

            foreach (var op in problem.Operators)
            {
                if (op.Usable(state))
                {
                    StateType newState = op.Apply(state);

                    if (!this.stateVertexDictionary.ContainsKey(newState))
                    {
                        this.GenerateDisplayGraph(newState);
                    }

                    DisplayGraphVertex childVertex = this.stateVertexDictionary[newState];
                    DisplayGraphEdge edge = new DisplayGraphEdge(vertex, childVertex);
                    this.Graph.AddEdge(edge);
                }
            }
        }

        protected abstract StateType GetNextState(StateType currentState);

        public void NextStep()
        {
            StateType nextState = this.GetNextState(this.currentState);

            if (nextState == null)
            {
                this.Status = SearchStatus.Finished;
            }
            else
            {
                this.stateVertexDictionary[this.currentState].VertexStatus = VertexStatus.Simple;
                
                this.currentState = nextState;

                if (this.problem.GoalStateChecker.IsGoalState(this.currentState))
                {
                    this.Status = SearchStatus.SolutionFound;
                    this.stateVertexDictionary[nextState].VertexStatus = VertexStatus.GoalState;
                }
                else
                {
                    this.stateVertexDictionary[nextState].VertexStatus = VertexStatus.Marked;
                }
            }
        }
    }
}
