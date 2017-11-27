using ArtificialIntelligenceVisualizerLibrary;
using System;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemNQueen
{
    public class FourQueenState : IState
    {
        public List<int> Rows { get; set; }

        public string TextRepresentation
        {
            get
            {
                return "{" + string.Join(",", this.Rows) + "}";
            }
        }

        public FourQueenState()
        {
            this.Rows = new List<int>();
        }

        public override bool Equals(object other)
        {
            FourQueenState otherState = other as FourQueenState;

            if (otherState == null)
            {
                return false;
            }

            if (this.Rows.Count != otherState.Rows.Count)
            {
                return false;
            }

            for (int i = 0; i < this.Rows.Count; i++)
            {
                if (this.Rows[i] != otherState.Rows[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int res = 5;
            for (int i = 0; i < this.Rows.Count; i++)
            {
                res *= 31 + this.Rows[i];
            }

            return res;
        }

        public bool IsUnderAttack(int row)
        {
            for (int i = 0; i < this.Rows.Count; i++)
            {
                //sor
                if (this.Rows[i] == row)
                {
                    return true;
                }

                //átló
                if (Math.Abs(this.Rows[i] - row) == Math.Abs(i - this.Rows.Count))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
