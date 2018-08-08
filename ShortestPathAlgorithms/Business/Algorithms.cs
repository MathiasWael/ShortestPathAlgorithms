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

        public void Djikstra()
        {
            List<Node> DjikstaNodes = new List<Node>(AllNodes);
            foreach (Node node in DjikstaNodes)
            {
                node.Distance = 999999999;
                if (node.Status == Node.NodeStatus.Start)
                    node.Distance = 0;
            }

            DjikstaNodes.RemoveAll(x => x.Status == Node.NodeStatus.Blocked);

            while(DjikstaNodes.Count != 0)
            {
                int lowestDistance = DjikstaNodes.Min(x => x.Distance);
                Node lowestDistanceNode = DjikstaNodes.First(x => x.Distance == lowestDistance);
                DjikstaNodes.Remove(lowestDistanceNode);
                lowestDistanceNode.Button.BackColor = System.Drawing.Color.LightBlue;
                Thread.Sleep(250);
                if(lowestDistanceNode.Status == Node.NodeStatus.End)
                    break;

                foreach (Node neighbour in lowestDistanceNode.Neighbours)
                {
                    int distance = lowestDistanceNode.Distance + neighbour.edgeWeight;
                    if(distance < neighbour.Distance)
                    {
                        neighbour.Distance = distance;
                        neighbour.Previous = lowestDistanceNode;
                    }
                }
            }
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
