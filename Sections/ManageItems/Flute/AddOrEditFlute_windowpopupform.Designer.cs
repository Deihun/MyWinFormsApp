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
            standardsize_tb = new TextBox();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            add_btn = new Button();
            cancel_btn = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(codename_tb);
            groupBox1.Controls.Add(label1);
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
            codename_tb.Location = new Point(142, 32);
            codename_tb.MaxLength = 2;
            codename_tb.Name = "codename_tb";
            codename_tb.Size = new Size(64, 29);
            codename_tb.TabIndex = 1;
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
            groupBox2.Controls.Add(standardsize_tb);
            groupBox2.Controls.Add(label2);
            groupBox2.Location = new Point(12, 97);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(243, 174);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Value";
            // 
            // standardsize_tb
            // 
            standardsize_tb.Location = new Point(142, 31);
            standardsize_tb.Name = "standardsize_tb";
            standardsize_tb.Size = new Size(64, 23);
            standardsize_tb.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 34);
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
    }
}