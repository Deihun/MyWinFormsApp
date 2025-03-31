namespace MyWinFormsApp.Sections.Estimate
{
    partial class Estimate_Form
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
            main_tbp = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            truck_cb = new ComboBox();
            category_panel = new Panel();
            category_btn = new Button();
            category_path = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            storedclient_flp = new FlowLayoutPanel();
            stored_bundlecontainer = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            addbundle_btn = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            storeddetailreport_flp = new FlowLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            remarks_rtb = new RichTextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            action_button = new Button();
            main_tbp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            category_panel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // main_tbp
            // 
            main_tbp.ColumnCount = 3;
            main_tbp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            main_tbp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            main_tbp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            main_tbp.Controls.Add(pictureBox1, 1, 0);
            main_tbp.Controls.Add(tableLayoutPanel1, 0, 0);
            main_tbp.Controls.Add(tableLayoutPanel3, 2, 0);
            main_tbp.Controls.Add(flowLayoutPanel3, 2, 1);
            main_tbp.Dock = DockStyle.Fill;
            main_tbp.Location = new Point(0, 0);
            main_tbp.Name = "main_tbp";
            main_tbp.Padding = new Padding(10);
            main_tbp.RowCount = 2;
            main_tbp.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            main_tbp.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            main_tbp.Size = new Size(1443, 649);
            main_tbp.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.Arrow;
            pictureBox1.Location = new Point(653, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 560);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.YellowGreen;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 2);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(10, 10);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 86F));
            tableLayoutPanel1.Size = new Size(640, 566);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(truck_cb);
            flowLayoutPanel1.Controls.Add(category_panel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(640, 39);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3, 3, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 21);
            label1.TabIndex = 0;
            label1.Text = "Truck:";
            // 
            // truck_cb
            // 
            truck_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            truck_cb.FormattingEnabled = true;
            truck_cb.Location = new Point(59, 3);
            truck_cb.Margin = new Padding(0, 3, 3, 3);
            truck_cb.Name = "truck_cb";
            truck_cb.Size = new Size(191, 23);
            truck_cb.TabIndex = 1;
            truck_cb.SelectedIndexChanged += truck_cb_SelectedIndexChanged;
            // 
            // category_panel
            // 
            category_panel.Controls.Add(category_btn);
            category_panel.Controls.Add(category_path);
            category_panel.Location = new Point(256, 3);
            category_panel.Name = "category_panel";
            category_panel.Size = new Size(328, 36);
            category_panel.TabIndex = 3;
            // 
            // category_btn
            // 
            category_btn.Location = new Point(28, 5);
            category_btn.Name = "category_btn";
            category_btn.Size = new Size(130, 22);
            category_btn.TabIndex = 0;
            category_btn.Text = "CHANGE CATEGORY";
            category_btn.UseVisualStyleBackColor = true;
            category_btn.Click += category_btn_Click;
            // 
            // category_path
            // 
            category_path.AutoSize = true;
            category_path.ForeColor = Color.FromArgb(64, 64, 64);
            category_path.Location = new Point(155, 8);
            category_path.Name = "category_path";
            category_path.Size = new Size(74, 15);
            category_path.TabIndex = 1;
            category_path.Text = "No Category";
            category_path.TextChanged += category_path_TextChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Controls.Add(storedclient_flp, 1, 0);
            tableLayoutPanel2.Controls.Add(stored_bundlecontainer, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 78);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(640, 488);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // storedclient_flp
            // 
            storedclient_flp.AutoScroll = true;
            storedclient_flp.BackColor = Color.OliveDrab;
            storedclient_flp.Dock = DockStyle.Fill;
            storedclient_flp.FlowDirection = FlowDirection.TopDown;
            storedclient_flp.Location = new Point(391, 0);
            storedclient_flp.Margin = new Padding(7, 0, 7, 7);
            storedclient_flp.Name = "storedclient_flp";
            storedclient_flp.Padding = new Padding(5);
            storedclient_flp.Size = new Size(242, 481);
            storedclient_flp.TabIndex = 4;
            storedclient_flp.WrapContents = false;
            // 
            // stored_bundlecontainer
            // 
            stored_bundlecontainer.AutoScroll = true;
            stored_bundlecontainer.BackColor = Color.OliveDrab;
            stored_bundlecontainer.Dock = DockStyle.Fill;
            stored_bundlecontainer.FlowDirection = FlowDirection.TopDown;
            stored_bundlecontainer.Location = new Point(7, 0);
            stored_bundlecontainer.Margin = new Padding(7, 0, 7, 7);
            stored_bundlecontainer.Name = "stored_bundlecontainer";
            stored_bundlecontainer.Padding = new Padding(5);
            stored_bundlecontainer.Size = new Size(370, 481);
            stored_bundlecontainer.TabIndex = 3;
            stored_bundlecontainer.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(addbundle_btn);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(0, 39);
            flowLayoutPanel2.Margin = new Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(640, 39);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // addbundle_btn
            // 
            addbundle_btn.BackColor = Color.White;
            addbundle_btn.FlatStyle = FlatStyle.Flat;
            addbundle_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            addbundle_btn.Location = new Point(0, 0);
            addbundle_btn.Margin = new Padding(0);
            addbundle_btn.Name = "addbundle_btn";
            addbundle_btn.Size = new Size(155, 39);
            addbundle_btn.TabIndex = 2;
            addbundle_btn.Text = "ADD BUNDLE (+)";
            addbundle_btn.TextAlign = ContentAlignment.TopCenter;
            addbundle_btn.UseVisualStyleBackColor = false;
            addbundle_btn.Click += addbundle_btn_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.YellowGreen;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(storeddetailreport_flp, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(792, 10);
            tableLayoutPanel3.Margin = new Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.Size = new Size(641, 566);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // storeddetailreport_flp
            // 
            storeddetailreport_flp.AutoScroll = true;
            storeddetailreport_flp.BackColor = Color.OliveDrab;
            storeddetailreport_flp.Dock = DockStyle.Fill;
            storeddetailreport_flp.FlowDirection = FlowDirection.TopDown;
            storeddetailreport_flp.Location = new Point(3, 3);
            storeddetailreport_flp.Name = "storeddetailreport_flp";
            storeddetailreport_flp.Size = new Size(635, 446);
            storeddetailreport_flp.TabIndex = 1;
            storeddetailreport_flp.WrapContents = false;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(remarks_rtb, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 455);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(635, 108);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // remarks_rtb
            // 
            remarks_rtb.BackColor = Color.OliveDrab;
            remarks_rtb.BorderStyle = BorderStyle.None;
            remarks_rtb.Cursor = Cursors.Hand;
            remarks_rtb.Dock = DockStyle.Fill;
            remarks_rtb.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            remarks_rtb.ForeColor = Color.Transparent;
            remarks_rtb.Location = new Point(3, 3);
            remarks_rtb.Name = "remarks_rtb";
            remarks_rtb.Size = new Size(629, 102);
            remarks_rtb.TabIndex = 1;
            remarks_rtb.Text = "Remarks";
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(action_button);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel3.Location = new Point(792, 576);
            flowLayoutPanel3.Margin = new Padding(0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(641, 63);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // action_button
            // 
            action_button.Location = new Point(506, 3);
            action_button.Name = "action_button";
            action_button.Size = new Size(132, 58);
            action_button.TabIndex = 0;
            action_button.Text = "SAVE RECORD";
            action_button.UseVisualStyleBackColor = true;
            action_button.Click += action_button_Click;
            // 
            // Estimate_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1443, 649);
            Controls.Add(main_tbp);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Estimate_Form";
            Text = "Estimate_Form";
            VisibleChanged += Estimate_Form_VisibleChanged;
            main_tbp.ResumeLayout(false);
            main_tbp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            category_panel.ResumeLayout(false);
            category_panel.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel main_tbp;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button addbundle_btn;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private ComboBox truck_cb;
        private FlowLayoutPanel stored_bundlecontainer;
        private TableLayoutPanel tableLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel storedclient_flp;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel storeddetailreport_flp;
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button action_button;
        private RichTextBox remarks_rtb;
        private Panel category_panel;
        private Button category_btn;
        private Label category_path;
    }
}