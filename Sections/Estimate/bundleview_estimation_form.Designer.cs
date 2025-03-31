namespace MyWinFormsApp.Sections.Estimate
{
    partial class bundleview_estimation_form
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
            tableLayoutPanel1 = new TableLayoutPanel();
            quantityholder_flp = new FlowLayoutPanel();
            label2 = new Label();
            totalbundletoload_tb = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            bundleitem_combobox = new ComboBox();
            delete_button = new Button();
            content_label = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            palletEnabler_checkbox = new CheckBox();
            quantityof_pallet = new TextBox();
            palletchoice_combobox = new ComboBox();
            error_provider = new Label();
            tableLayoutPanel1.SuspendLayout();
            quantityholder_flp.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(quantityholder_flp, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(delete_button, 0, 4);
            tableLayoutPanel1.Controls.Add(content_label, 0, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(325, 193);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // quantityholder_flp
            // 
            quantityholder_flp.Controls.Add(label2);
            quantityholder_flp.Controls.Add(totalbundletoload_tb);
            quantityholder_flp.Dock = DockStyle.Fill;
            quantityholder_flp.Location = new Point(0, 40);
            quantityholder_flp.Margin = new Padding(0);
            quantityholder_flp.Name = "quantityholder_flp";
            quantityholder_flp.Size = new Size(325, 20);
            quantityholder_flp.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 0);
            label2.Margin = new Padding(3, 0, 0, 0);
            label2.Name = "label2";
            label2.Size = new Size(164, 15);
            label2.TabIndex = 3;
            label2.Text = "Total Bundles to load in Truck:";
            // 
            // totalbundletoload_tb
            // 
            totalbundletoload_tb.Font = new Font("Segoe UI", 7F);
            totalbundletoload_tb.Location = new Point(167, 0);
            totalbundletoload_tb.Margin = new Padding(0);
            totalbundletoload_tb.MaxLength = 3;
            totalbundletoload_tb.Name = "totalbundletoload_tb";
            totalbundletoload_tb.Size = new Size(71, 20);
            totalbundletoload_tb.TabIndex = 4;
            totalbundletoload_tb.TextAlign = HorizontalAlignment.Center;
            totalbundletoload_tb.TextChanged += totalbundletoload_tb_TextChanged;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.Controls.Add(bundleitem_combobox);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 0);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(325, 20);
            flowLayoutPanel2.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Margin = new Padding(3, 0, 34, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 2;
            label1.Text = "Bundle";
            // 
            // bundleitem_combobox
            // 
            bundleitem_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            bundleitem_combobox.Font = new Font("Segoe UI", 8F);
            bundleitem_combobox.FormattingEnabled = true;
            bundleitem_combobox.Items.AddRange(new object[] { "<Select an Item-Bundle>" });
            bundleitem_combobox.Location = new Point(88, 0);
            bundleitem_combobox.Margin = new Padding(7, 0, 0, 0);
            bundleitem_combobox.Name = "bundleitem_combobox";
            bundleitem_combobox.Size = new Size(224, 21);
            bundleitem_combobox.Sorted = true;
            bundleitem_combobox.TabIndex = 1;
            bundleitem_combobox.DrawItem += bundleitem_combobox_DrawItem;
            bundleitem_combobox.SelectedIndexChanged += bundleitem_combobox_SelectedIndexChanged;
            // 
            // delete_button
            // 
            delete_button.BackColor = Color.FromArgb(192, 0, 0);
            delete_button.Dock = DockStyle.Right;
            delete_button.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 0);
            delete_button.FlatStyle = FlatStyle.Flat;
            delete_button.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            delete_button.ForeColor = Color.FromArgb(255, 192, 192);
            delete_button.Location = new Point(250, 173);
            delete_button.Margin = new Padding(0);
            delete_button.Name = "delete_button";
            delete_button.Size = new Size(75, 20);
            delete_button.TabIndex = 3;
            delete_button.Text = "DELETE";
            delete_button.UseVisualStyleBackColor = false;
            delete_button.Click += delete_button_Click;
            // 
            // content_label
            // 
            content_label.AutoSize = true;
            content_label.Location = new Point(25, 65);
            content_label.Margin = new Padding(25, 5, 3, 0);
            content_label.Name = "content_label";
            content_label.Size = new Size(64, 15);
            content_label.TabIndex = 4;
            content_label.Text = "<content>";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(palletEnabler_checkbox);
            flowLayoutPanel1.Controls.Add(quantityof_pallet);
            flowLayoutPanel1.Controls.Add(palletchoice_combobox);
            flowLayoutPanel1.Controls.Add(error_provider);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 20);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(325, 20);
            flowLayoutPanel1.TabIndex = 2;
            // 
            // palletEnabler_checkbox
            // 
            palletEnabler_checkbox.AutoSize = true;
            palletEnabler_checkbox.Location = new Point(5, 0);
            palletEnabler_checkbox.Margin = new Padding(5, 0, 0, 0);
            palletEnabler_checkbox.Name = "palletEnabler_checkbox";
            palletEnabler_checkbox.Size = new Size(76, 19);
            palletEnabler_checkbox.TabIndex = 0;
            palletEnabler_checkbox.Text = "use pallet";
            palletEnabler_checkbox.UseVisualStyleBackColor = true;
            palletEnabler_checkbox.CheckedChanged += palletEnabler_checkbox_CheckedChanged;
            // 
            // quantityof_pallet
            // 
            quantityof_pallet.Enabled = false;
            quantityof_pallet.ForeColor = Color.DimGray;
            quantityof_pallet.Location = new Point(88, 0);
            quantityof_pallet.Margin = new Padding(7, 0, 0, 0);
            quantityof_pallet.Name = "quantityof_pallet";
            quantityof_pallet.Size = new Size(96, 23);
            quantityof_pallet.TabIndex = 2;
            quantityof_pallet.Text = "qty. of pallet";
            quantityof_pallet.TextChanged += quantityof_pallet_TextChanged;
            quantityof_pallet.Enter += quantityof_pallet_Enter;
            quantityof_pallet.Leave += quantityof_pallet_Leave;
            // 
            // palletchoice_combobox
            // 
            palletchoice_combobox.BackColor = SystemColors.Control;
            palletchoice_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            palletchoice_combobox.Enabled = false;
            palletchoice_combobox.Font = new Font("Segoe UI", 8F);
            palletchoice_combobox.FormattingEnabled = true;
            palletchoice_combobox.Items.AddRange(new object[] { "<Select a Pallet Item>" });
            palletchoice_combobox.Location = new Point(184, 0);
            palletchoice_combobox.Margin = new Padding(0);
            palletchoice_combobox.Name = "palletchoice_combobox";
            palletchoice_combobox.Size = new Size(128, 21);
            palletchoice_combobox.TabIndex = 1;
            palletchoice_combobox.SelectedIndexChanged += palletchoice_combobox_SelectedIndexChanged;
            // 
            // error_provider
            // 
            error_provider.AutoSize = true;
            error_provider.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            error_provider.ForeColor = Color.FromArgb(64, 0, 0);
            error_provider.Location = new Point(312, 0);
            error_provider.Margin = new Padding(0);
            error_provider.Name = "error_provider";
            error_provider.Size = new Size(11, 13);
            error_provider.TabIndex = 3;
            error_provider.Text = "!";
            error_provider.Visible = false;
            // 
            // bundleview_estimation_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.IndianRed;
            ClientSize = new Size(325, 193);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "bundleview_estimation_form";
            Text = "bundleview_estimation_form";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            quantityholder_flp.ResumeLayout(false);
            quantityholder_flp.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox palletEnabler_checkbox;
        private ComboBox palletchoice_combobox;
        private Button delete_button;
        private Label content_label;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label1;
        private ComboBox bundleitem_combobox;
        private FlowLayoutPanel quantityholder_flp;
        private Label label2;
        private TextBox totalbundletoload_tb;
        private TextBox quantityof_pallet;
        private Label error_provider;
    }
}