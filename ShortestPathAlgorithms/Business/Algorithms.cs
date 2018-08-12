using ShortestPathAlgorithms.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ShortestPathAlgorithms.Business
{
    public class Algorithms
    {
        public List<Node> AllNodes = new List<Node>();
        public List<Node> Sequence = new List<Node>();
        public int WaitTimeBetweenNodes;

        public void Djikstra()
        {
            List<Node> DjikstraNodes = new List<Node>(AllNodes.FindAll(x => x.Status != Node.NodeStatus.Blocked));

            foreach (Node node in DjikstraNodes)
            {
                node.Distance = int.MaxValue;
                node.Previous = null;
            }
            DjikstraNodes.Find(x => x.Status == Node.NodeStatus.Start).Distance = 0;

            while (DjikstraNodes.Count != 0)
            {
                Thread.Sleep(WaitTimeBetweenNodes);
                Node lowestDistanceNode = DjikstraNodes.First(x => x.Distance == DjikstraNodes.Min(i => i.Distance));
                DjikstraNodes.Remove(lowestDistanceNode);

                if (lowestDistanceNode.Distance == int.MaxValue)
                    break;
                if (lowestDistanceNode.Status == Node.NodeStatus.End)
                {
                    djikstraPath(lowestDistanceNode);
                    break;
                }
                if (lowestDistanceNode.Status != Node.NodeStatus.Start)
                {
                    lowestDistanceNode.Status = Node.NodeStatus.Visited;
                    lowestDistanceNode.Button.BackColor = System.Drawing.Color.DarkOrange;
                }

                foreach (Edge edge in lowestDistanceNode.Edges)
                {
                    Node neighbour = edge.Connections.Find(x => x != lowestDistanceNode);
                    int distance = lowestDistanceNode.Distance + edge.Weight;
                    if (distance < neighbour.Distance)
                    {
                        Thread.Sleep(WaitTimeBetweenNodes);
                        if(neighbour.Status != Node.NodeStatus.End)
                        {
                            neighbour.Status = Node.NodeStatus.Relaxed;
                            neighbour.Button.BackColor = System.Drawing.Color.Yellow;
                        } 
                        neighbour.Distance = distance;
                        neighbour.Previous = lowestDistanceNode;
                    }
                }
            }
        }

        private void djikstraPath(Node target)
        {
            Thread.Sleep(WaitTimeBetweenNodes);
            target.Button.BackColor = System.Drawing.Color.Gray;
            Sequence.Add(target);
            if (target.Previous != null)
                djikstraPath(target.Previous);
        }

    }
}
