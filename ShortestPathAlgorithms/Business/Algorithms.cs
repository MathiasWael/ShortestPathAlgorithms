using ShortestPathAlgorithms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathAlgorithms.Business
{
    public class Algorithms
    {
        public List<Node> AllNodes = new List<Node>();
        public List<Node> Sequence = new List<Node>();
        public int WaitTimeBetweenNodes;

        public void Djikstra()
        {
            Node lowestDistanceNode = null;
            List<Node> DjikstraNodes = new List<Node>(AllNodes.FindAll(x => x.Status != Node.NodeStatus.Blocked));

            foreach (Node node in DjikstraNodes)
                node.Distance = 999999999;
            DjikstraNodes.Find(x => x.Status == Node.NodeStatus.Start).Distance = 0;

            while(DjikstraNodes.Count != 0)
            {
                Thread.Sleep(WaitTimeBetweenNodes);

                lowestDistanceNode = DjikstraNodes.First(x => x.Distance == DjikstraNodes.Min(i => i.Distance));
                DjikstraNodes.Remove(lowestDistanceNode);

                if (lowestDistanceNode.Distance == 999999999)
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

                foreach (Node neighbour in lowestDistanceNode.Neighbours)
                {
                    int distance = lowestDistanceNode.Distance + neighbour.EdgeWeight;
                    if(distance < neighbour.Distance)
                    {
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
            if(target.Previous != null)
                djikstraPath(target.Previous);
        }

        public void LinkNeighbouringNodes(int x, int y)
        {
            int counter = 0;
            foreach (Node node in AllNodes)
            {
                if (counter <= x - 1) //top row
                {
                    if (counter == 0)
                    {
                        node.Neighbours.Add(AllNodes[counter + 1]);
                        node.Neighbours.Add(AllNodes[counter + x]);
                    }
                    else if (counter == x - 1)
                    {
                        node.Neighbours.Add(AllNodes[counter - 1]);
                        node.Neighbours.Add(AllNodes[counter + x]);
                    }
                    else
                    {
                        node.Neighbours.Add(AllNodes[counter - 1]);
                        node.Neighbours.Add(AllNodes[counter + 1]);
                        node.Neighbours.Add(AllNodes[counter + x]);
                    }
                }
                else if (counter >= x * (y - 1)) //bottom row
                {
                    if (counter == x * (y - 1))
                    {
                        node.Neighbours.Add(AllNodes[counter - x]);
                        node.Neighbours.Add(AllNodes[counter + 1]);
                    }
                    else if (counter == x * y - 1)
                    {
                        node.Neighbours.Add(AllNodes[counter - 1]);
                        node.Neighbours.Add(AllNodes[counter - x]);
                    }
                    else
                    {
                        node.Neighbours.Add(AllNodes[counter - 1]);
                        node.Neighbours.Add(AllNodes[counter + 1]);
                        node.Neighbours.Add(AllNodes[counter - x]);
                    }
                }
                else if (counter % x == x - 1) //right side
                {
                    node.Neighbours.Add(AllNodes[counter - 1]);
                    node.Neighbours.Add(AllNodes[counter + x]);
                    node.Neighbours.Add(AllNodes[counter - x]);
                }
                else if (counter % x == 0) //left side
                {
                    node.Neighbours.Add(AllNodes[counter + 1]);
                    node.Neighbours.Add(AllNodes[counter + x]);
                    node.Neighbours.Add(AllNodes[counter - x]);
                }
                else //middle
                {
                    node.Neighbours.Add(AllNodes[counter - 1]);
                    node.Neighbours.Add(AllNodes[counter + 1]);
                    node.Neighbours.Add(AllNodes[counter + x]);
                    node.Neighbours.Add(AllNodes[counter - x]);
                }
                counter++;
            }
        }

    }
}
