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
            platenumber_label = new Label();
            dimensions_label = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            delete_btn = new Button();
            edit_btn = new Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(trucktype_label, 1, 0);
            tableLayoutPanel1.Controls.Add(platenumber_label, 0, 0);
            tableLayoutPanel1.Controls.Add(dimensions_label, 1, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Size = new Size(1422, 240);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // trucktype_label
            // 
            trucktype_label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            trucktype_label.AutoSize = true;
            trucktype_label.Location = new Point(145, 4);
            trucktype_label.Name = "trucktype_label";
            trucktype_label.Size = new Size(1131, 15);
            trucktype_label.TabIndex = 1;
            trucktype_label.Text = "<TRUCKTYPE>";
            // 
            // platenumber_label
            // 
            platenumber_label.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            platenumber_label.AutoSize = true;
            platenumber_label.Location = new Point(3, 4);
            platenumber_label.Name = "platenumber_label";
            platenumber_label.Size = new Size(136, 15);
            platenumber_label.TabIndex = 0;
            platenumber_label.Text = "<PLATENUMBER>";
            // 
            // dimensions_label
            // 
            dimensions_label.AutoSize = true;
            dimensions_label.Font = new Font("Segoe UI", 15F);
            dimensions_label.Location = new Point(167, 49);
            dimensions_label.Margin = new Padding(25, 25, 3, 0);
            dimensions_label.Name = "dimensions_label";
            dimensions_label.Size = new Size(141, 112);
            dimensions_label.TabIndex = 2;
            dimensions_label.Text = "Length: xxx\r\nWidth : xxx\r\nHeight: xxx\r\nDimension: xxx";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(delete_btn);
            flowLayoutPanel1.Controls.Add(edit_btn);
            flowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel1.Location = new Point(1279, 24);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(143, 216);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(3, 165);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(137, 48);
            delete_btn.TabIndex = 0;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.Location = new Point(3, 111);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(137, 48);
            edit_btn.TabIndex = 1;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // PreviewSelectedTruck_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1452, 270);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PreviewSelectedTruck_Form";
            Padding = new Padding(15);
            Text = "PreviewSelectedTruck_For";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label trucktype_label;
        private Label platenumber_label;
        private Label dimensions_label;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button delete_btn;
        private Button edit_btn;
    }
}