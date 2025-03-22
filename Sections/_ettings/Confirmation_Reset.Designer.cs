namespace MyWinFormsApp.Sections._ettings
{
    partial class Confirmation_Reset
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            label1 = new Label();
            panel1 = new Panel();
            button2 = new Button();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 139);
            button1.Name = "button1";
            button1.Size = new Size(99, 36);
            button1.TabIndex = 0;
            button1.Text = "CANCEL";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(294, 45);
            label1.TabIndex = 1;
            label1.Text = "WARNING! This Reset is a process which cannot be \r\nundone and result of lost of all data within the System \r\nitself. Are you sure do you want to proceed?\r\n";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(302, 54);
            panel1.TabIndex = 2;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(192, 0, 0);
            button2.Enabled = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.FromArgb(255, 192, 192);
            button2.Location = new Point(207, 139);
            button2.Name = "button2";
            button2.Size = new Size(99, 36);
            button2.TabIndex = 3;
            button2.Text = "YES";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 69);
            label2.Name = "label2";
            label2.Size = new Size(128, 15);
            label2.TabIndex = 4;
            label2.Text = "<COOLDOWN TIMER>";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // Confirmation_Reset
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 182);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(panel1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Confirmation_Reset";
            Text = "Warning";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Panel panel1;
        private Button button2;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}