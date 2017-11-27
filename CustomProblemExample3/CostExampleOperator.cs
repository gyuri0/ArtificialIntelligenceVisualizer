using ArtificialIntelligenceVisualizerLibrary;
using System.Collections.Generic;

namespace CustomProblemExample3
{
    public class CostExampleOperator : Operator<CostExampleState>
    {
        private int goalStateId;

        public CostExampleOperator(int goalStateId)
        {
            this.goalStateId = goalStateId;
        }

        public override CostExampleState Apply(CostExampleState state)
        {
            return new CostExampleState(goalStateId);
        }

        public override double GetCost(CostExampleState state)
        {
            if(state.StateId == 0 && this.goalStateId == 1)
            {
                return 2;
            }

            if(state.StateId == 0 && this.goalStateId == 2)
            {
                return 4;
            }

            if(state.StateId == 1 && this.goalStateId == 2)
            {
                return 1;
            }

            return double.PositiveInfinity;
        }

        public override bool Usable(CostExampleState state)
        {
            if(this.GetCost(state) == double.PositiveInfinity)
            {
                return false;
            }

            return true;
        }

        public static List<Operator<CostExampleState>> GetAllOperators()
        {
            return new List<Operator<CostExampleState>>() { new CostExampleOperator(1), new CostExampleOperator(2) };
        }
    }
}
