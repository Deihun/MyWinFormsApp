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
            button2 = new Button();
            button1 = new Button();
            reset_btn = new Button();
            history_btn = new Button();
            History = new ToolTip(components);
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            label5 = new Label();
            groupBox4 = new GroupBox();
            label6 = new Label();
            label7 = new Label();
            groupBox5 = new GroupBox();
            label8 = new Label();
            label9 = new Label();
            groupBox6 = new GroupBox();
            label10 = new Label();
            label11 = new Label();
            flowLayoutPanel1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(groupBox2);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(1443, 649);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.VisibleChanged += flowLayoutPanel1_VisibleChanged;
            // 
            // button2
            // 
            button2.Location = new Point(520, 16);
            button2.Name = "button2";
            button2.Size = new Size(147, 31);
            button2.TabIndex = 6;
            button2.Text = "RESTORE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(520, 16);
            button1.Name = "button1";
            button1.Size = new Size(147, 31);
            button1.TabIndex = 4;
            button1.Text = "SAVE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // reset_btn
            // 
            reset_btn.Location = new Point(524, 15);
            reset_btn.Name = "reset_btn";
            reset_btn.Size = new Size(147, 31);
            reset_btn.TabIndex = 3;
            reset_btn.Text = "RESET";
            reset_btn.UseVisualStyleBackColor = true;
            reset_btn.Click += reset_btn_Click;
            // 
            // history_btn
            // 
            history_btn.Location = new Point(520, 21);
            history_btn.Name = "history_btn";
            history_btn.Size = new Size(147, 31);
            history_btn.TabIndex = 1;
            history_btn.Text = "HISTORY";
            history_btn.UseVisualStyleBackColor = true;
            history_btn.Click += history_btn_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(groupBox6);
            groupBox2.Controls.Add(groupBox5);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            groupBox2.Location = new Point(23, 23);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(727, 336);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "DATEBASE";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(history_btn);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.Location = new Point(33, 33);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(677, 68);
            groupBox3.TabIndex = 0;
            groupBox3.TabStop = false;
            groupBox3.Text = "CHECK HISTORY";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 8F);
            label5.Location = new Point(31, 27);
            label5.Name = "label5";
            label5.Size = new Size(379, 13);
            label5.TabIndex = 2;
            label5.Text = "Here you can see and track all the changes happening within the system";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label7);
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(button1);
            groupBox4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox4.Location = new Point(33, 107);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(677, 68);
            groupBox4.TabIndex = 1;
            groupBox4.TabStop = false;
            groupBox4.Text = "SAVE BACKUP";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 8F);
            label6.Location = new Point(45, 26);
            label6.Name = "label6";
            label6.Size = new Size(0, 13);
            label6.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 8F);
            label7.Location = new Point(30, 24);
            label7.Name = "label7";
            label7.Size = new Size(475, 13);
            label7.TabIndex = 5;
            label7.Text = "Create a Backup (.BAK) of your current use database at the file path in your C://sqlBackup/...\r\n";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button2);
            groupBox5.Controls.Add(label8);
            groupBox5.Controls.Add(label9);
            groupBox5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox5.Location = new Point(33, 181);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(677, 68);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "RESTORE BACKUP";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 8F);
            label8.Location = new Point(30, 24);
            label8.Name = "label8";
            label8.Size = new Size(416, 39);
            label8.TabIndex = 5;
            label8.Text = "Restore a data from a Backup database (.BAK) depends on your chosen backup. \r\nWarning: This action will result of current dataloss.\r\n\r\n";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 8F);
            label9.Location = new Point(45, 26);
            label9.Name = "label9";
            label9.Size = new Size(0, 13);
            label9.TabIndex = 2;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label10);
            groupBox6.Controls.Add(reset_btn);
            groupBox6.Controls.Add(label11);
            groupBox6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox6.Location = new Point(33, 256);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(677, 68);
            groupBox6.TabIndex = 3;
            groupBox6.TabStop = false;
            groupBox6.Text = "RESET DATABASE";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 8F);
            label10.Location = new Point(30, 24);
            label10.Name = "label10";
            label10.Size = new Size(458, 26);
            label10.TabIndex = 5;
            label10.Text = "Fully remove the data within the database. WARNING: This action will result a complete \r\nloss of data.\r\n";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 8F);
            label11.Location = new Point(45, 26);
            label11.Name = "label11";
            label11.Size = new Size(0, 13);
            label11.TabIndex = 2;
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
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button history_btn;
        private ToolTip History;
        private Button reset_btn;
        private Button button1;
        private Button button2;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label5;
        private GroupBox groupBox5;
        private Label label8;
        private Label label9;
        private GroupBox groupBox4;
        private Label label7;
        private Label label6;
        private GroupBox groupBox6;
        private Label label10;
        private Label label11;
    }
}