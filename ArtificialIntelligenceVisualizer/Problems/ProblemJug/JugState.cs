using ArtificialIntelligenceVisualizerLibrary;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemJug
{
    public class JugState : IState
    {
        public int[] Values { get; private set; }

        public static readonly int[] JugSizes = new int[3] { 3, 5, 8 };

        public string TextRepresentation
        {
            get
            {
                return "{" + string.Join(",", this.Values) + "}";
            }
        }

        public JugState(int[] values)
        {
            this.Values = values;
        }

        public bool IsEmpty(int index)
        {
            return this.Values[index] == 0;
        }

        public bool IsFull(int index)
        {
            return this.Values[index] == JugState.JugSizes[index];
        }

        public override int GetHashCode()
        {
            return 3 * this.Values[0] + 5 * this.Values[1] + 7 * this.Values[2];
        }

        public override bool Equals(object other)
        {
            JugState otherState = other as JugState;

            if (otherState == null)
            {
                return false;
            }

            for (int i = 0; i < this.Values.Length; i++)
            {
                if (this.Values[i] != otherState.Values[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
