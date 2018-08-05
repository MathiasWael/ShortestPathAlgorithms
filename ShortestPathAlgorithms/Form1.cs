using ShortestPathAlgorithms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathAlgorithms
{
    public partial class Form1 : Form
    {
        private static Dictionary<Node.NodeStatus, Color> _nodeStatusColour = new Dictionary<Node.NodeStatus, Color> {
            { Node.NodeStatus.Blocked, Color.Gray },
            { Node.NodeStatus.End, Color.Red },
            { Node.NodeStatus.Open, Color.White },
            { Node.NodeStatus.Start, Color.Green } };
        private List<Node> _nodes = new List<Node>();
        private static int _buttonHeight = 40;
        private static int _buttonWidth = 40;
        private static int _startingX = 150;
        private static int _startingY = 25;

        public Form1()
        {
            InitializeComponent();
            createButtons(20, 20);
        }

        private void linkNeighbouringNodes()
        {
            int counter = 0;
            foreach (Node node in _nodes)
            {
                node.Neighbours.Add(_nodes[counter + 1]);
                counter++;
            }
        }

        private void createButtons(int width, int height)
        {
            Point location = new Point(_startingX, _startingY);
            for (int heightIndex = 0; heightIndex < height; heightIndex++)
            {
                for (int widthIndex = 0; widthIndex < width; widthIndex++)
                {
                    _nodes.Add(new Node(createButton(location)));
                    location.X += _buttonWidth;
                }
                location.X = _startingX;
                location.Y += _buttonHeight;
            }
        }

        private Button createButton(Point point)
        {
            Button dynamicButton = new Button();
            dynamicButton.Location = point;
            dynamicButton.Height = _buttonHeight;
            dynamicButton.Width = _buttonWidth;
            Controls.Add(dynamicButton);
            return dynamicButton;
        }

        private void nodeColouring(Node node)
        {

        }

        private void startNodeButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void endNodeButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void blockNodeButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
