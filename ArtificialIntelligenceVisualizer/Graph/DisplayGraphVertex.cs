using GraphX.PCL.Common.Models;

namespace ArtificialIntelligenceVisualizer.Graph
{
    public class DisplayGraphVertex : VertexBase
    {
        public string Text { get; set; }

        public VertexStatus VertexStatus { get; set; }

        public DisplayGraphVertex(string text, VertexStatus vertexStatus = VertexStatus.Simple)
        {
            this.Text = text;
            this.VertexStatus = vertexStatus;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
