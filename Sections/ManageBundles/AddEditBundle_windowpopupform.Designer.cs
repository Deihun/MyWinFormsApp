namespace MyWinFormsApp.Sections.ManageBundles
{
    partial class AddEditBundle_windowpopupform
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
            itemlist_cb = new ComboBox();
            quantity_tb = new TextBox();
            label3 = new Label();
            details_label = new Label();
            add_btn = new Button();
            cancel_btn = new Button();
            item_warning = new Label();
            quantity_warning = new Label();
            label7 = new Label();
            category_path = new Label();
            editcategory_btn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 13);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Item: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(325, 14);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Quantity:";
            // 
            // itemlist_cb
            // 
            itemlist_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            itemlist_cb.FormattingEnabled = true;
            itemlist_cb.Location = new Point(98, 9);
            itemlist_cb.Name = "itemlist_cb";
            itemlist_cb.Size = new Size(190, 23);
            itemlist_cb.TabIndex = 2;
            itemlist_cb.SelectedIndexChanged += itemlist_cb_SelectedIndexChanged;
            // 
            // quantity_tb
            // 
            quantity_tb.Location = new Point(387, 9);
            quantity_tb.MaxLength = 5;
            quantity_tb.Name = "quantity_tb";
            quantity_tb.Size = new Size(132, 23);
            quantity_tb.TabIndex = 3;
            quantity_tb.TextChanged += quantity_tb_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 4;
            label3.Text = "Details:";
            // 
            // details_label
            // 
            details_label.AutoSize = true;
            details_label.ForeColor = SystemColors.ControlDarkDark;
            details_label.Location = new Point(209, 121);
            details_label.Name = "details_label";
            details_label.Size = new Size(112, 15);
            details_label.TabIndex = 5;
            details_label.Text = "Select an Input Item";
            // 
            // add_btn
            // 
            add_btn.Location = new Point(6, 196);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(94, 35);
            add_btn.TabIndex = 6;
            add_btn.Text = "ADD BUNDLE";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // cancel_btn
            // 
            cancel_btn.Location = new Point(106, 195);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(94, 35);
            cancel_btn.TabIndex = 7;
            cancel_btn.Text = "CANCEL";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // item_warning
            // 
            item_warning.AutoSize = true;
            item_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            item_warning.ForeColor = Color.Red;
            item_warning.Location = new Point(44, 12);
            item_warning.Name = "item_warning";
            item_warning.Size = new Size(14, 19);
            item_warning.TabIndex = 18;
            item_warning.Text = "!";
            // 
            // quantity_warning
            // 
            quantity_warning.AutoSize = true;
            quantity_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            quantity_warning.ForeColor = Color.Red;
            quantity_warning.Location = new Point(317, 12);
            quantity_warning.Name = "quantity_warning";
            quantity_warning.Size = new Size(14, 19);
            quantity_warning.TabIndex = 19;
            quantity_warning.Text = "!";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 43);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 28;
            label7.Text = "Category:";
            // 
            // category_path
            // 
            category_path.AutoSize = true;
            category_path.ForeColor = Color.DimGray;
            category_path.Location = new Point(186, 43);
            category_path.Name = "category_path";
            category_path.Size = new Size(74, 15);
            category_path.TabIndex = 27;
            category_path.Text = "No Category";
            // 
            // editcategory_btn
            // 
            editcategory_btn.Location = new Point(96, 39);
            editcategory_btn.Name = "editcategory_btn";
            editcategory_btn.Size = new Size(84, 23);
            editcategory_btn.TabIndex = 26;
            editcategory_btn.Text = "EDIT";
            editcategory_btn.UseVisualStyleBackColor = true;
            editcategory_btn.Click += editcategory_btn_Click;
            // 
            // AddEditBundle_windowpopupform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 234);
            Controls.Add(label7);
            Controls.Add(category_path);
            Controls.Add(editcategory_btn);
            Controls.Add(cancel_btn);
            Controls.Add(add_btn);
            Controls.Add(details_label);
            Controls.Add(label3);
            Controls.Add(quantity_tb);
            Controls.Add(itemlist_cb);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(item_warning);
            Controls.Add(quantity_warning);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddEditBundle_windowpopupform";
            Text = "ADD BUNDLE";
            Load += AddEditBundle_windowpopupform_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox itemlist_cb;
        private TextBox quantity_tb;
        private Label label3;
        private Label details_label;
        private Button add_btn;
        private Button cancel_btn;
        private Label item_warning;
        private Label quantity_warning;
        private Label label7;
        private Label category_path;
        private Button editcategory_btn;
    }
}