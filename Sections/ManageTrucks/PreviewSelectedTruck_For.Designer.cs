namespace MyWinFormsApp.Sections.ManageTrucks
{
    partial class PreviewSelectedTruck_Form
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
            trucktype_label = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            delete_btn = new Button();
            edit_btn = new Button();
            panel5 = new Panel();
            id_label = new Label();
            dimensions_label = new Label();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(trucktype_label, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Controls.Add(dimensions_label, 0, 1);
            tableLayoutPanel1.Location = new Point(0, -3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Size = new Size(840, 220);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // trucktype_label
            // 
            trucktype_label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            trucktype_label.AutoSize = true;
            trucktype_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            trucktype_label.Location = new Point(0, 9);
            trucktype_label.Margin = new Padding(0, 0, 3, 0);
            trucktype_label.Name = "trucktype_label";
            trucktype_label.Size = new Size(753, 25);
            trucktype_label.TabIndex = 1;
            trucktype_label.Text = "<TRUCKTYPE>";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(delete_btn);
            flowLayoutPanel1.Controls.Add(edit_btn);
            flowLayoutPanel1.Controls.Add(panel5);
            flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel1.Location = new Point(756, 44);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(84, 175);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.FromArgb(192, 0, 0);
            delete_btn.FlatStyle = FlatStyle.Flat;
            delete_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            delete_btn.ForeColor = Color.FromArgb(255, 192, 192);
            delete_btn.Location = new Point(0, 153);
            delete_btn.Margin = new Padding(0);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(84, 22);
            delete_btn.TabIndex = 0;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.FlatStyle = FlatStyle.Flat;
            edit_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            edit_btn.Location = new Point(0, 133);
            edit_btn.Margin = new Padding(0);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(84, 20);
            edit_btn.TabIndex = 1;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(id_label);
            panel5.Location = new Point(0, 5);
            panel5.Margin = new Padding(0, 0, 3, 85);
            panel5.Name = "panel5";
            panel5.Size = new Size(86, 43);
            panel5.TabIndex = 15;
            // 
            // id_label
            // 
            id_label.AutoSize = true;
            id_label.Dock = DockStyle.Right;
            id_label.Font = new Font("Segoe UI", 15F);
            id_label.Location = new Point(3, 0);
            id_label.Name = "id_label";
            id_label.Size = new Size(83, 28);
            id_label.TabIndex = 11;
            id_label.Text = "ID:####";
            // 
            // dimensions_label
            // 
            dimensions_label.AutoSize = true;
            dimensions_label.Font = new Font("Segoe UI", 15F);
            dimensions_label.ForeColor = Color.FromArgb(64, 64, 64);
            dimensions_label.Location = new Point(100, 59);
            dimensions_label.Margin = new Padding(100, 15, 3, 0);
            dimensions_label.Name = "dimensions_label";
            dimensions_label.Size = new Size(141, 112);
            dimensions_label.TabIndex = 2;
            dimensions_label.Text = "Length: xxx\r\nWidth : xxx\r\nHeight: xxx\r\nDimension: xxx";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Location = new Point(-2, 217);
            panel1.Name = "panel1";
            panel1.Size = new Size(842, 10);
            panel1.TabIndex = 1;
            // 
            // PreviewSelectedTruck_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 226);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PreviewSelectedTruck_Form";
            Text = "PreviewSelectedTruck_For";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label trucktype_label;
        private Label dimensions_label;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button delete_btn;
        private Button edit_btn;
        private Panel panel1;
        private Panel panel5;
        private Label id_label;
    }
}