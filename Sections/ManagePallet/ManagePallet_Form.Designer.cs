﻿namespace MyWinFormsApp.Sections.ManagePallet
{
    partial class ManagePallet_Form
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
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            label2 = new Label();
            searchname_tb = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel2 = new Panel();
            panel1 = new Panel();
            add_btn = new Button();
            storedarea_flt = new FlowLayoutPanel();
            _no_result = new Label();
            tablelayout_main.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            storedarea_flt.SuspendLayout();
            SuspendLayout();
            // 
            // tablelayout_main
            // 
            tablelayout_main.BackColor = Color.Transparent;
            tablelayout_main.ColumnCount = 1;
            tablelayout_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablelayout_main.Controls.Add(tableLayoutPanel1, 0, 0);
            tablelayout_main.Dock = DockStyle.Fill;
            tablelayout_main.Location = new Point(0, 0);
            tablelayout_main.Margin = new Padding(0);
            tablelayout_main.Name = "tablelayout_main";
            tablelayout_main.RowCount = 1;
            tablelayout_main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tablelayout_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tablelayout_main.Size = new Size(1478, 688);
            tablelayout_main.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1478, 688);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.DarkSeaGreen;
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel3);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(225, 688);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
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
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(searchname_tb, 1, 0);
            tableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel3.Location = new Point(3, 34);
            tableLayoutPanel3.Margin = new Padding(3, 3, 3, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(233, 24);
            tableLayoutPanel3.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Left;
            label2.ForeColor = Color.White;
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(72, 24);
            label2.TabIndex = 6;
            label2.Text = "Pallet name:";
            // 
            // searchname_tb
            // 
            searchname_tb.Dock = DockStyle.Left;
            searchname_tb.ForeColor = Color.Gray;
            searchname_tb.Location = new Point(81, 0);
            searchname_tb.Margin = new Padding(0);
            searchname_tb.Name = "searchname_tb";
            searchname_tb.Size = new Size(129, 23);
            searchname_tb.TabIndex = 7;
            searchname_tb.Text = "ex. Standard Pallet";
            searchname_tb.TextChanged += searchname_tb_TextChanged;
            searchname_tb.Enter += searchname_tb_Enter;
            searchname_tb.Leave += searchname_tb_Leave;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(panel2, 0, 2);
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(storedarea_flt, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(225, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel2.Size = new Size(1253, 688);
            tableLayoutPanel2.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.OliveDrab;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 653);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1253, 35);
            panel2.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.OliveDrab;
            panel1.Controls.Add(add_btn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1253, 50);
            panel1.TabIndex = 0;
            // 
            // add_btn
            // 
            add_btn.AutoSize = true;
            add_btn.Location = new Point(0, 0);
            add_btn.Margin = new Padding(0);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(216, 50);
            add_btn.TabIndex = 0;
            add_btn.Text = "ADD NEW PALLET PRESET";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // storedarea_flt
            // 
            storedarea_flt.AutoScroll = true;
            storedarea_flt.Controls.Add(_no_result);
            storedarea_flt.FlowDirection = FlowDirection.TopDown;
            storedarea_flt.Location = new Point(0, 50);
            storedarea_flt.Margin = new Padding(0);
            storedarea_flt.Name = "storedarea_flt";
            storedarea_flt.Padding = new Padding(10);
            storedarea_flt.Size = new Size(1253, 603);
            storedarea_flt.TabIndex = 4;
            storedarea_flt.WrapContents = false;
            storedarea_flt.Paint += storedarea_flt_Paint;
            // 
            // _no_result
            // 
            _no_result.AutoSize = true;
            _no_result.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            _no_result.ForeColor = Color.LimeGreen;
            _no_result.Location = new Point(210, 110);
            _no_result.Margin = new Padding(200, 100, 3, 0);
            _no_result.Name = "_no_result";
            _no_result.Size = new Size(344, 46);
            _no_result.TabIndex = 4;
            _no_result.Text = "NO RECORD RESULT";
            _no_result.TextAlign = ContentAlignment.MiddleCenter;
            _no_result.Visible = false;
            // 
            // ManagePallet_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1478, 688);
            Controls.Add(tablelayout_main);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManagePallet_Form";
            Text = "ManagePallet_Form";
            Load += ManagePallet_Form_Load;
            VisibleChanged += ManagePallet_Form_VisibleChanged;
            tablelayout_main.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            storedarea_flt.ResumeLayout(false);
            storedarea_flt.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tablelayout_main;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label2;
        private TextBox searchname_tb;
        private FlowLayoutPanel storedarea_flt;
        private Button add_btn;
        private Label _no_result;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel2;
        private Panel panel1;
    }
}