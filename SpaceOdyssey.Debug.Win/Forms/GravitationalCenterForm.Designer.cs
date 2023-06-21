namespace SpaceOdyssey.Debug.Win.Forms
{
    partial class GravitationalCenterForm
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
            this.celestialObject_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radius_TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gravitationalParameter_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // celestialObject_ComboBox
            // 
            this.celestialObject_ComboBox.FormattingEnabled = true;
            this.celestialObject_ComboBox.Items.AddRange(new object[] {
            "Солнце",
            "Земля",
            "Луна",
            "Венера",
            "Юпитер",
            "Сатурн"});
            this.celestialObject_ComboBox.Location = new System.Drawing.Point(139, 6);
            this.celestialObject_ComboBox.Name = "celestialObject_ComboBox";
            this.celestialObject_ComboBox.Size = new System.Drawing.Size(177, 24);
            this.celestialObject_ComboBox.TabIndex = 0;
            this.celestialObject_ComboBox.SelectedIndexChanged += new System.EventHandler(this.CelestialObject_ComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Небесное тело";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.radius_TextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.gravitationalParameter_TextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 172);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Вторая космическая скорость V2 на R, км/с";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Первая космическая скорость V1 на R, км/с";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(301, 135);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(159, 22);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(301, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(159, 22);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radius_TextBox
            // 
            this.radius_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.radius_TextBox.Location = new System.Drawing.Point(301, 59);
            this.radius_TextBox.Name = "radius_TextBox";
            this.radius_TextBox.ReadOnly = true;
            this.radius_TextBox.Size = new System.Drawing.Size(159, 22);
            this.radius_TextBox.TabIndex = 6;
            this.radius_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Радиус R, км";
            // 
            // gravitationalParameter_TextBox
            // 
            this.gravitationalParameter_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.gravitationalParameter_TextBox.Location = new System.Drawing.Point(301, 21);
            this.gravitationalParameter_TextBox.Name = "gravitationalParameter_TextBox";
            this.gravitationalParameter_TextBox.ReadOnly = true;
            this.gravitationalParameter_TextBox.Size = new System.Drawing.Size(159, 22);
            this.gravitationalParameter_TextBox.TabIndex = 4;
            this.gravitationalParameter_TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Гравитационный параметр K, СИ";
            // 
            // GravitationalCenterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.celestialObject_ComboBox);
            this.Name = "GravitationalCenterForm";
            this.Text = "Центр притяжения";
            this.Load += new System.EventHandler(this.GravitationalCenterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox celestialObject_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox gravitationalParameter_TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox radius_TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}