using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace ArtificialIntelligenceVisualizer.Problems.ProblemNQueen
{
    public class FourQueenOperator : Operator<FourQueenState>
    {
        public int Row { get; set; }

        public FourQueenOperator(int row)
        {
            this.Row = row;
        }

        public override bool Usable(FourQueenState state)
        {
            return !state.IsUnderAttack(this.Row);
        }

        public override FourQueenState Apply(FourQueenState state)
        {
            FourQueenState newState = new FourQueenState();
            newState.Rows = new List<int>(state.Rows);
            newState.Rows.Add(Row);

            return newState;
        }

        public static List<Operator<FourQueenState>> GetAllOperators()
        {
            List<Operator<FourQueenState>> allOperator = new List<Operator<FourQueenState>>();

            for (int i = 0; i < 4; i++)
            {
                allOperator.Add(new FourQueenOperator(i));
            }

            return allOperator;
        }
    }
}
