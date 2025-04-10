namespace MyWinFormsApp.Sections.Estimate
{
    partial class Text_Unit_Conversion_list
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            content_label = new Label();
            unit_cb = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tableLayoutPanel1.Controls.Add(content_label, 0, 0);
            tableLayoutPanel1.Controls.Add(unit_cb, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(336, 24);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // content_label
            // 
            content_label.AutoSize = true;
            content_label.BackColor = Color.Transparent;
            content_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            content_label.ForeColor = Color.DimGray;
            content_label.Location = new Point(3, 0);
            content_label.Name = "content_label";
            content_label.Size = new Size(104, 21);
            content_label.TabIndex = 0;
            content_label.Text = "<CONTEXT>";
            // 
            // unit_cb
            // 
            unit_cb.Dock = DockStyle.Fill;
            unit_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_cb.FormattingEnabled = true;
            unit_cb.Items.AddRange(new object[] { "mm", "cm", "inches", "m" });
            unit_cb.Location = new Point(256, 0);
            unit_cb.Margin = new Padding(0);
            unit_cb.Name = "unit_cb";
            unit_cb.Size = new Size(80, 23);
            unit_cb.TabIndex = 1;
            unit_cb.SelectedIndexChanged += unit_cb_SelectedIndexChanged;
            // 
            // Text_Unit_Conversion_list
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "Text_Unit_Conversion_list";
            Size = new Size(336, 24);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label content_label;
        private ComboBox unit_cb;
    }
}
