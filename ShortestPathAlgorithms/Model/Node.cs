using System.Collections.Generic;
using System.Windows.Forms;

namespace ShortestPathAlgorithms.Model
{
    public class Node
    {
        public enum NodeStatus { Blocked, Open, Start, End, Visited, Relaxed}
        public NodeStatus Status { get; set; }
        public Button Button { get; set; }
        public List<Edge> Edges = new List<Edge>();
        public int Distance;
        public Node Previous;

        public Node(Button button)
        {
            Status = NodeStatus.Open;
            Button = button;
        }
    }
}
