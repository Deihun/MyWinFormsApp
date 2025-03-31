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
            label7 = new Label();
            category_path = new Label();
            editcategory_btn = new Button();
            description_warning = new Label();
            name_warning = new Label();
            description_rtb = new RichTextBox();
            label1 = new Label();
            name_lb = new Label();
            clientname_tb = new TextBox();
            condition = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            add_btn = new Button();
            cancel_btn = new Button();
            tableLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            condition.SuspendLayout();
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
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(category_path);
            groupBox1.Controls.Add(editcategory_btn);
            groupBox1.Controls.Add(description_warning);
            groupBox1.Controls.Add(name_warning);
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(73, 171);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 28;
            label7.Text = "Category:";
            // 
            // category_path
            // 
            category_path.AutoSize = true;
            category_path.ForeColor = Color.DimGray;
            category_path.Location = new Point(227, 171);
            category_path.Name = "category_path";
            category_path.Size = new Size(74, 15);
            category_path.TabIndex = 27;
            category_path.Text = "No Category";
            // 
            // editcategory_btn
            // 
            editcategory_btn.Location = new Point(137, 167);
            editcategory_btn.Name = "editcategory_btn";
            editcategory_btn.Size = new Size(84, 23);
            editcategory_btn.TabIndex = 26;
            editcategory_btn.Text = "EDIT";
            editcategory_btn.UseVisualStyleBackColor = true;
            editcategory_btn.Click += editcategory_btn_Click;
            // 
            // description_warning
            // 
            description_warning.AutoSize = true;
            description_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            description_warning.ForeColor = Color.Red;
            description_warning.Location = new Point(5, 52);
            description_warning.Name = "description_warning";
            description_warning.Size = new Size(14, 19);
            description_warning.TabIndex = 21;
            description_warning.Text = "!";
            // 
            // name_warning
            // 
            name_warning.AutoSize = true;
            name_warning.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            name_warning.ForeColor = Color.Red;
            name_warning.Location = new Point(40, 23);
            name_warning.Name = "name_warning";
            name_warning.Size = new Size(14, 19);
            name_warning.TabIndex = 20;
            name_warning.Text = "!";
            // 
            // description_rtb
            // 
            description_rtb.BorderStyle = BorderStyle.FixedSingle;
            description_rtb.Location = new Point(138, 54);
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
            label1.Location = new Point(29, 56);
            label1.Margin = new Padding(0, 30, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 1;
            label1.Text = "Client Description:";
            // 
            // name_lb
            // 
            name_lb.AutoSize = true;
            name_lb.Location = new Point(57, 25);
            name_lb.Margin = new Padding(0, 30, 0, 0);
            name_lb.Name = "name_lb";
            name_lb.Size = new Size(76, 15);
            name_lb.TabIndex = 0;
            name_lb.Text = "Client Name:";
            // 
            // clientname_tb
            // 
            clientname_tb.Location = new Point(138, 22);
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
            condition.Text = "Conditions (optional)";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(3, 19);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(25);
            flowLayoutPanel1.Size = new Size(385, 187);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
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
        private FlowLayoutPanel flowLayoutPanel2;
        private Button add_btn;
        private Button cancel_btn;
        private Label description_warning;
        private Label name_warning;
        private Label label7;
        private Label category_path;
        private Button editcategory_btn;
    }
}