﻿using ShortestPathAlgorithms.Model;
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

        public void CheckNode(Button button)
        {
            button.BackColor = Color.LightBlue;
        }

        private void createButtons(int width, int height)
        {
            _buttonHeight = _mapHeight / Algorithms.NoButtonsY;
            _buttonWidth = _mapWidth / Algorithms.NoButtonsX;

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
                node.Button.BackColor = Color.Gray;
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
                node.Status = Node.NodeStatus.Open;
                node.Button.BackColor = Color.White;
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
                Algorithms.NoButtonsX = Int32.Parse(noButtonsXTextBox.Text);
                Algorithms.NoButtonsY = Int32.Parse(noButtonsYTextBox.Text);
                createButtons(Algorithms.NoButtonsX, Algorithms.NoButtonsY);
                Algorithms.LinkNeighbouringNodes();
            }
            catch(FormatException)
            {
                MessageBox.Show("Need to specify how many nodes in y and x axis", "Wrong input");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Algorithms.Djikstra();
        }
    }
}
