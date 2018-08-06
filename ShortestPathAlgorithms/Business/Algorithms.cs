using ShortestPathAlgorithms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathAlgorithms.Business
{
    public class Algorithms
    {
        public List<Node> AllNodes = new List<Node>();
        public static int NoButtonsX = 20;
        public static int NoButtonsY = 20;

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
