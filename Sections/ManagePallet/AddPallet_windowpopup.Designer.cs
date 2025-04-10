namespace MyWinFormsApp.Sections.ManagePallet
{
    partial class AddPallet_windowpopup
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
            name_tb = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label5 = new Label();
            referencepalletsize_cb = new ComboBox();
            height_tb = new TextBox();
            label4 = new Label();
            width_tb = new TextBox();
            label3 = new Label();
            length_tb = new TextBox();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            add_btn = new Button();
            cancel_btn = new Button();
            name_warning = new Label();
            length_warning = new Label();
            width_warning = new Label();
            height_warning = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(name_warning);
            groupBox1.Controls.Add(name_tb);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(413, 71);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Information";
            // 
            // name_tb
            // 
            name_tb.Location = new Point(73, 26);
            name_tb.Name = "name_tb";
            name_tb.Size = new Size(265, 23);
            name_tb.TabIndex = 4;
            name_tb.TextChanged += name_tb_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 29);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Name:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(height_warning);
            groupBox2.Controls.Add(width_warning);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(referencepalletsize_cb);
            groupBox2.Controls.Add(height_tb);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(width_tb);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(length_tb);
            groupBox2.Controls.Add(pictureBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(length_warning);
            groupBox2.Location = new Point(4, 77);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(409, 162);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dimensions";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 20);
            label5.Name = "label5";
            label5.Size = new Size(114, 15);
            label5.TabIndex = 9;
            label5.Text = "Reference Pallet Size";
            // 
            // referencepalletsize_cb
            // 
            referencepalletsize_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            referencepalletsize_cb.FormattingEnabled = true;
            referencepalletsize_cb.Location = new Point(145, 12);
            referencepalletsize_cb.Name = "referencepalletsize_cb";
            referencepalletsize_cb.Size = new Size(208, 23);
            referencepalletsize_cb.TabIndex = 8;
            referencepalletsize_cb.SelectedIndexChanged += referencepalletsize_cb_SelectedIndexChanged;
            // 
            // height_tb
            // 
            height_tb.Location = new Point(92, 106);
            height_tb.Name = "height_tb";
            height_tb.Size = new Size(118, 23);
            height_tb.TabIndex = 7;
            height_tb.TextChanged += height_tb_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 109);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 6;
            label4.Text = "Height(mm):";
            // 
            // width_tb
            // 
            width_tb.Location = new Point(92, 77);
            width_tb.Name = "width_tb";
            width_tb.Size = new Size(118, 23);
            width_tb.TabIndex = 5;
            width_tb.TextChanged += width_tb_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 80);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Width(mm):";
            // 
            // length_tb
            // 
            length_tb.Location = new Point(92, 48);
            length_tb.Name = "length_tb";
            length_tb.Size = new Size(118, 23);
            length_tb.TabIndex = 3;
            length_tb.TextChanged += length_tb_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = TruckEstimation.Properties.Resources.PalletHintPicture1;
            pictureBox1.Location = new Point(214, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(199, 105);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 51);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 1;
            label2.Text = "Length(mm): ";
            // 
            // add_btn
            // 
            add_btn.Location = new Point(6, 245);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(99, 40);
            add_btn.TabIndex = 2;
            add_btn.Text = "ADD";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // cancel_btn
            // 
            cancel_btn.Location = new Point(111, 245);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(99, 40);
            cancel_btn.TabIndex = 3;
            cancel_btn.Text = "CANCEL";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // name_warning
            // 
            name_warning.AutoSize = true;
            name_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            name_warning.ForeColor = Color.Red;
            name_warning.Location = new Point(12, 27);
            name_warning.Name = "name_warning";
            name_warning.Size = new Size(14, 19);
            name_warning.TabIndex = 21;
            name_warning.Text = "!";
            // 
            // length_warning
            // 
            length_warning.AutoSize = true;
            length_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            length_warning.ForeColor = Color.Red;
            length_warning.Location = new Point(7, 48);
            length_warning.Name = "length_warning";
            length_warning.Size = new Size(14, 19);
            length_warning.TabIndex = 22;
            length_warning.Text = "!";
            // 
            // width_warning
            // 
            width_warning.AutoSize = true;
            width_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            width_warning.ForeColor = Color.Red;
            width_warning.Location = new Point(7, 77);
            width_warning.Name = "width_warning";
            width_warning.Size = new Size(14, 19);
            width_warning.TabIndex = 22;
            width_warning.Text = "!";
            // 
            // height_warning
            // 
            height_warning.AutoSize = true;
            height_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            height_warning.ForeColor = Color.Red;
            height_warning.Location = new Point(7, 105);
            height_warning.Name = "height_warning";
            height_warning.Size = new Size(14, 19);
            height_warning.TabIndex = 23;
            height_warning.Text = "!";
            // 
            // AddPallet_windowpopup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 285);
            Controls.Add(cancel_btn);
            Controls.Add(add_btn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddPallet_windowpopup";
            Text = "Add new Pallet";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private GroupBox groupBox2;
        private Label label2;
        private PictureBox pictureBox1;
        private TextBox length_tb;
        private ComboBox referencepalletsize_cb;
        private TextBox height_tb;
        private Label label4;
        private TextBox width_tb;
        private Label label3;
        private TextBox name_tb;
        private Label label5;
        private Button add_btn;
        private Button cancel_btn;
        private Label name_warning;
        private Label height_warning;
        private Label width_warning;
        private Label length_warning;
    }
}