namespace MyWinFormsApp.Sections._ettings
{
    partial class settings_form
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1 = new GroupBox();
            button2 = new Button();
            label3 = new Label();
            button1 = new Button();
            reset_btn = new Button();
            label4 = new Label();
            label2 = new Label();
            history_btn = new Button();
            label1 = new Label();
            History = new ToolTip(components);
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(1443, 649);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(reset_btn);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(history_btn);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(23, 23);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(442, 216);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Data";
            // 
            // button2
            // 
            button2.Location = new Point(205, 120);
            button2.Name = "button2";
            button2.Size = new Size(147, 31);
            button2.TabIndex = 6;
            button2.Text = "RESTORE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 128);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 5;
            label3.Text = "Restore Back-up";
            // 
            // button1
            // 
            button1.Location = new Point(205, 78);
            button1.Name = "button1";
            button1.Size = new Size(147, 31);
            button1.TabIndex = 4;
            button1.Text = "SAVE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // reset_btn
            // 
            reset_btn.Location = new Point(205, 164);
            reset_btn.Name = "reset_btn";
            reset_btn.Size = new Size(147, 31);
            reset_btn.TabIndex = 3;
            reset_btn.Text = "RESET";
            reset_btn.UseVisualStyleBackColor = true;
            reset_btn.Click += reset_btn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 86);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 0;
            label4.Text = "Save Backup";
            label4.MouseHover += label4_MouseHover;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 172);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 2;
            label2.Text = "Reset Database";
            label2.MouseHover += label2_MouseHover;
            // 
            // history_btn
            // 
            history_btn.Location = new Point(205, 33);
            history_btn.Name = "history_btn";
            history_btn.Size = new Size(147, 31);
            history_btn.TabIndex = 1;
            history_btn.Text = "HISTORY";
            history_btn.UseVisualStyleBackColor = true;
            history_btn.Click += history_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 41);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "Check History";
            label1.MouseEnter += label1_MouseEnter;
            // 
            // settings_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1443, 649);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "settings_form";
            Text = "settings_form";
            flowLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private Button history_btn;
        private Label label1;
        private ToolTip History;
        private Button reset_btn;
        private Label label2;
        private Label label4;
        private Button button1;
        private Button button2;
        private Label label3;
    }
}