using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathAlgorithms.Model
{
    class Node
    {
        public enum NodeStatus { Blocked, Open, Start, End }
        public NodeStatus Status { get; set; }
        public Button Button { get; set; }

        public Node(Button button)
        {
            Status = NodeStatus.Open;
            Button = button;
        }
    }
}
