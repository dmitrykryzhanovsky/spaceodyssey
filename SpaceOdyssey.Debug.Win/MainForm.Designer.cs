namespace SpaceOdyssey.Debug.Win
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.центрПритяженияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gravitationalCenter_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.центрПритяженияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // центрПритяженияToolStripMenuItem
            // 
            this.центрПритяженияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gravitationalCenter_ToolStripMenuItem});
            this.центрПритяженияToolStripMenuItem.Name = "центрПритяженияToolStripMenuItem";
            this.центрПритяженияToolStripMenuItem.Size = new System.Drawing.Size(114, 24);
            this.центрПритяженияToolStripMenuItem.Text = "Расчёт орбит";
            // 
            // gravitationalCenter_ToolStripMenuItem
            // 
            this.gravitationalCenter_ToolStripMenuItem.Name = "gravitationalCenter_ToolStripMenuItem";
            this.gravitationalCenter_ToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.gravitationalCenter_ToolStripMenuItem.Text = "Центр притяжения";
            this.gravitationalCenter_ToolStripMenuItem.Click += new System.EventHandler(this.GravitationalCenter_ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "SpaceOdyssey Debug";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem центрПритяженияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gravitationalCenter_ToolStripMenuItem;
    }
}

