using ArtificialIntelligenceVisualizer.Graph;
using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;
using System.Linq;

namespace ArtificialIntelligenceVisualizer.Searches.Backtrack
{
    public class BackTrack<StateType> : ISearch where StateType : IState
    {
        private Problem<StateType> problem;

        private Dictionary<StateType, DisplayGraphVertex> stateVertexDictionary;

        /// <summary>Állapotok listája ami a jelenleg aktív utat reprezentálja</summary>
        private List<StateType> route;

        /// <summary>
        /// A <see cref="route"/>-hoz tartozó állapotokhoz tartozó indexek listája,
        /// amely azt határozza meg, hogy az adott állapotot melyik operátorral állítottuk elő.
        /// </summary>
        private List<int> lastOperatorIndex;

        public DisplayGraph Graph { get; private set; }

        public SearchStatus Status { get; private set; }

        public bool IsCostSearch => false;

        public bool IsHeuristicSearch => false;

        public BackTrack(Problem<StateType> problem) : base()
        {
            this.problem = problem;

            this.Status = SearchStatus.InProgress;
            this.Graph = new DisplayGraph();
            this.stateVertexDictionary = new Dictionary<StateType, DisplayGraphVertex>();

            this.GenerateDisplayGraph(problem.StartState);

            this.route = new List<StateType> { problem.StartState };
            this.lastOperatorIndex = new List<int> { -1 };
            this.stateVertexDictionary[problem.StartState].VertexStatus = VertexStatus.Marked;
        }

        /// <summary>
        /// Létrehozza az egész gráfot rekurzívan.
        /// </summary>
        /// <param name="state"></param>
        private void GenerateDisplayGraph(StateType state)
        {
            DisplayGraphVertex vertex = new DisplayGraphVertex(state.TextRepresentation);
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
                    this.Graph.AddVertex(childVertex);
                    DisplayGraphEdge edge = new DisplayGraphEdge(vertex, childVertex);
                    this.Graph.AddEdge(edge);
                }
            }
        }

        public void NextStep()
        {
            var lastState = this.route.Last();
            this.lastOperatorIndex[this.route.Count - 1]++;
            if (this.lastOperatorIndex.Last() == this.problem.Operators.Count)
            {
                //Visszalépés
                this.stateVertexDictionary[lastState].VertexStatus = VertexStatus.Simple;

                this.lastOperatorIndex.RemoveAt(this.lastOperatorIndex.Count - 1);
                this.route.RemoveAt(this.route.Count - 1);

                if (this.route.Any())
                {
                    DisplayGraphEdge edgeToSimplify;
                    if (this.Graph.TryGetEdge(this.stateVertexDictionary[this.route.Last()], this.stateVertexDictionary[lastState], out edgeToSimplify))
                    {
                        edgeToSimplify.EdgeStatus = EdgeStatus.Simple;
                    }
                }
                else
                {
                    this.Status = SearchStatus.Finished;
                }

                return;
            }

            var op = problem.Operators[this.lastOperatorIndex[this.route.Count - 1]];

            if (!op.Usable(lastState))
            {
                this.NextStep();
                return;
            }

            StateType newState = op.Apply(lastState);

            if (route.Contains(newState))
            {
                this.NextStep();
                return;
            }

            this.route.Add(newState);
            this.lastOperatorIndex.Add(-1);

            DisplayGraphEdge edgeToMark;
            if (this.Graph.TryGetEdge(this.stateVertexDictionary[lastState], this.stateVertexDictionary[newState], out edgeToMark))
            {
                edgeToMark.EdgeStatus = EdgeStatus.Marked;
            }

            if (this.problem.GoalStateChecker.IsGoalState(newState))
            {
                this.stateVertexDictionary[newState].VertexStatus = VertexStatus.GoalState;
                this.Status = SearchStatus.SolutionFound;
            }
            else
            {
                this.stateVertexDictionary[newState].VertexStatus = VertexStatus.Marked;
            }
        }
    }
}
