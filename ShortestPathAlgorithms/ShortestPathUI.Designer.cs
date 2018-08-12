namespace ShortestPathAlgorithms
{
    partial class ShortestPathUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startNodeButton = new System.Windows.Forms.RadioButton();
            this.endNodeButton = new System.Windows.Forms.RadioButton();
            this.blockNodeButton = new System.Windows.Forms.RadioButton();
            this.openNodeButton = new System.Windows.Forms.RadioButton();
            this.drawModeCheckBox = new System.Windows.Forms.CheckBox();
            this.resetMapButton = new System.Windows.Forms.Button();
            this.createMapButton = new System.Windows.Forms.Button();
            this.noButtonsYTextBox = new System.Windows.Forms.TextBox();
            this.noButtonsXTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.djikstraButton = new System.Windows.Forms.Button();
            this.waitTimeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startNodeButton
            // 
            this.startNodeButton.AutoSize = true;
            this.startNodeButton.Location = new System.Drawing.Point(12, 92);
            this.startNodeButton.Name = "startNodeButton";
            this.startNodeButton.Size = new System.Drawing.Size(47, 17);
            this.startNodeButton.TabIndex = 0;
            this.startNodeButton.TabStop = true;
            this.startNodeButton.Text = "Start";
            this.startNodeButton.UseVisualStyleBackColor = true;
            // 
            // endNodeButton
            // 
            this.endNodeButton.AutoSize = true;
            this.endNodeButton.Location = new System.Drawing.Point(12, 116);
            this.endNodeButton.Name = "endNodeButton";
            this.endNodeButton.Size = new System.Drawing.Size(44, 17);
            this.endNodeButton.TabIndex = 1;
            this.endNodeButton.TabStop = true;
            this.endNodeButton.Text = "End";
            this.endNodeButton.UseVisualStyleBackColor = true;
            // 
            // blockNodeButton
            // 
            this.blockNodeButton.AutoSize = true;
            this.blockNodeButton.Location = new System.Drawing.Point(12, 139);
            this.blockNodeButton.Name = "blockNodeButton";
            this.blockNodeButton.Size = new System.Drawing.Size(52, 17);
            this.blockNodeButton.TabIndex = 2;
            this.blockNodeButton.TabStop = true;
            this.blockNodeButton.Text = "Block";
            this.blockNodeButton.UseVisualStyleBackColor = true;
            // 
            // openNodeButton
            // 
            this.openNodeButton.AutoSize = true;
            this.openNodeButton.Location = new System.Drawing.Point(12, 162);
            this.openNodeButton.Name = "openNodeButton";
            this.openNodeButton.Size = new System.Drawing.Size(51, 17);
            this.openNodeButton.TabIndex = 3;
            this.openNodeButton.TabStop = true;
            this.openNodeButton.Text = "Open";
            this.openNodeButton.UseVisualStyleBackColor = true;
            // 
            // drawModeCheckBox
            // 
            this.drawModeCheckBox.AutoSize = true;
            this.drawModeCheckBox.Location = new System.Drawing.Point(12, 185);
            this.drawModeCheckBox.Name = "drawModeCheckBox";
            this.drawModeCheckBox.Size = new System.Drawing.Size(81, 17);
            this.drawModeCheckBox.TabIndex = 6;
            this.drawModeCheckBox.Text = "Draw Mode";
            this.drawModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetMapButton
            // 
            this.resetMapButton.Location = new System.Drawing.Point(93, 51);
            this.resetMapButton.Name = "resetMapButton";
            this.resetMapButton.Size = new System.Drawing.Size(75, 23);
            this.resetMapButton.TabIndex = 7;
            this.resetMapButton.Text = "Clear Map";
            this.resetMapButton.UseVisualStyleBackColor = true;
            this.resetMapButton.Click += new System.EventHandler(this.resetMapButton_Click);
            // 
            // createMapButton
            // 
            this.createMapButton.Location = new System.Drawing.Point(12, 51);
            this.createMapButton.Name = "createMapButton";
            this.createMapButton.Size = new System.Drawing.Size(75, 23);
            this.createMapButton.TabIndex = 8;
            this.createMapButton.Text = "Create Map";
            this.createMapButton.UseVisualStyleBackColor = true;
            this.createMapButton.Click += new System.EventHandler(this.createMapButton_Click);
            // 
            // noButtonsYTextBox
            // 
            this.noButtonsYTextBox.Location = new System.Drawing.Point(90, 25);
            this.noButtonsYTextBox.Name = "noButtonsYTextBox";
            this.noButtonsYTextBox.Size = new System.Drawing.Size(69, 20);
            this.noButtonsYTextBox.TabIndex = 9;
            this.noButtonsYTextBox.Text = "15";
            // 
            // noButtonsXTextBox
            // 
            this.noButtonsXTextBox.Location = new System.Drawing.Point(12, 25);
            this.noButtonsXTextBox.Name = "noButtonsXTextBox";
            this.noButtonsXTextBox.Size = new System.Drawing.Size(69, 20);
            this.noButtonsXTextBox.TabIndex = 10;
            this.noButtonsXTextBox.Text = "15";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "# nodes X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "# nodes Y";
            // 
            // djikstraButton
            // 
            this.djikstraButton.Location = new System.Drawing.Point(12, 319);
            this.djikstraButton.Name = "djikstraButton";
            this.djikstraButton.Size = new System.Drawing.Size(80, 23);
            this.djikstraButton.TabIndex = 13;
            this.djikstraButton.Text = "Djikstra";
            this.djikstraButton.UseVisualStyleBackColor = true;
            this.djikstraButton.Click += new System.EventHandler(this.djikstraButton_Click);
            // 
            // waitTimeTextBox
            // 
            this.waitTimeTextBox.Location = new System.Drawing.Point(12, 290);
            this.waitTimeTextBox.Name = "waitTimeTextBox";
            this.waitTimeTextBox.Size = new System.Drawing.Size(69, 20);
            this.waitTimeTextBox.TabIndex = 14;
            this.waitTimeTextBox.Text = "50";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Time per node, ms";
            // 
            // ShortestPathUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 901);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.waitTimeTextBox);
            this.Controls.Add(this.djikstraButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.noButtonsXTextBox);
            this.Controls.Add(this.noButtonsYTextBox);
            this.Controls.Add(this.createMapButton);
            this.Controls.Add(this.resetMapButton);
            this.Controls.Add(this.drawModeCheckBox);
            this.Controls.Add(this.openNodeButton);
            this.Controls.Add(this.blockNodeButton);
            this.Controls.Add(this.endNodeButton);
            this.Controls.Add(this.startNodeButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ShortestPathUI";
            this.Text = "Shortest Path";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton startNodeButton;
        private System.Windows.Forms.RadioButton endNodeButton;
        private System.Windows.Forms.RadioButton blockNodeButton;
        private System.Windows.Forms.RadioButton openNodeButton;
        private System.Windows.Forms.CheckBox drawModeCheckBox;
        private System.Windows.Forms.Button resetMapButton;
        private System.Windows.Forms.Button createMapButton;
        private System.Windows.Forms.TextBox noButtonsYTextBox;
        private System.Windows.Forms.TextBox noButtonsXTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button djikstraButton;
        private System.Windows.Forms.TextBox waitTimeTextBox;
        private System.Windows.Forms.Label label3;
    }
}

