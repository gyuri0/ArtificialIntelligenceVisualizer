using ArtificialIntelligenceVisualizerLibrary;
using System;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemJug
{
    public class JugOperator : Operator<JugState>
    {
        public int IndexFrom { get; set; }

        public int IndexTo { get; set; }

        public JugOperator(int indexFrom, int indexTo)
        {
            this.IndexFrom = indexFrom;
            this.IndexTo = indexTo;
        }

        public override JugState Apply(JugState state)
        {
            int valueToPour = 
                Math.Min(state.Values[IndexFrom], JugState.JugSizes[IndexTo] - state.Values[IndexTo]);

            int[] values = new int[3] { state.Values[0], state.Values[1], state.Values[2] };
            values[IndexFrom] -= valueToPour;
            values[IndexTo] += valueToPour;
            return new JugState(values);
        }

        public override bool Usable(JugState state)
        {
            return !state.IsEmpty(IndexFrom) && !state.IsFull(IndexTo);
        }

        public static List<Operator<JugState>> GetAllOperators()
        {
            List<Operator<JugState>> operators = new List<Operator<JugState>>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    operators.Add(new JugOperator(i, j));
                }
            }

            return operators;
        }
    }
}
