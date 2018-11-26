using ShortestPathAlgorithms.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ShortestPathAlgorithms.Business;
using System.Threading;

namespace ShortestPathAlgorithms
{
    public partial class ShortestPathUI : Form
    {
        private Algorithms Algorithms;
        private Random random;
        private List<Label> labels;

        private static int _mapHeight = 800;
        private static int _mapWidth = 800;
        private static int _startingX = 175;
        private static int _startingY = 25;

        private int _buttonHeight;
        private int _buttonWidth;
        private int noNodesX;
        private int noNodesY;

        public ShortestPathUI()
        {
            Algorithms = new Algorithms();
            labels = new List<Label>();
            random = new Random();
            InitializeComponent();
        }

        #region ClickHandlers
        private void createMapButton_Click(object sender, EventArgs e)
        {
            foreach (Node node in Algorithms.AllNodes)
                Controls.Remove(node.Button);
            foreach (Label label in labels)
                Controls.Remove(label);
            Algorithms.AllNodes.Clear();

            try
            {
                noNodesX = int.Parse(noButtonsXTextBox.Text);
                noNodesY = int.Parse(noButtonsYTextBox.Text);
                if (noNodesX < 2 || noNodesY < 2)
                    MessageBox.Show("Minimum 2 in both y and x axis", "Wrong input");
                else if (noNodesX > 30 || noNodesY > 30)
                    MessageBox.Show("Max. 30 in both y and x axis", "Wrong input");
                else
                {
                    createButtons();
                    createLabels();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Need to specify how many nodes in y and x axis", "Wrong input");
            }
        }

        private void resetMapButton_Click(object sender, EventArgs e)
        {
            foreach (Node node in Algorithms.AllNodes)
            {
                if (node.Status == Node.NodeStatus.Visited || node.Status == Node.NodeStatus.Relaxed)
                {
                    node.Status = Node.NodeStatus.Open;
                    node.Button.BackColor = Color.White;
                }
                else if (node.Status == Node.NodeStatus.Start)
                    node.Button.BackColor = Color.Red;
                else if (node.Status == Node.NodeStatus.End)
                    node.Button.BackColor = Color.Green;
            }
        }

        private void djikstraButton_Click(object sender, EventArgs e)
        {
            if (startingNodeCheck() && getWaitTime())
            {
                Thread thread = new Thread(Algorithms.Djikstra);
                thread.Start();
            }
        }

        private void nodeHoverMouse(object sender, EventArgs e)
        {
            if (drawModeCheckBox.Checked)
                nodeColouring(Algorithms.AllNodes.Find(x => x.Button == sender as Button));
        }

        private void nodeClick(object sender, EventArgs e)
        {
            if (!drawModeCheckBox.Checked)
                nodeColouring(Algorithms.AllNodes.Find(x => x.Button == sender as Button));
        }
        #endregion

        #region MapCreation
        private void createLabels()
        {
            int counter = 0;
            foreach (Node node in Algorithms.AllNodes)
            {
                int weight = getRandomWeight();
                if (counter <= noNodesX - 1)
                {
                    createLabelsTopRow(node, counter);
                }
                else if (counter >= noNodesX * (noNodesY - 1))
                {
                    createLabelsBottomRow(node, counter);
                }
                else if (counter % noNodesX == noNodesX - 1)
                {
                    createLabelsRightSide(node, counter);
                }
                else if (counter % noNodesX == 0)
                {
                    createLabelsLeftSide(node, counter);
                }
                else
                {
                    createLabelsMiddle(node, counter);
                }
                counter++;
            }
        }

        private void createButtons()
        {
            _buttonHeight = _mapHeight / noNodesY - 10;
            _buttonWidth = _mapWidth / noNodesX - 10;

            Point location = new Point(_startingX, _startingY);
            for (int heightIndex = 0; heightIndex < noNodesY; heightIndex++)
            {
                for (int widthIndex = 0; widthIndex < noNodesX; widthIndex++)
                {
                    Algorithms.AllNodes.Add(new Node(createButton(location)));
                    location.X += _buttonWidth + 13;
                }
                location.X = _startingX;
                location.Y += _buttonHeight + 13;
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

        private void nodeColouring(Node node)
        {
            if (startNodeButton.Checked)
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
            else if (endNodeButton.Checked)
            {
                node.Status = Node.NodeStatus.End;
                node.Button.BackColor = Color.Green;
            }
            else if (blockNodeButton.Checked)
            {
                node.Status = Node.NodeStatus.Blocked;
                node.Button.BackColor = Color.Black;
            }
            else if (openNodeButton.Checked)
            {
                node.Status = Node.NodeStatus.Open;
                node.Button.BackColor = Color.White;
            }
        }
        #endregion

        #region LabelHelpers
        private void createLabelsTopRow(Node node, int counter)
        {
            if (counter == 0)
            {
                createLabelRight(node.Button.Location, counter);
                createLabelDown(node.Button.Location, counter);
            }
            else if (counter == noNodesX - 1)
                createLabelDown(node.Button.Location, counter);
            else
            {
                createLabelRight(node.Button.Location, counter);
                createLabelDown(node.Button.Location, counter);
            }
        }

        private void createLabelsBottomRow(Node node, int counter)
        {
            if (counter == noNodesX * (noNodesY - 1))
                createLabelRight(node.Button.Location, counter);
            else if (!(counter == noNodesX * noNodesY - 1))
                createLabelRight(node.Button.Location, counter);
        }

        private void createLabelsRightSide(Node node, int counter)
        {
            createLabelDown(node.Button.Location, counter);
        }

        private void createLabelsLeftSide(Node node, int counter)
        {
            createLabelRight(node.Button.Location, counter);
            createLabelDown(node.Button.Location, counter);
        }

        private void createLabelsMiddle(Node node, int counter)
        {
            createLabelRight(node.Button.Location, counter);
            createLabelDown(node.Button.Location, counter);
        }

        private void createLabelRight(Point point, int counter)
        {
            int weight = getRandomWeight();
            point.X += _buttonWidth;
            point.Y += _buttonHeight / 2 - 7;
            Label dynamicLabel = new Label();
            Size size = new Size();
            size.Height = 10;
            size.Width = 10;
            dynamicLabel.AutoSize = false;
            dynamicLabel.Font = new Font("Arial", 6);
            dynamicLabel.Size = size;
            dynamicLabel.Location = point;
            dynamicLabel.Text = weight.ToString();

            Edge edgeRight = new Edge(dynamicLabel, weight);
            edgeRight.Connections.Add(Algorithms.AllNodes[counter]);
            edgeRight.Connections.Add(Algorithms.AllNodes[counter + 1]);
            Algorithms.AllNodes[counter].Edges.Add(edgeRight);
            Algorithms.AllNodes[counter + 1].Edges.Add(edgeRight);

            Controls.Add(dynamicLabel);
            labels.Add(dynamicLabel);
        }

        private void createLabelDown(Point point, int counter)
        {
            int weight = getRandomWeight();
            point.X += _buttonWidth / 2 - 5;
            point.Y += _buttonHeight;
            Label dynamicLabel = new Label();
            Size size = new Size();
            size.Height = 10;
            size.Width = 10;
            dynamicLabel.AutoSize = false;
            dynamicLabel.Font = new Font("Arial", 6);
            dynamicLabel.Size = size;
            dynamicLabel.Location = point;
            dynamicLabel.Text = weight.ToString();

            Edge edgeDown = new Edge(dynamicLabel, weight);
            edgeDown.Connections.Add(Algorithms.AllNodes[counter]);
            edgeDown.Connections.Add(Algorithms.AllNodes[counter + noNodesX]);
            Algorithms.AllNodes[counter].Edges.Add(edgeDown);
            Algorithms.AllNodes[counter + noNodesX].Edges.Add(edgeDown);

            Controls.Add(dynamicLabel);
            labels.Add(dynamicLabel);
        }
        #endregion

        private int getRandomWeight()
        {
            return random.Next(1, 10);
        }

        private bool getWaitTime()
        {
            try
            {
                Algorithms.WaitTimeBetweenNodes = int.Parse(waitTimeTextBox.Text);
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
            if (!Algorithms.AllNodes.Any(x => x.Status == Node.NodeStatus.Start) || !Algorithms.AllNodes.Any(x => x.Status == Node.NodeStatus.End))
            {
                MessageBox.Show("Need to specify a starting and end node", "Wrong input");
                return false;
            }
            return true;
        }
    }
}
