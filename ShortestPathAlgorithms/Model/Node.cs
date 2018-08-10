using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathAlgorithms.Model
{
    public class Node
    {
        public enum NodeStatus { Blocked, Open, Start, End, Visited}
        public NodeStatus Status { get; set; }
        public Button Button { get; set; }
        public List<Node> Neighbours = new List<Node>();
        public int Distance;
        public int EdgeWeight = 1;
        public Node Previous;

        public Node(Button button)
        {
            Status = NodeStatus.Open;
            Button = button;
        }
    }
}
