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
            label7 = new Label();
            category_path = new Label();
            editcategory_btn = new Button();
            fccontrol_tb = new TextBox();
            label6 = new Label();
            itemdescription_rtb = new RichTextBox();
            client_cb = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            itemdescription_warning = new Label();
            client_warning = new Label();
            fcControl_warning = new Label();
            groupBox2 = new GroupBox();
            width_warning = new Label();
            unfolded_rb = new RadioButton();
            fold_rb = new RadioButton();
            flutetype_cb = new ComboBox();
            width_tb = new TextBox();
            length_tb = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            flute_warning = new Label();
            length_warning = new Label();
            pictureBox1 = new PictureBox();
            add_btn = new Button();
            cancel_btn = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(category_path);
            groupBox1.Controls.Add(editcategory_btn);
            groupBox1.Controls.Add(fccontrol_tb);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(itemdescription_rtb);
            groupBox1.Controls.Add(client_cb);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(itemdescription_warning);
            groupBox1.Controls.Add(client_warning);
            groupBox1.Controls.Add(fcControl_warning);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(573, 130);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Information";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(56, 89);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 28;
            label7.Text = "Category:";
            // 
            // category_path
            // 
            category_path.AutoSize = true;
            category_path.ForeColor = Color.DimGray;
            category_path.Location = new Point(210, 89);
            category_path.Name = "category_path";
            category_path.Size = new Size(74, 15);
            category_path.TabIndex = 27;
            category_path.Text = "No Category";
            // 
            // editcategory_btn
            // 
            editcategory_btn.Location = new Point(120, 85);
            editcategory_btn.Name = "editcategory_btn";
            editcategory_btn.Size = new Size(84, 23);
            editcategory_btn.TabIndex = 26;
            editcategory_btn.Text = "EDIT";
            editcategory_btn.UseVisualStyleBackColor = true;
            editcategory_btn.Click += editcategory_btn_Click;
            // 
            // fccontrol_tb
            // 
            fccontrol_tb.Location = new Point(424, 53);
            fccontrol_tb.Name = "fccontrol_tb";
            fccontrol_tb.Size = new Size(143, 23);
            fccontrol_tb.TabIndex = 15;
            fccontrol_tb.TextChanged += fccontrol_tb_TextChanged;
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
            // itemdescription_rtb
            // 
            itemdescription_rtb.Location = new Point(120, 22);
            itemdescription_rtb.Name = "itemdescription_rtb";
            itemdescription_rtb.Size = new Size(222, 57);
            itemdescription_rtb.TabIndex = 13;
            itemdescription_rtb.Text = "";
            itemdescription_rtb.TextChanged += itemdescription_rtb_TextChanged;
            // 
            // client_cb
            // 
            client_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            client_cb.FormattingEnabled = true;
            client_cb.Location = new Point(402, 19);
            client_cb.Name = "client_cb";
            client_cb.Size = new Size(165, 23);
            client_cb.TabIndex = 3;
            client_cb.SelectedIndexChanged += client_cb_SelectedIndexChanged;
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
            // itemdescription_warning
            // 
            itemdescription_warning.AutoSize = true;
            itemdescription_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            itemdescription_warning.ForeColor = Color.Red;
            itemdescription_warning.Location = new Point(9, 22);
            itemdescription_warning.Name = "itemdescription_warning";
            itemdescription_warning.Size = new Size(14, 19);
            itemdescription_warning.TabIndex = 6;
            itemdescription_warning.Text = "!";
            // 
            // client_warning
            // 
            client_warning.AutoSize = true;
            client_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            client_warning.ForeColor = Color.Red;
            client_warning.Location = new Point(346, 19);
            client_warning.Name = "client_warning";
            client_warning.Size = new Size(14, 19);
            client_warning.TabIndex = 16;
            client_warning.Text = "!";
            // 
            // fcControl_warning
            // 
            fcControl_warning.AutoSize = true;
            fcControl_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            fcControl_warning.ForeColor = Color.Red;
            fcControl_warning.Location = new Point(345, 52);
            fcControl_warning.Name = "fcControl_warning";
            fcControl_warning.Size = new Size(14, 19);
            fcControl_warning.TabIndex = 17;
            fcControl_warning.Text = "!";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(width_warning);
            groupBox2.Controls.Add(unfolded_rb);
            groupBox2.Controls.Add(fold_rb);
            groupBox2.Controls.Add(flutetype_cb);
            groupBox2.Controls.Add(width_tb);
            groupBox2.Controls.Add(length_tb);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(flute_warning);
            groupBox2.Controls.Add(length_warning);
            groupBox2.Location = new Point(12, 139);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(316, 146);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dimensions";
            // 
            // width_warning
            // 
            width_warning.AutoSize = true;
            width_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            width_warning.ForeColor = Color.Red;
            width_warning.Location = new Point(37, 114);
            width_warning.Name = "width_warning";
            width_warning.Size = new Size(14, 19);
            width_warning.TabIndex = 20;
            width_warning.Text = "!";
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
            flutetype_cb.SelectedIndexChanged += flutetype_cb_SelectedIndexChanged;
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
            // flute_warning
            // 
            flute_warning.AutoSize = true;
            flute_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            flute_warning.ForeColor = Color.Red;
            flute_warning.Location = new Point(22, 30);
            flute_warning.Name = "flute_warning";
            flute_warning.Size = new Size(14, 19);
            flute_warning.TabIndex = 18;
            flute_warning.Text = "!";
            // 
            // length_warning
            // 
            length_warning.AutoSize = true;
            length_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            length_warning.ForeColor = Color.Red;
            length_warning.Location = new Point(37, 84);
            length_warning.Name = "length_warning";
            length_warning.Size = new Size(14, 19);
            length_warning.TabIndex = 19;
            length_warning.Text = "!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = TruckEstimation.Properties.Resources.ItemHintPicture;
            pictureBox1.Location = new Point(367, 142);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 176);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // add_btn
            // 
            add_btn.Location = new Point(3, 3);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(91, 33);
            add_btn.TabIndex = 3;
            add_btn.Text = "ADD ITEM";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // cancel_btn
            // 
            cancel_btn.Location = new Point(230, 3);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(91, 33);
            cancel_btn.TabIndex = 4;
            cancel_btn.Text = "CANCEL";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(add_btn);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Controls.Add(cancel_btn);
            flowLayoutPanel1.Location = new Point(12, 290);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(342, 40);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(100, 3);
            button1.Name = "button1";
            button1.Size = new Size(124, 33);
            button1.TabIndex = 5;
            button1.Text = "ADD && COPY";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // AddNewItems_WindowPopUpForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 330);
            Controls.Add(flowLayoutPanel1);
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
            flowLayoutPanel1.ResumeLayout(false);
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
        private RadioButton unfolded_rb;
        private RadioButton fold_rb;
        private RichTextBox itemdescription_rtb;
        private TextBox fccontrol_tb;
        private Label label6;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button1;
        private Label itemdescription_warning;
        private Label client_warning;
        private Label fcControl_warning;
        private Label width_warning;
        private Label flute_warning;
        private Label length_warning;
        private Label label7;
        private Label category_path;
        private Button editcategory_btn;
    }
}