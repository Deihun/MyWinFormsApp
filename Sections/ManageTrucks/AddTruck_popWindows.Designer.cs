namespace MyWinFormsApp.Sections.ManageTrucks
{
    partial class AddTruck_popWindows
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
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            platenumber_tb = new TextBox();
            trucktype_cb = new ComboBox();
            groupBox2 = new GroupBox();
            height_tb = new TextBox();
            width_tb = new TextBox();
            length_tb = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            referencesize_cb = new ComboBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            cancel_btn = new Button();
            add_btn = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 38);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "Plate Number:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(292, 38);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 1;
            label2.Text = "Truck Type:";
            label2.Click += label2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(platenumber_tb);
            groupBox1.Controls.Add(trucktype_cb);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 9);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(553, 88);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Information";
            // 
            // platenumber_tb
            // 
            platenumber_tb.Location = new Point(104, 35);
            platenumber_tb.Name = "platenumber_tb";
            platenumber_tb.Size = new Size(181, 23);
            platenumber_tb.TabIndex = 9;
            platenumber_tb.TextChanged += platenumber_tb_TextChanged;
            // 
            // trucktype_cb
            // 
            trucktype_cb.FormattingEnabled = true;
            trucktype_cb.Location = new Point(363, 35);
            trucktype_cb.Name = "trucktype_cb";
            trucktype_cb.Size = new Size(181, 23);
            trucktype_cb.TabIndex = 2;
            trucktype_cb.SelectedIndexChanged += trucktype_cb_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(height_tb);
            groupBox2.Controls.Add(width_tb);
            groupBox2.Controls.Add(length_tb);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(referencesize_cb);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Location = new Point(12, 112);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(553, 189);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Interior Dimension of Truck";
            // 
            // height_tb
            // 
            height_tb.Location = new Point(132, 113);
            height_tb.Name = "height_tb";
            height_tb.Size = new Size(165, 23);
            height_tb.TabIndex = 8;
            height_tb.TextChanged += height_tb_TextChanged;
            // 
            // width_tb
            // 
            width_tb.Location = new Point(132, 82);
            width_tb.Name = "width_tb";
            width_tb.Size = new Size(165, 23);
            width_tb.TabIndex = 7;
            width_tb.TextChanged += width_tb_TextChanged;
            // 
            // length_tb
            // 
            length_tb.Location = new Point(132, 53);
            length_tb.Name = "length_tb";
            length_tb.Size = new Size(165, 23);
            length_tb.TabIndex = 6;
            length_tb.TextChanged += length_tb_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(47, 116);
            label6.Name = "label6";
            label6.Size = new Size(79, 15);
            label6.TabIndex = 5;
            label6.Text = "Height (mm):";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 85);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 4;
            label5.Text = "Width (mm): ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 56);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 3;
            label4.Text = "Length (mm): ";
            // 
            // referencesize_cb
            // 
            referencesize_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            referencesize_cb.FormattingEnabled = true;
            referencesize_cb.Location = new Point(101, 22);
            referencesize_cb.Name = "referencesize_cb";
            referencesize_cb.Size = new Size(196, 23);
            referencesize_cb.TabIndex = 2;
            referencesize_cb.SelectedIndexChanged += referencesize_cb_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 23);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 1;
            label3.Text = "Reference Size: ";
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = Properties.Resources.TruckHintPicture;
            pictureBox1.Image = Properties.Resources.TruckHintPicture;
            pictureBox1.Location = new Point(303, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(238, 142);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // cancel_btn
            // 
            cancel_btn.Location = new Point(12, 307);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(126, 45);
            cancel_btn.TabIndex = 6;
            cancel_btn.Text = "CANCEL";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // add_btn
            // 
            add_btn.Location = new Point(144, 307);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(126, 46);
            add_btn.TabIndex = 7;
            add_btn.Text = "ADD";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += button1_Click;
            // 
            // AddTruck_popWindows
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 359);
            Controls.Add(add_btn);
            Controls.Add(cancel_btn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddTruck_popWindows";
            Text = "Adding a Truck";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ComboBox referencesize_cb;
        private Label label3;
        private PictureBox pictureBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button cancel_btn;
        private Button add_btn;
        private TextBox length_tb;
        private ComboBox trucktype_cb;
        private TextBox height_tb;
        private TextBox width_tb;
        private TextBox platenumber_tb;
    }
}