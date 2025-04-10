namespace MyWinFormsApp.Sections.Record
{
    partial class ViewRecord_Form
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
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            clear_btn = new Button();
            search_btn = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            label2 = new Label();
            searchname_tb = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            client_cb = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            label4 = new Label();
            truck_cb = new ComboBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label5 = new Label();
            month_cb = new ComboBox();
            year_cb = new ComboBox();
            label6 = new Label();
            tableLayoutPanel5 = new TableLayoutPanel();
            panel2 = new Panel();
            panel1 = new Panel();
            storedarea_flt = new FlowLayoutPanel();
            _no_result = new Label();
            tablelayout_main.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
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
            tablelayout_main.Size = new Size(1443, 649);
            tablelayout_main.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 225F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1443, 649);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.DarkSeaGreen;
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Controls.Add(search_btn);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel3);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel2);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel4);
            flowLayoutPanel1.Controls.Add(flowLayoutPanel4);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(225, 649);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.Controls.Add(clear_btn);
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(213, 28);
            flowLayoutPanel2.TabIndex = 10;
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
            // clear_btn
            // 
            clear_btn.BackColor = Color.White;
            clear_btn.FlatStyle = FlatStyle.Flat;
            clear_btn.Location = new Point(139, 3);
            clear_btn.Margin = new Padding(75, 3, 3, 3);
            clear_btn.Name = "clear_btn";
            clear_btn.Size = new Size(69, 23);
            clear_btn.TabIndex = 9;
            clear_btn.Text = "CLEAR";
            clear_btn.UseVisualStyleBackColor = false;
            clear_btn.Click += clear_btn_Click;
            // 
            // search_btn
            // 
            search_btn.BackColor = Color.White;
            search_btn.Dock = DockStyle.Right;
            search_btn.FlatStyle = FlatStyle.Flat;
            search_btn.Location = new Point(142, 34);
            search_btn.Margin = new Padding(0, 0, 30, 0);
            search_btn.Name = "search_btn";
            search_btn.Size = new Size(67, 23);
            search_btn.TabIndex = 14;
            search_btn.Text = "SEARCH";
            search_btn.UseVisualStyleBackColor = false;
            search_btn.Click += search_btn_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(searchname_tb, 1, 0);
            tableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel3.Location = new Point(3, 60);
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
            label2.Size = new Size(69, 24);
            label2.TabIndex = 6;
            label2.Text = "Item Name:";
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
            searchname_tb.Text = "ex. Piatos";
            searchname_tb.Enter += searchname_tb_Enter;
            searchname_tb.Leave += searchname_tb_Leave;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Controls.Add(client_cb, 1, 0);
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel2.Location = new Point(3, 87);
            tableLayoutPanel2.Margin = new Padding(3, 3, 3, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(233, 24);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(76, 24);
            label3.TabIndex = 6;
            label3.Text = "Client Name:";
            // 
            // client_cb
            // 
            client_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            client_cb.FlatStyle = FlatStyle.Flat;
            client_cb.FormattingEnabled = true;
            client_cb.Location = new Point(81, 0);
            client_cb.Margin = new Padding(0);
            client_cb.Name = "client_cb";
            client_cb.Size = new Size(129, 23);
            client_cb.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel4.Controls.Add(label4, 0, 0);
            tableLayoutPanel4.Controls.Add(truck_cb, 1, 0);
            tableLayoutPanel4.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel4.Location = new Point(3, 114);
            tableLayoutPanel4.Margin = new Padding(3, 3, 3, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(233, 24);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Left;
            label4.ForeColor = Color.White;
            label4.Location = new Point(0, 0);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(72, 24);
            label4.TabIndex = 6;
            label4.Text = "Truck_Name";
            // 
            // truck_cb
            // 
            truck_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            truck_cb.FlatStyle = FlatStyle.Flat;
            truck_cb.FormattingEnabled = true;
            truck_cb.Location = new Point(81, 0);
            truck_cb.Margin = new Padding(0);
            truck_cb.Name = "truck_cb";
            truck_cb.Size = new Size(129, 23);
            truck_cb.TabIndex = 7;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label5);
            flowLayoutPanel4.Controls.Add(month_cb);
            flowLayoutPanel4.Controls.Add(year_cb);
            flowLayoutPanel4.Location = new Point(3, 141);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(213, 31);
            flowLayoutPanel4.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Left;
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 0);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(34, 23);
            label5.TabIndex = 7;
            label5.Text = "Date:";
            // 
            // month_cb
            // 
            month_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            month_cb.FlatStyle = FlatStyle.Flat;
            month_cb.FormattingEnabled = true;
            month_cb.Items.AddRange(new object[] { "<month>", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" });
            month_cb.Location = new Point(81, 0);
            month_cb.Margin = new Padding(47, 0, 0, 0);
            month_cb.Name = "month_cb";
            month_cb.Size = new Size(75, 23);
            month_cb.TabIndex = 8;
            // 
            // year_cb
            // 
            year_cb.FlatStyle = FlatStyle.Flat;
            year_cb.FormattingEnabled = true;
            year_cb.Location = new Point(156, 0);
            year_cb.Margin = new Padding(0);
            year_cb.Name = "year_cb";
            year_cb.Size = new Size(53, 23);
            year_cb.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(3, 205);
            label6.Margin = new Padding(3, 30, 3, 10);
            label6.Name = "label6";
            label6.Size = new Size(95, 21);
            label6.TabIndex = 13;
            label6.Text = "CATEGORY:";
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(panel2, 0, 0);
            tableLayoutPanel5.Controls.Add(panel1, 0, 2);
            tableLayoutPanel5.Controls.Add(storedarea_flt, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(225, 0);
            tableLayoutPanel5.Margin = new Padding(0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 3;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel5.Size = new Size(1218, 649);
            tableLayoutPanel5.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.BackColor = Color.OliveDrab;
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1218, 50);
            panel2.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.BackColor = Color.OliveDrab;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 614);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1218, 35);
            panel1.TabIndex = 9;
            // 
            // storedarea_flt
            // 
            storedarea_flt.AutoScroll = true;
            storedarea_flt.Controls.Add(_no_result);
            storedarea_flt.Dock = DockStyle.Fill;
            storedarea_flt.FlowDirection = FlowDirection.TopDown;
            storedarea_flt.Location = new Point(0, 50);
            storedarea_flt.Margin = new Padding(0);
            storedarea_flt.Name = "storedarea_flt";
            storedarea_flt.Padding = new Padding(10);
            storedarea_flt.Size = new Size(1218, 564);
            storedarea_flt.TabIndex = 4;
            storedarea_flt.WrapContents = false;
            // 
            // _no_result
            // 
            _no_result.AutoSize = true;
            _no_result.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            _no_result.ForeColor = Color.SeaGreen;
            _no_result.Location = new Point(210, 110);
            _no_result.Margin = new Padding(200, 100, 3, 0);
            _no_result.Name = "_no_result";
            _no_result.Size = new Size(344, 46);
            _no_result.TabIndex = 0;
            _no_result.Text = "NO RECORD RESULT";
            _no_result.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ViewRecord_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1443, 649);
            Controls.Add(tablelayout_main);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewRecord_Form";
            Text = "ViewRecord_Form";
            VisibleChanged += ViewRecord_Form_VisibleChanged;
            tablelayout_main.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            tableLayoutPanel5.ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private ComboBox client_cb;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label4;
        private ComboBox truck_cb;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button clear_btn;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label5;
        private ComboBox month_cb;
        private ComboBox year_cb;
        private Label _no_result;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel2;
        private Label label6;
        private Button search_btn;
    }
}