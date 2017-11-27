using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;
using System.Text;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemHanoiTower
{
    public class HanoiTowerState : IState
    {
        public List<int>[] Rods { get; private set; }

        public int N { get; private set; }

        public string TextRepresentation
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < this.N; i++)
                {
                    if (i != 0)
                    {
                        sb.Append(',');
                    }
                    sb.Append('{' + string.Join(",", this.Rods[i]) + '}');
                }

                return sb.ToString();
            }
        }

        public HanoiTowerState(int n)
        {
            this.N = n;
            this.Rods = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                this.Rods[i] = new List<int>();
            }

            for (int i = n; i > 0; i--)
            {
                this.Rods[0].Add(i);
            }
        }

        public HanoiTowerState(int n, List<int>[] rods)
        {
            this.N = n;
            this.Rods = rods;
        }

        public override bool Equals(object other)
        {
            HanoiTowerState otherAsState = other as HanoiTowerState;
            if(otherAsState == null)
            {
                return false;
            }

            if(this.N != otherAsState.N)
            {
                return false;
            }

            for (int i = 0; i < N; i++)
            {
                if(this.Rods[i].Count != otherAsState.Rods[i].Count)
                {
                    return false;
                }

                for (int j = 0; j < Rods[i].Count; j++)
                {
                    if(this.Rods[i][j] != otherAsState.Rods[i][j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int res = 5;
            for (int i = 0; i < this.Rods.Length; i++)
            {
                res *= 31 + this.Rods[i].Count;
            }

            return res;
        }
    }
}
