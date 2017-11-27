using GraphX.PCL.Common.Models;

namespace ArtificialIntelligenceVisualizer.Graph
{
    public class DisplayGraphEdge : EdgeBase<DisplayGraphVertex>
    {
        public EdgeStatus EdgeStatus { get; set; }

        public DisplayGraphEdge(DisplayGraphVertex source, DisplayGraphVertex target, string text = "")
            : base(source, target)
        {
            this.Text = text;
            this.EdgeStatus = EdgeStatus.Simple;
        }

        public DisplayGraphEdge()
            : base(null, null, 1)
        {
            this.EdgeStatus = EdgeStatus.Simple;
        }

        public string Text { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
