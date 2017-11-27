using ArtificialIntelligenceVisualizer.Graph;
using GraphX.PCL.Common.Enums;
using GraphX.PCL.Logic.Algorithms.LayoutAlgorithms;
using GraphX.PCL.Logic.Algorithms.OverlapRemoval;
using GraphX.PCL.Logic.Models;

namespace ArtificialIntelligenceVisualizer.UI
{
    public class GXLogicCore : GXLogicCore<DisplayGraphVertex, DisplayGraphEdge, DisplayGraph>
    {
        public GXLogicCore(LayoutType layoutType, DisplayGraph graph)
        {
            switch (layoutType)
            {
                case LayoutType.TreeLayout:
                    this.DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.EfficientSugiyama;
                    this.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.EfficientSugiyama);
                    ((EfficientSugiyamaLayoutParameters)this.DefaultLayoutAlgorithmParams).LayerDistance = 150;
                    ((EfficientSugiyamaLayoutParameters)this.DefaultLayoutAlgorithmParams).OptimizeWidth = false;
                    //((EfficientSugiyamaLayoutParameters)LogicCore.DefaultLayoutAlgorithmParams).MinimizeEdgeLength = false;
                    ((EfficientSugiyamaLayoutParameters)this.DefaultLayoutAlgorithmParams).EdgeRouting = SugiyamaEdgeRoutings.Traditional;
                    ((EfficientSugiyamaLayoutParameters)this.DefaultLayoutAlgorithmParams).PositionMode = 2;
                    break;
                case LayoutType.GraphLayout:
                    this.DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.LinLog;
                    this.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.LinLog);
                    ((LinLogLayoutParameters)this.DefaultLayoutAlgorithmParams).Seed = 0;
                    break;
            }

            this.DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA;
            this.DefaultOverlapRemovalAlgorithmParams =
                                this.AlgorithmFactory.CreateOverlapRemovalParameters(OverlapRemovalAlgorithmTypeEnum.FSA);
            ((OverlapRemovalParameters)this.DefaultOverlapRemovalAlgorithmParams).HorizontalGap = 50;
            ((OverlapRemovalParameters)this.DefaultOverlapRemovalAlgorithmParams).VerticalGap = 50;

            this.DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.None;
            this.Graph = graph;
        }
    }
}
