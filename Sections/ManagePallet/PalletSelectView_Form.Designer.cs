namespace MyWinFormsApp.Sections.ManagePallet
{
    partial class PalletSelectView_Form
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
            delete_btn = new Button();
            edit_btn = new Button();
            content_label = new Label();
            name_label = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 87.23404F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.7659578F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Controls.Add(content_label, 0, 1);
            tableLayoutPanel1.Controls.Add(name_label, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.8712873F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.1287155F));
            tableLayoutPanel1.Size = new Size(840, 226);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(delete_btn);
            flowLayoutPanel1.Controls.Add(edit_btn);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel1.Location = new Point(732, 29);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(108, 197);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.WrapContents = false;
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.FromArgb(192, 0, 0);
            delete_btn.FlatStyle = FlatStyle.Flat;
            delete_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            delete_btn.ForeColor = Color.FromArgb(255, 192, 192);
            delete_btn.Location = new Point(0, 176);
            delete_btn.Margin = new Padding(0);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(101, 21);
            delete_btn.TabIndex = 0;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.FlatStyle = FlatStyle.Flat;
            edit_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            edit_btn.Location = new Point(0, 155);
            edit_btn.Margin = new Padding(0);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(101, 21);
            edit_btn.TabIndex = 1;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // content_label
            // 
            content_label.AutoSize = true;
            content_label.Dock = DockStyle.Left;
            content_label.Font = new Font("Segoe UI", 15F);
            content_label.ForeColor = Color.FromArgb(64, 64, 64);
            content_label.Location = new Point(120, 44);
            content_label.Margin = new Padding(120, 15, 3, 0);
            content_label.Name = "content_label";
            content_label.Size = new Size(163, 182);
            content_label.TabIndex = 2;
            content_label.Text = "Length(mm): XXX\r\nWidth(mm):  XXX\r\nHeight(mm): XXX";
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.Dock = DockStyle.Left;
            name_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            name_label.Location = new Point(3, 0);
            name_label.Name = "name_label";
            name_label.Size = new Size(94, 29);
            name_label.TabIndex = 1;
            name_label.Text = "<NAME>";
            // 
            // PalletSelectView_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 226);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PalletSelectView_Form";
            Text = "PalletSelectView_Form";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button delete_btn;
        private Button edit_btn;
        private Label name_label;
        private Label content_label;
    }
}