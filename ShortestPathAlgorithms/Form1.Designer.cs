namespace ShortestPathAlgorithms
{
    partial class Form1
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
            this.SuspendLayout();
            // 
            // startNodeButton
            // 
            this.startNodeButton.AutoSize = true;
            this.startNodeButton.Location = new System.Drawing.Point(12, 12);
            this.startNodeButton.Name = "startNodeButton";
            this.startNodeButton.Size = new System.Drawing.Size(47, 17);
            this.startNodeButton.TabIndex = 0;
            this.startNodeButton.TabStop = true;
            this.startNodeButton.Text = "Start";
            this.startNodeButton.UseVisualStyleBackColor = true;
            this.startNodeButton.CheckedChanged += new System.EventHandler(this.startNodeButton_CheckedChanged);
            // 
            // endNodeButton
            // 
            this.endNodeButton.AutoSize = true;
            this.endNodeButton.Location = new System.Drawing.Point(12, 36);
            this.endNodeButton.Name = "endNodeButton";
            this.endNodeButton.Size = new System.Drawing.Size(44, 17);
            this.endNodeButton.TabIndex = 1;
            this.endNodeButton.TabStop = true;
            this.endNodeButton.Text = "End";
            this.endNodeButton.UseVisualStyleBackColor = true;
            this.endNodeButton.CheckedChanged += new System.EventHandler(this.endNodeButton_CheckedChanged);
            // 
            // blockNodeButton
            // 
            this.blockNodeButton.AutoSize = true;
            this.blockNodeButton.Location = new System.Drawing.Point(12, 59);
            this.blockNodeButton.Name = "blockNodeButton";
            this.blockNodeButton.Size = new System.Drawing.Size(52, 17);
            this.blockNodeButton.TabIndex = 2;
            this.blockNodeButton.TabStop = true;
            this.blockNodeButton.Text = "Block";
            this.blockNodeButton.UseVisualStyleBackColor = true;
            this.blockNodeButton.CheckedChanged += new System.EventHandler(this.blockNodeButton_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 854);
            this.Controls.Add(this.blockNodeButton);
            this.Controls.Add(this.endNodeButton);
            this.Controls.Add(this.startNodeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton startNodeButton;
        private System.Windows.Forms.RadioButton endNodeButton;
        private System.Windows.Forms.RadioButton blockNodeButton;
    }
}

