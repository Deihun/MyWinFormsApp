namespace MyWinFormsApp.Sections.ManageTrucks
{
    partial class ManageTrucks_Form
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
            tablelayout_main = new TableLayoutPanel();
            add_btn = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label2 = new Label();
            platenumbersearch_tb = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            wheelertype_cb = new ComboBox();
            storedarea_flt = new FlowLayoutPanel();
            tablelayout_main.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tablelayout_main
            // 
            tablelayout_main.BackColor = Color.PaleGreen;
            tablelayout_main.ColumnCount = 1;
            tablelayout_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablelayout_main.Controls.Add(add_btn, 0, 0);
            tablelayout_main.Controls.Add(tableLayoutPanel1, 0, 1);
            tablelayout_main.Dock = DockStyle.Fill;
            tablelayout_main.Location = new Point(0, 0);
            tablelayout_main.Margin = new Padding(0);
            tablelayout_main.Name = "tablelayout_main";
            tablelayout_main.RowCount = 2;
            tablelayout_main.RowStyles.Add(new RowStyle(SizeType.Percent, 6F));
            tablelayout_main.RowStyles.Add(new RowStyle(SizeType.Percent, 94F));
            tablelayout_main.Size = new Size(1478, 688);
            tablelayout_main.TabIndex = 2;
            // 
            // add_btn
            // 
            add_btn.Dock = DockStyle.Left;
            add_btn.Location = new Point(3, 3);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(217, 35);
            add_btn.TabIndex = 0;
            add_btn.Text = "ADD NEW TRUCK";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(storedarea_flt, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 41);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1478, 647);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.DarkSeaGreen;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel3);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel2);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(221, 647);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 0);
            label1.Margin = new Padding(3, 0, 3, 10);
            label1.Name = "label1";
            label1.Size = new Size(58, 21);
            label1.TabIndex = 3;
            label1.Text = "FILTER";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(platenumbersearch_tb, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Left;
            tableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel3.Location = new Point(3, 34);
            tableLayoutPanel3.Margin = new Padding(3, 3, 3, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(208, 24);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(78, 24);
            label2.TabIndex = 6;
            label2.Text = "plate number";
            // 
            // platenumbersearch_tb
            // 
            platenumbersearch_tb.Dock = DockStyle.Left;
            platenumbersearch_tb.Location = new Point(83, 0);
            platenumbersearch_tb.Margin = new Padding(0);
            platenumbersearch_tb.Name = "platenumbersearch_tb";
            platenumbersearch_tb.Size = new Size(125, 23);
            platenumbersearch_tb.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Controls.Add(wheelertype_cb, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Left;
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel2.Location = new Point(3, 61);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(208, 25);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(34, 25);
            label3.TabIndex = 5;
            label3.Text = "Type:";
            // 
            // wheelertype_cb
            // 
            wheelertype_cb.Dock = DockStyle.Left;
            wheelertype_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            wheelertype_cb.FormattingEnabled = true;
            wheelertype_cb.Location = new Point(83, 0);
            wheelertype_cb.Margin = new Padding(0);
            wheelertype_cb.Name = "wheelertype_cb";
            wheelertype_cb.Size = new Size(125, 23);
            wheelertype_cb.TabIndex = 6;
            // 
            // storedarea_flt
            // 
            storedarea_flt.Dock = DockStyle.Fill;
            storedarea_flt.FlowDirection = FlowDirection.TopDown;
            storedarea_flt.Location = new Point(221, 0);
            storedarea_flt.Margin = new Padding(0);
            storedarea_flt.Name = "storedarea_flt";
            storedarea_flt.Size = new Size(1257, 647);
            storedarea_flt.TabIndex = 4;
            // 
            // ManageTrucks_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleGreen;
            ClientSize = new Size(1478, 688);
            Controls.Add(tablelayout_main);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManageTrucks_Form";
            Text = "ManageTrucks_Form";
            tablelayout_main.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tablelayout_main;
        private Button add_btn;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label2;
        private TextBox platenumbersearch_tb;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private ComboBox wheelertype_cb;
        private FlowLayoutPanel storedarea_flt;
    }
}