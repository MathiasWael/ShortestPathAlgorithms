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
using ShortestPathAlgorithms.Business;
using System.Threading;

namespace ShortestPathAlgorithms
{
    public partial class ShortestPathUI : Form
    {
        public Algorithms Algorithms;
        private static int _mapHeight = 800;
        private static int _mapWidth = 800;
        private int _buttonHeight;
        private int _buttonWidth;
        private static int _startingX = 175;
        private static int _startingY = 25;

        public ShortestPathUI()
        {
            Algorithms = new Algorithms();
            InitializeComponent();
        }

        private void createButtons(int width, int height)
        {
            _buttonHeight = _mapHeight / height;
            _buttonWidth = _mapWidth / width;

            Point location = new Point(_startingX, _startingY);
            for (int heightIndex = 0; heightIndex < height; heightIndex++)
            {
                for (int widthIndex = 0; widthIndex < width; widthIndex++)
                {
                    Algorithms.AllNodes.Add(new Node(createButton(location)));
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
            dynamicButton.BackColor = Color.White;
            dynamicButton.Click += new EventHandler(nodeClick);
            dynamicButton.MouseEnter += new EventHandler(nodeHoverMouse);
            Controls.Add(dynamicButton);
            return dynamicButton;
        }

        private void nodeHoverMouse(object sender, EventArgs e)
        {
            if(drawModeCheckBox.Checked)
            {
                nodeColouring(Algorithms.AllNodes.Find(x => x.Button == sender as Button));
            }
        }

        private void nodeClick(object sender, EventArgs e)
        {
            if(!drawModeCheckBox.Checked)
            {
                nodeColouring(Algorithms.AllNodes.Find(x => x.Button == sender as Button));
            }
        }

        private void nodeColouring(Node node)
        {
            if(startNodeButton.Checked)
            {
                if (Algorithms.AllNodes.Exists(x => x.Status == Node.NodeStatus.Start))
                {
                    Node previousStartNode = Algorithms.AllNodes.Find(x => x.Status == Node.NodeStatus.Start);
                    previousStartNode.Button.BackColor = Color.White;
                    previousStartNode.Status = Node.NodeStatus.Open;
                }
                node.Status = Node.NodeStatus.Start;
                node.Button.BackColor = Color.Red;
            }
            else if(endNodeButton.Checked)
            {
                node.Status = Node.NodeStatus.End;
                node.Button.BackColor = Color.Green;
            }
            else if(blockNodeButton.Checked)
            {
                node.Status = Node.NodeStatus.Blocked;
                node.Button.BackColor = Color.Black;
            }
            else if(openNodeButton.Checked)
            {
                node.Status = Node.NodeStatus.Open;
                node.Button.BackColor = Color.White;
            }
        }

        private void resetMapButton_Click(object sender, EventArgs e)
        {
            foreach (Node node in Algorithms.AllNodes)
            {
                if(node.Status == Node.NodeStatus.Visited)
                {
                    node.Status = Node.NodeStatus.Open;
                    node.Button.BackColor = Color.White;
                }
                else if(node.Status == Node.NodeStatus.Start)
                {
                    node.Button.BackColor = Color.Red;
                }
                else if(node.Status == Node.NodeStatus.End)
                {
                    node.Button.BackColor = Color.Green;
                }
            }
        }

        private void createMapButton_Click(object sender, EventArgs e)
        {
            foreach (Node node in Algorithms.AllNodes)
            {
                Controls.Remove(node.Button);
            }
            Algorithms.AllNodes.Clear();

            try
            {
                int x = Int32.Parse(noButtonsXTextBox.Text);
                int y = Int32.Parse(noButtonsYTextBox.Text);
                if(x < 2 || y < 2)
                    MessageBox.Show("Minimum 2 in both y and x axis", "Wrong input");
                else
                {
                    createButtons(x, y);
                    Algorithms.LinkNeighbouringNodes(x, y);
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Need to specify how many nodes in y and x axis", "Wrong input");
            }
        }

        private void djikstraButton_Click(object sender, EventArgs e)
        {
            if(startingNodeCheck() && getWaitTime())
            {
                Thread thread = new Thread(() => 
                {
                    Algorithms.Djikstra();
                    updateScore();
                });
                thread.Start();
            }
        }

        private void updateScore()
        {
            if(Algorithms.Sequence.Count != 0)
            {
                djikstraScoreLabel.Invoke(new Action(() => djikstraScoreLabel.Text = "Djikstra: " + Algorithms.Sequence.First().Distance));
            }
            else
            {
                MessageBox.Show("Could not find a path from start to end", "No path found");
            }
        }

        private bool getWaitTime()
        {
            try
            {
                Algorithms.WaitTimeBetweenNodes = Int32.Parse(waitTimeTextBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Need to specify waiting time", "Wrong input");
            }
            return false;
        }

        private bool startingNodeCheck()
        {
            if (!Algorithms.AllNodes.Any(x => x.Status == Node.NodeStatus.Start))
            {
                MessageBox.Show("Need to specify a starting node", "Wrong input");
                return false;
            }
            return true;
        }
    }
}
