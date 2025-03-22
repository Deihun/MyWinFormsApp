namespace MyWinFormsApp.Sections.ManageItems
{
    partial class ViewPerItem_Form
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            client_label = new Label();
            flute_label = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            delete_btn = new Button();
            edit_btn = new Button();
            itemname_label = new Label();
            content_label = new Label();
            fcc_label = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flute_label, 2, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 2, 1);
            tableLayoutPanel1.Controls.Add(itemname_label, 1, 0);
            tableLayoutPanel1.Controls.Add(content_label, 1, 1);
            tableLayoutPanel1.Controls.Add(fcc_label, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new Size(840, 226);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(client_label);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(180, 45);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // client_label
            // 
            client_label.AutoSize = true;
            client_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            client_label.Location = new Point(3, 0);
            client_label.Name = "client_label";
            client_label.Size = new Size(86, 21);
            client_label.TabIndex = 0;
            client_label.Text = "<CLIENT>";
            // 
            // flute_label
            // 
            flute_label.AutoSize = true;
            flute_label.Dock = DockStyle.Fill;
            flute_label.Font = new Font("Segoe UI", 10F);
            flute_label.Location = new Point(723, 0);
            flute_label.Name = "flute_label";
            flute_label.Size = new Size(114, 45);
            flute_label.TabIndex = 1;
            flute_label.Text = "<FLUTETYPE>";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(delete_btn);
            flowLayoutPanel2.Controls.Add(edit_btn);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel2.Location = new Point(720, 45);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(120, 181);
            flowLayoutPanel2.TabIndex = 4;
            flowLayoutPanel2.WrapContents = false;
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.FromArgb(192, 0, 0);
            delete_btn.FlatStyle = FlatStyle.Flat;
            delete_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            delete_btn.ForeColor = Color.FromArgb(255, 192, 192);
            delete_btn.Location = new Point(0, 161);
            delete_btn.Margin = new Padding(0);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(120, 20);
            delete_btn.TabIndex = 4;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.FlatStyle = FlatStyle.Flat;
            edit_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            edit_btn.Location = new Point(0, 141);
            edit_btn.Margin = new Padding(0);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(120, 20);
            edit_btn.TabIndex = 3;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // itemname_label
            // 
            itemname_label.AutoSize = true;
            itemname_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            itemname_label.Location = new Point(180, 0);
            itemname_label.Margin = new Padding(0, 0, 3, 0);
            itemname_label.Name = "itemname_label";
            itemname_label.Size = new Size(154, 28);
            itemname_label.TabIndex = 1;
            itemname_label.Text = "<ITEM NAME>";
            // 
            // content_label
            // 
            content_label.AutoSize = true;
            content_label.Font = new Font("Segoe UI", 14F);
            content_label.ForeColor = Color.FromArgb(64, 64, 64);
            content_label.Location = new Point(210, 60);
            content_label.Margin = new Padding(30, 15, 3, 0);
            content_label.Name = "content_label";
            content_label.Size = new Size(159, 100);
            content_label.TabIndex = 2;
            content_label.Text = "length:         XXXX\r\nwidth:          XXXX\r\nheight:         XXXX\r\nDimension: XXXX";
            // 
            // fcc_label
            // 
            fcc_label.AutoSize = true;
            fcc_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            fcc_label.ForeColor = Color.FromArgb(64, 0, 0);
            fcc_label.Location = new Point(3, 45);
            fcc_label.Name = "fcc_label";
            fcc_label.Size = new Size(57, 21);
            fcc_label.TabIndex = 5;
            fcc_label.Text = "label1";
            // 
            // ViewPerItem_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 226);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewPerItem_Form";
            Text = "ViewPerItem_Form";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label client_label;
        private Label itemname_label;
        private Label flute_label;
        private Label content_label;
        private Button edit_btn;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button delete_btn;
        private Label fcc_label;
    }
}