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
        private static int _buttonHeight = 40;
        private static int _buttonWidth = 40;
        private static int _startingX = 150;
        private static int _startingY = 25;

        public Form1()
        {
            InitializeComponent();
            createButtons(20, 20);
        }

        private void nodeColouring(Node node)
        {

        }

        private void createButtons(int width, int height)
        {
            Point location = new Point(_startingX, _startingY);
            for (int heightIndex = 0; heightIndex < height; heightIndex++)
            {
                for (int widthIndex = 0; widthIndex < width; widthIndex++)
                {
                    Node node = new Node(createButton(location));
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
