using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Model
{
    class Node
    {
        public enum NodeStatus { Blocked, Open, Start, End }
        public NodeStatus Status { get; set; }

        public Node()
        {
            Status = NodeStatus.Open;
        }
    }
}
