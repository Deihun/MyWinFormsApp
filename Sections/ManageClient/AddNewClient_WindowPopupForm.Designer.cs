namespace MyWinFormsApp.Sections.ManageClient
{
    partial class AddNewClient_WindowPopupForm
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
            groupBox1 = new GroupBox();
            description_rtb = new RichTextBox();
            label1 = new Label();
            name_lb = new Label();
            clientname_tb = new TextBox();
            condition = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            requirepallet_cb = new CheckBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            add_btn = new Button();
            cancel_btn = new Button();
            requireclearancespace_cb = new CheckBox();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            condition.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(groupBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(condition, 0, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(397, 479);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(description_rtb);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(name_lb);
            groupBox1.Controls.Add(clientname_tb);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(391, 209);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Basic Information";
            // 
            // description_rtb
            // 
            description_rtb.BorderStyle = BorderStyle.FixedSingle;
            description_rtb.Location = new Point(138, 83);
            description_rtb.Margin = new Padding(3, 30, 30, 3);
            description_rtb.Name = "description_rtb";
            description_rtb.Size = new Size(224, 108);
            description_rtb.TabIndex = 3;
            description_rtb.Text = "";
            description_rtb.TextChanged += description_rtb_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 85);
            label1.Margin = new Padding(0, 30, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 1;
            label1.Text = "Client Description:";
            // 
            // name_lb
            // 
            name_lb.AutoSize = true;
            name_lb.Location = new Point(46, 48);
            name_lb.Margin = new Padding(0, 30, 0, 0);
            name_lb.Name = "name_lb";
            name_lb.Size = new Size(76, 15);
            name_lb.TabIndex = 0;
            name_lb.Text = "Client Name:";
            // 
            // clientname_tb
            // 
            clientname_tb.Location = new Point(138, 45);
            clientname_tb.Margin = new Padding(0, 30, 30, 0);
            clientname_tb.Name = "clientname_tb";
            clientname_tb.Size = new Size(224, 23);
            clientname_tb.TabIndex = 2;
            clientname_tb.TextChanged += clientname_tb_TextChanged;
            // 
            // condition
            // 
            condition.Controls.Add(flowLayoutPanel1);
            condition.Dock = DockStyle.Fill;
            condition.Location = new Point(3, 218);
            condition.Name = "condition";
            condition.Size = new Size(391, 209);
            condition.TabIndex = 1;
            condition.TabStop = false;
            condition.Text = "Conditions";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(requirepallet_cb);
            flowLayoutPanel1.Controls.Add(requireclearancespace_cb);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(25);
            flowLayoutPanel1.Size = new Size(385, 187);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // requirepallet_cb
            // 
            requirepallet_cb.AutoSize = true;
            requirepallet_cb.Location = new Point(28, 28);
            requirepallet_cb.Name = "requirepallet_cb";
            requirepallet_cb.Size = new Size(103, 19);
            requirepallet_cb.TabIndex = 0;
            requirepallet_cb.Text = "Requires Pallet";
            requirepallet_cb.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(add_btn);
            flowLayoutPanel2.Controls.Add(cancel_btn);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 433);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(391, 43);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // add_btn
            // 
            add_btn.AutoSize = true;
            add_btn.Dock = DockStyle.Fill;
            add_btn.Location = new Point(3, 3);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(75, 35);
            add_btn.TabIndex = 0;
            add_btn.Text = "ADD";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // cancel_btn
            // 
            cancel_btn.AutoSize = true;
            cancel_btn.Dock = DockStyle.Fill;
            cancel_btn.Location = new Point(84, 3);
            cancel_btn.Name = "cancel_btn";
            cancel_btn.Size = new Size(75, 35);
            cancel_btn.TabIndex = 1;
            cancel_btn.Text = "CANCEL";
            cancel_btn.UseVisualStyleBackColor = true;
            cancel_btn.Click += cancel_btn_Click;
            // 
            // requireclearancespace_cb
            // 
            requireclearancespace_cb.AutoSize = true;
            requireclearancespace_cb.Location = new Point(28, 53);
            requireclearancespace_cb.Name = "requireclearancespace_cb";
            requireclearancespace_cb.Size = new Size(239, 19);
            requireclearancespace_cb.TabIndex = 1;
            requireclearancespace_cb.Text = "Require big spaces in each Bundle inside";
            requireclearancespace_cb.UseVisualStyleBackColor = true;
            // 
            // AddNewClient_WindowPopupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 479);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddNewClient_WindowPopupForm";
            Text = "Add New Client";
            tableLayoutPanel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            condition.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private GroupBox groupBox1;
        private Label name_lb;
        private Label label1;
        private TextBox clientname_tb;
        private RichTextBox description_rtb;
        private GroupBox condition;
        private FlowLayoutPanel flowLayoutPanel1;
        private CheckBox requirepallet_cb;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button add_btn;
        private Button cancel_btn;
        private CheckBox requireclearancespace_cb;
    }
}