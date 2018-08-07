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
        public int NoButtonsX = 20;
        public int NoButtonsY = 20;
        private Node _startNode;
        

        public void Djikstra()
        {
            foreach (Node node in AllNodes)
            {
                node.Distance = 999999999;
                if (node.Status == Node.NodeStatus.Start)
                    node.Distance = 0;
            }

            AllNodes.RemoveAll(x => x.Status == Node.NodeStatus.Blocked);

            while(AllNodes.Count != 0)
            {
                int lowestDistance = AllNodes.Min(x => x.Distance);
                Node lowestDistanceNode = AllNodes.First(x => x.Distance == lowestDistance);
                AllNodes.Remove(lowestDistanceNode);
                //lowestDistanceNode.Button.BackColor = System.Drawing.Color.LightBlue;
                ShortestPathUI ui = Application.OpenForms["ShortestPathUI"] as ShortestPathUI;
                ui.CheckNode(lowestDistanceNode.Button);
                Thread.Sleep(50);
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

        public void LinkNeighbouringNodes()
        {
            int counter = 0;
            foreach (Node node in AllNodes)
            {
                if (counter <= NoButtonsX) //top row
                {
                    if (counter == 0)
                    {
                        node.Neighbours.Add(AllNodes[counter + 1]);
                        node.Neighbours.Add(AllNodes[counter + NoButtonsX]);
                    }
                    else if (counter == NoButtonsX)
                    {
                        node.Neighbours.Add(AllNodes[counter - 1]);
                        node.Neighbours.Add(AllNodes[counter + NoButtonsX]);
                    }
                    else
                    {
                        node.Neighbours.Add(AllNodes[counter - 1]);
                        node.Neighbours.Add(AllNodes[counter + 1]);
                        node.Neighbours.Add(AllNodes[counter + NoButtonsX]);
                    }
                }
                else if (counter >= NoButtonsX * (NoButtonsY - 1)) //bottom row
                {
                    if (counter == NoButtonsX * (NoButtonsY - 1))
                    {
                        node.Neighbours.Add(AllNodes[counter - NoButtonsX]);
                        node.Neighbours.Add(AllNodes[counter + 1]);
                    }
                    else if (counter == NoButtonsX * NoButtonsY - 1)
                    {
                        node.Neighbours.Add(AllNodes[counter - 1]);
                        node.Neighbours.Add(AllNodes[counter - NoButtonsX]);
                    }
                    else
                    {
                        node.Neighbours.Add(AllNodes[counter - 1]);
                        node.Neighbours.Add(AllNodes[counter + 1]);
                        node.Neighbours.Add(AllNodes[counter - NoButtonsX]);
                    }
                }
                else if (counter % NoButtonsX == NoButtonsX - 1) //right side
                {
                    node.Neighbours.Add(AllNodes[counter - 1]);
                    node.Neighbours.Add(AllNodes[counter + NoButtonsX]);
                    node.Neighbours.Add(AllNodes[counter - NoButtonsX]);
                }
                else if (counter % NoButtonsX == 0) //left side
                {
                    node.Neighbours.Add(AllNodes[counter + 1]);
                    node.Neighbours.Add(AllNodes[counter + NoButtonsX]);
                    node.Neighbours.Add(AllNodes[counter - NoButtonsX]);
                }
                else //middle
                {
                    node.Neighbours.Add(AllNodes[counter - 1]);
                    node.Neighbours.Add(AllNodes[counter + 1]);
                    node.Neighbours.Add(AllNodes[counter + NoButtonsX]);
                    node.Neighbours.Add(AllNodes[counter - NoButtonsX]);
                }
                counter++;
            }
        }

    }
}
