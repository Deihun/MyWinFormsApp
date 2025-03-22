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
            itemdescription_rtb = new RichTextBox();
            category_cb = new ComboBox();
            category_checkbox = new CheckBox();
            client_cb = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            unfolded_rb = new RadioButton();
            fold_rb = new RadioButton();
            flutetype_cb = new ComboBox();
            width_tb = new TextBox();
            length_tb = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            add_btn = new Button();
            cancel_btn = new Button();
            label6 = new Label();
            fccontrol_tb = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(fccontrol_tb);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(itemdescription_rtb);
            groupBox1.Controls.Add(category_cb);
            groupBox1.Controls.Add(category_checkbox);
            groupBox1.Controls.Add(client_cb);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(573, 130);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Information";
            // 
            // itemdescription_rtb
            // 
            itemdescription_rtb.Location = new Point(120, 22);
            itemdescription_rtb.Name = "itemdescription_rtb";
            itemdescription_rtb.Size = new Size(222, 57);
            itemdescription_rtb.TabIndex = 13;
            itemdescription_rtb.Text = "";
            // 
            // category_cb
            // 
            category_cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            category_cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            category_cb.Enabled = false;
            category_cb.FlatStyle = FlatStyle.Flat;
            category_cb.FormattingEnabled = true;
            category_cb.Location = new Point(120, 85);
            category_cb.Name = "category_cb";
            category_cb.Size = new Size(222, 23);
            category_cb.TabIndex = 12;
            // 
            // category_checkbox
            // 
            category_checkbox.AutoSize = true;
            category_checkbox.Location = new Point(40, 89);
            category_checkbox.Name = "category_checkbox";
            category_checkbox.Size = new Size(74, 19);
            category_checkbox.TabIndex = 11;
            category_checkbox.Text = "Category";
            category_checkbox.UseVisualStyleBackColor = true;
            category_checkbox.CheckedChanged += category_checkbox_CheckedChanged;
            // 
            // client_cb
            // 
            client_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            client_cb.FormattingEnabled = true;
            client_cb.Location = new Point(402, 19);
            client_cb.Name = "client_cb";
            client_cb.Size = new Size(165, 23);
            client_cb.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(355, 22);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 1;
            label2.Text = "Client:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 25);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Item Description:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(unfolded_rb);
            groupBox2.Controls.Add(fold_rb);
            groupBox2.Controls.Add(flutetype_cb);
            groupBox2.Controls.Add(width_tb);
            groupBox2.Controls.Add(length_tb);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Location = new Point(12, 139);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(316, 146);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dimensions";
            // 
            // unfolded_rb
            // 
            unfolded_rb.AutoSize = true;
            unfolded_rb.Checked = true;
            unfolded_rb.Location = new Point(210, 53);
            unfolded_rb.Name = "unfolded_rb";
            unfolded_rb.Size = new Size(74, 19);
            unfolded_rb.TabIndex = 8;
            unfolded_rb.TabStop = true;
            unfolded_rb.Text = "Unfolded";
            unfolded_rb.UseVisualStyleBackColor = true;
            // 
            // fold_rb
            // 
            fold_rb.AutoSize = true;
            fold_rb.Location = new Point(120, 55);
            fold_rb.Name = "fold_rb";
            fold_rb.Size = new Size(61, 19);
            fold_rb.TabIndex = 7;
            fold_rb.TabStop = true;
            fold_rb.Text = "Folded";
            fold_rb.UseVisualStyleBackColor = true;
            // 
            // flutetype_cb
            // 
            flutetype_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            flutetype_cb.FormattingEnabled = true;
            flutetype_cb.Location = new Point(120, 26);
            flutetype_cb.Name = "flutetype_cb";
            flutetype_cb.Size = new Size(164, 23);
            flutetype_cb.TabIndex = 6;
            // 
            // width_tb
            // 
            width_tb.Location = new Point(120, 109);
            width_tb.Name = "width_tb";
            width_tb.Size = new Size(164, 23);
            width_tb.TabIndex = 5;
            width_tb.TextChanged += width_tb_TextChanged;
            // 
            // length_tb
            // 
            length_tb.Location = new Point(120, 78);
            length_tb.Name = "length_tb";
            length_tb.Size = new Size(164, 23);
            length_tb.TabIndex = 4;
            length_tb.TextChanged += length_tb_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 117);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 3;
            label5.Text = "Width:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 86);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 2;
            label4.Text = "Length: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 33);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 1;
            label3.Text = "Flute Type:";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ItemHintPicture;
            pictureBox1.Location = new Point(367, 142);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 176);
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(355, 56);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 14;
            label6.Text = "F.C. Control:";
            // 
            // fccontrol_tb
            // 
            fccontrol_tb.Location = new Point(424, 53);
            fccontrol_tb.Name = "fccontrol_tb";
            fccontrol_tb.Size = new Size(143, 23);
            fccontrol_tb.TabIndex = 15;
            // 
            // AddNewItems_WindowPopUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 330);
            Controls.Add(cancel_btn);
            Controls.Add(add_btn);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
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
        private ComboBox category_cb;
        private CheckBox category_checkbox;
        private RadioButton unfolded_rb;
        private RadioButton fold_rb;
        private RichTextBox itemdescription_rtb;
        private TextBox fccontrol_tb;
        private Label label6;
    }
}