namespace MyWinFormsApp.Sections.ManageItems.Flute
{
    partial class AddOrEditFlute_windowpopupform
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
            groupBox1 = new GroupBox();
            codename_tb = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            textBox1 = new TextBox();
            label5 = new Label();
            targetrange_from_tb = new TextBox();
            label4 = new Label();
            targetrange_to_tb = new TextBox();
            label3 = new Label();
            standardsize_tb = new TextBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            add_btn = new Button();
            cancel_btn = new Button();
            name_warning = new Label();
            standard_warning = new Label();
            target_warning = new Label();
            tolerance_warning = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(codename_tb);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(name_warning);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(243, 83);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Information";
            // 
            // codename_tb
            // 
            codename_tb.Font = new Font("Segoe UI", 12F);
            codename_tb.Location = new Point(134, 32);
            codename_tb.MaxLength = 2;
            codename_tb.Name = "codename_tb";
            codename_tb.Size = new Size(103, 29);
            codename_tb.TabIndex = 1;
            codename_tb.TextChanged += codename_tb_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(29, 35);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 0;
            label1.Text = "Flute Type:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(targetrange_from_tb);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(targetrange_to_tb);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(standardsize_tb);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(target_warning);
            groupBox2.Controls.Add(standard_warning);
            groupBox2.Controls.Add(tolerance_warning);
            groupBox2.Location = new Point(12, 97);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(243, 174);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Value";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(134, 115);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(103, 23);
            textBox1.TabIndex = 8;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 118);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 7;
            label5.Text = "Tolerance (mm) : ";
            // 
            // targetrange_from_tb
            // 
            targetrange_from_tb.Location = new Point(134, 73);
            targetrange_from_tb.Name = "targetrange_from_tb";
            targetrange_from_tb.Size = new Size(42, 23);
            targetrange_from_tb.TabIndex = 4;
            targetrange_from_tb.TextChanged += targetrange_from_tb_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(173, 76);
            label4.Name = "label4";
            label4.Size = new Size(17, 15);
            label4.TabIndex = 6;
            label4.Text = "→";
            // 
            // targetrange_to_tb
            // 
            targetrange_to_tb.Location = new Point(191, 73);
            targetrange_to_tb.Name = "targetrange_to_tb";
            targetrange_to_tb.Size = new Size(46, 23);
            targetrange_to_tb.TabIndex = 5;
            targetrange_to_tb.TextChanged += targetrange_to_tb_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 76);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 3;
            label3.Text = "Target Range(mm) : ";
            // 
            // standardsize_tb
            // 
            standardsize_tb.Location = new Point(134, 31);
            standardsize_tb.Name = "standardsize_tb";
            standardsize_tb.Size = new Size(103, 23);
            standardsize_tb.TabIndex = 2;
            standardsize_tb.TextChanged += standardsize_tb_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 36);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 1;
            label2.Text = "Standard Size(mm) : ";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.FluteHintPicture;
            pictureBox1.Location = new Point(261, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(187, 249);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // add_btn
            // 
            add_btn.Location = new Point(12, 277);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(75, 40);
            add_btn.TabIndex = 3;
            add_btn.Text = "ADD";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // cancel_btn
            // 
            cancel_btn.Location = new Point(93, 277);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(75, 40);
            cancel_btn.TabIndex = 4;
            cancel_btn.Text = "CANCEL";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // name_warning
            // 
            name_warning.AutoSize = true;
            name_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            name_warning.ForeColor = Color.Red;
            name_warning.Location = new Point(20, 37);
            name_warning.Name = "name_warning";
            name_warning.Size = new Size(14, 19);
            name_warning.TabIndex = 17;
            name_warning.Text = "!";
            // 
            // standard_warning
            // 
            standard_warning.AutoSize = true;
            standard_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            standard_warning.ForeColor = Color.Red;
            standard_warning.Location = new Point(4, 33);
            standard_warning.Name = "standard_warning";
            standard_warning.Size = new Size(14, 19);
            standard_warning.TabIndex = 17;
            standard_warning.Text = "!";
            // 
            // target_warning
            // 
            target_warning.AutoSize = true;
            target_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            target_warning.ForeColor = Color.Red;
            target_warning.Location = new Point(3, 74);
            target_warning.Name = "target_warning";
            target_warning.Size = new Size(14, 19);
            target_warning.TabIndex = 18;
            target_warning.Text = "!";
            // 
            // tolerance_warning
            // 
            tolerance_warning.AutoSize = true;
            tolerance_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tolerance_warning.ForeColor = Color.Red;
            tolerance_warning.Location = new Point(20, 115);
            tolerance_warning.Name = "tolerance_warning";
            tolerance_warning.Size = new Size(14, 19);
            tolerance_warning.TabIndex = 19;
            tolerance_warning.Text = "!";
            // 
            // AddOrEditFlute_windowpopupform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 322);
            Controls.Add(cancel_btn);
            Controls.Add(add_btn);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddOrEditFlute_windowpopupform";
            Text = "ADD NEW FLUTE";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox codename_tb;
        private Label label1;
        private GroupBox groupBox2;
        private TextBox standardsize_tb;
        private Label label2;
        private PictureBox pictureBox1;
        private Button add_btn;
        private Button cancel_btn;
        private TextBox targetrange_to_tb;
        private TextBox targetrange_from_tb;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private Label name_warning;
        private Label target_warning;
        private Label standard_warning;
        private Label tolerance_warning;
    }
}