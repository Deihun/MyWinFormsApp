namespace MyWinFormsApp.Sections
{
    partial class ManageItems_form
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
            label4 = new Label();
            clear_btn = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            label2 = new Label();
            searchname_tb = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            flutetype_cb = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            c = new Label();
            client_cb = new ComboBox();
            label1 = new Label();
            storedarea_flt = new FlowLayoutPanel();
            _no_result = new Label();
            flowLayoutPanel3 = new FlowLayoutPanel();
            add_btn = new Button();
            manageflute_btn = new Button();
            tablelayout_main.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            storedarea_flt.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tablelayout_main
            // 
            tablelayout_main.BackColor = Color.PaleGreen;
            tablelayout_main.ColumnCount = 1;
            tablelayout_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tablelayout_main.Controls.Add(tableLayoutPanel1, 0, 1);
            tablelayout_main.Controls.Add(flowLayoutPanel3, 0, 0);
            tablelayout_main.Dock = DockStyle.Fill;
            tablelayout_main.Location = new Point(0, 0);
            tablelayout_main.Margin = new Padding(0);
            tablelayout_main.Name = "tablelayout_main";
            tablelayout_main.RowCount = 2;
            tablelayout_main.RowStyles.Add(new RowStyle(SizeType.Percent, 6F));
            tablelayout_main.RowStyles.Add(new RowStyle(SizeType.Percent, 94F));
            tablelayout_main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tablelayout_main.Size = new Size(1386, 788);
            tablelayout_main.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(storedarea_flt, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 47);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1386, 741);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.DarkSeaGreen;
            flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel3);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel2);
            flowLayoutPanel1.Controls.Add(tableLayoutPanel4);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(207, 741);
            flowLayoutPanel1.TabIndex = 3;
            flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label4);
            flowLayoutPanel2.Controls.Add(clear_btn);
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(213, 28);
            flowLayoutPanel2.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(3, 0);
            label4.Margin = new Padding(3, 0, 3, 10);
            label4.Name = "label4";
            label4.Size = new Size(58, 21);
            label4.TabIndex = 3;
            label4.Text = "FILTER";
            // 
            // clear_btn
            // 
            clear_btn.BackColor = Color.White;
            clear_btn.FlatStyle = FlatStyle.Flat;
            clear_btn.Location = new Point(134, 3);
            clear_btn.Margin = new Padding(70, 3, 3, 3);
            clear_btn.Name = "clear_btn";
            clear_btn.Size = new Size(69, 23);
            clear_btn.TabIndex = 9;
            clear_btn.Text = "CLEAR";
            clear_btn.UseVisualStyleBackColor = false;
            clear_btn.Click += clear_btn_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel3.Controls.Add(label2, 0, 0);
            tableLayoutPanel3.Controls.Add(searchname_tb, 1, 0);
            tableLayoutPanel3.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel3.Location = new Point(3, 37);
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
            label2.Size = new Size(67, 24);
            label2.TabIndex = 6;
            label2.Text = "item name:";
            // 
            // searchname_tb
            // 
            searchname_tb.Dock = DockStyle.Left;
            searchname_tb.ForeColor = Color.Gray;
            searchname_tb.Location = new Point(69, 0);
            searchname_tb.Margin = new Padding(0);
            searchname_tb.Name = "searchname_tb";
            searchname_tb.Size = new Size(129, 23);
            searchname_tb.TabIndex = 7;
            searchname_tb.Text = "ex. Piatos Small";
            searchname_tb.TextChanged += searchname_tb_TextChanged;
            searchname_tb.Enter += searchname_tb_Enter;
            searchname_tb.Leave += searchname_tb_Leave;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Controls.Add(flutetype_cb, 1, 0);
            tableLayoutPanel2.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel2.Location = new Point(3, 64);
            tableLayoutPanel2.Margin = new Padding(3, 3, 3, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(233, 25);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Left;
            label3.ForeColor = Color.White;
            label3.Location = new Point(0, 0);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 5;
            label3.Text = "flute type:";
            // 
            // flutetype_cb
            // 
            flutetype_cb.Dock = DockStyle.Left;
            flutetype_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            flutetype_cb.FlatStyle = FlatStyle.Flat;
            flutetype_cb.FormattingEnabled = true;
            flutetype_cb.Location = new Point(69, 0);
            flutetype_cb.Margin = new Padding(0);
            flutetype_cb.Name = "flutetype_cb";
            flutetype_cb.Size = new Size(129, 23);
            flutetype_cb.TabIndex = 6;
            flutetype_cb.SelectedIndexChanged += flutetype_cb_SelectedIndexChanged;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel4.Controls.Add(c, 0, 0);
            tableLayoutPanel4.Controls.Add(client_cb, 1, 0);
            tableLayoutPanel4.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel4.Location = new Point(3, 92);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(233, 25);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // c
            // 
            c.AutoSize = true;
            c.Dock = DockStyle.Left;
            c.ForeColor = Color.White;
            c.Location = new Point(0, 0);
            c.Margin = new Padding(0);
            c.Name = "c";
            c.Size = new Size(41, 25);
            c.TabIndex = 5;
            c.Text = "Client:";
            // 
            // client_cb
            // 
            client_cb.Dock = DockStyle.Left;
            client_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            client_cb.FlatStyle = FlatStyle.Flat;
            client_cb.FormattingEnabled = true;
            client_cb.Location = new Point(69, 0);
            client_cb.Margin = new Padding(0);
            client_cb.Name = "client_cb";
            client_cb.Size = new Size(129, 23);
            client_cb.TabIndex = 6;
            client_cb.SelectedIndexChanged += client_cb_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 150);
            label1.Margin = new Padding(3, 30, 3, 10);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 13;
            label1.Text = "CATEGORY:";
            // 
            // storedarea_flt
            // 
            storedarea_flt.Controls.Add(_no_result);
            storedarea_flt.Dock = DockStyle.Fill;
            storedarea_flt.FlowDirection = FlowDirection.TopDown;
            storedarea_flt.Location = new Point(207, 0);
            storedarea_flt.Margin = new Padding(0);
            storedarea_flt.Name = "storedarea_flt";
            storedarea_flt.Size = new Size(1179, 741);
            storedarea_flt.TabIndex = 4;
            // 
            // _no_result
            // 
            _no_result.AutoSize = true;
            _no_result.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            _no_result.ForeColor = Color.LimeGreen;
            _no_result.Location = new Point(200, 100);
            _no_result.Margin = new Padding(200, 100, 3, 0);
            _no_result.Name = "_no_result";
            _no_result.Size = new Size(344, 46);
            _no_result.TabIndex = 1;
            _no_result.Text = "NO RECORD RESULT";
            _no_result.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel3.Controls.Add(add_btn);
            flowLayoutPanel3.Controls.Add(manageflute_btn);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Margin = new Padding(0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(1386, 47);
            flowLayoutPanel3.TabIndex = 8;
            // 
            // add_btn
            // 
            add_btn.Location = new Point(3, 3);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(204, 41);
            add_btn.TabIndex = 0;
            add_btn.Text = "ADD NEW ITEM";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // manageflute_btn
            // 
            manageflute_btn.Location = new Point(213, 3);
            manageflute_btn.Name = "manageflute_btn";
            manageflute_btn.Size = new Size(204, 41);
            manageflute_btn.TabIndex = 1;
            manageflute_btn.Text = "MANAGE FLUTE";
            manageflute_btn.UseVisualStyleBackColor = true;
            manageflute_btn.Click += manageflute_btn_Click;
            // 
            // ManageItems_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1386, 788);
            Controls.Add(tablelayout_main);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManageItems_form";
            Text = "ManageItems_form";
            VisibleChanged += ManageItems_form_VisibleChanged;
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
            storedarea_flt.ResumeLayout(false);
            storedarea_flt.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tablelayout_main;
        private Button add_btn;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel3;
        private ComboBox flutetype_cb;
        private Label label2;
        private TextBox searchname_tb;
        private FlowLayoutPanel storedarea_flt;
        private TableLayoutPanel tableLayoutPanel4;
        private Label c;
        private ComboBox client_cb;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button manageflute_btn;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label4;
        private Button clear_btn;
        private Label _no_result;
        private Label label1;
    }
}