using ArtificialIntelligenceVisualizerLibrary;

namespace CustomProblemExample3
{
    public class CostExampleState : IState
    {
        public int StateId { get; set; }

        public string TextRepresentation => this.StateId.ToString();

        public CostExampleState(int stateId = 0)
        {
            this.StateId = stateId;
        }

        public override bool Equals(object other)
        {
            CostExampleState otherAsState = other as CostExampleState;

            if (otherAsState == null)
            {
                return false;
            }

            return this.StateId == otherAsState.StateId;
        }

        public override int GetHashCode()
        {
            return this.StateId;
        }

        public bool IsGoalState()
        {
            return this.StateId == 2;
        }
    }
}
