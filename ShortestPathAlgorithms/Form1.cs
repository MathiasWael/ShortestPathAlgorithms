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
        private static int _noButtonsX = 20;
        private static int _noButtonsY = 20;

        public Form1()
        {
            InitializeComponent();
            createButtons(_noButtonsX, _noButtonsY);
        }

        private void linkNeighbouringNodes()
        {
            int counter = 1;

            for (int i = 0; i < _noButtonsX; i++)
            {
                if(i == 0)
                {

                }
                else if(i == _noButtonsX - 1)
            }

            foreach (Node node in _nodes)
            {
                if(counter == 1 || counter % 20 == 1) //left
                {
                    
                }
                else if(counter % 20 == 0) //right
                {
                    
                }
                if(counter <= 20) //top
                {
                    
                }
                else if(counter >= 380) //bottom
                {
                    
                }
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
