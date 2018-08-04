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
        private Dictionary<Node.NodeStatus, Color> _nodeStatusColour = new Dictionary<Node.NodeStatus, Color> {
            { Node.NodeStatus.Blocked, Color.Gray },
            { Node.NodeStatus.End, Color.Red },
            { Node.NodeStatus.Open, Color.White },
            { Node.NodeStatus.Start, Color.Green } };

        public Form1()
        {
            InitializeComponent();
        }

        private void nodeColouring(Node node)
        {

        }

        private void createButtons(int width, int height)
        {
            int numberOfButtons = width * height;
            for (int i = 0; i < numberOfButtons; i++)
            {
                Node node = new Node();

                i++;
            }
        }

        private void createButton(int x, int y)
        {
            Button dynamicButton = new Button();
            dynamicButton.Location = new Point(x, y); //150, 25
            dynamicButton.Height = 40;
            dynamicButton.Width = 40;
            Controls.Add(dynamicButton);
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
