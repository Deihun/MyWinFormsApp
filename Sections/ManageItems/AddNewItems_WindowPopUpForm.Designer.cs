namespace MyWinFormsApp.Sections.ManageItems
{
    partial class AddNewItems_WindowPopUpForm
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
            client_cb = new ComboBox();
            itemname_tb = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            flutetype_cb = new ComboBox();
            width_tb = new TextBox();
            length_tb = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
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
            groupBox1.Controls.Add(client_cb);
            groupBox1.Controls.Add(itemname_tb);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(305, 121);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Information";
            // 
            // client_cb
            // 
            client_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            client_cb.FormattingEnabled = true;
            client_cb.Location = new Point(118, 63);
            client_cb.Name = "client_cb";
            client_cb.Size = new Size(164, 23);
            client_cb.TabIndex = 3;
            // 
            // itemname_tb
            // 
            itemname_tb.Location = new Point(118, 34);
            itemname_tb.Name = "itemname_tb";
            itemname_tb.Size = new Size(164, 23);
            itemname_tb.TabIndex = 2;
            itemname_tb.TextChanged += itemname_tb_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 71);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Client:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 37);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 0;
            label1.Text = "Item Name:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(flutetype_cb);
            groupBox2.Controls.Add(width_tb);
            groupBox2.Controls.Add(length_tb);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 139);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(305, 146);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dimensions";
            // 
            // flutetype_cb
            // 
            flutetype_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            flutetype_cb.FormattingEnabled = true;
            flutetype_cb.Location = new Point(118, 30);
            flutetype_cb.Name = "flutetype_cb";
            flutetype_cb.Size = new Size(164, 23);
            flutetype_cb.TabIndex = 6;
            // 
            // width_tb
            // 
            width_tb.Location = new Point(118, 93);
            width_tb.Name = "width_tb";
            width_tb.Size = new Size(164, 23);
            width_tb.TabIndex = 5;
            width_tb.TextChanged += width_tb_TextChanged;
            // 
            // length_tb
            // 
            length_tb.Location = new Point(118, 62);
            length_tb.Name = "length_tb";
            length_tb.Size = new Size(164, 23);
            length_tb.TabIndex = 4;
            length_tb.TextChanged += length_tb_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 96);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 3;
            label5.Text = "Width:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 65);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 2;
            label4.Text = "Length: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 33);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 1;
            label3.Text = "Flute Type:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ItemHintPicture;
            pictureBox1.Location = new Point(322, 83);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 202);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // add_btn
            // 
            add_btn.Location = new Point(12, 291);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(91, 33);
            add_btn.TabIndex = 3;
            add_btn.Text = "ADD ITEM";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // cancel_btn
            // 
            cancel_btn.Location = new Point(109, 291);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(91, 33);
            cancel_btn.TabIndex = 4;
            cancel_btn.Text = "CANCEL";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // AddNewItems_WindowPopUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(503, 330);
            Controls.Add(cancel_btn);
            Controls.Add(add_btn);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddNewItems_WindowPopUpForm";
            Text = "Add New Item";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox client_cb;
        private TextBox itemname_tb;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private ComboBox flutetype_cb;
        private TextBox width_tb;
        private TextBox length_tb;
        private Label label5;
        private Label label4;
        private Label label3;
        private PictureBox pictureBox1;
        private Button add_btn;
        private Button cancel_btn;
    }
}