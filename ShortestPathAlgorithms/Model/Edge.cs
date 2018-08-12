using System.Collections.Generic;
using System.Windows.Forms;

namespace ShortestPathAlgorithms.Model
{
    public class Edge
    {
        public int Weight;
        public List<Node> Connections = new List<Node>();
        public Label Label;

        public Edge(Label label, int weight)
        {
            Label = label;
            Weight = weight;
        }
    }
}
