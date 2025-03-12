﻿namespace MyWinFormsApp.Sections.Estimate
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
            tableLayoutPanel2 = new TableLayoutPanel();
            storedclient_flp = new FlowLayoutPanel();
            stored_bundlecontainer = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            addbundle_btn = new Button();
            add_client = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            storeddetailreport_flp = new FlowLayoutPanel();
            contentresult_label = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            storedRuleWarning_flp = new FlowLayoutPanel();
            main_tbp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            storeddetailreport_flp.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
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
            flowLayoutPanel2.Controls.Add(add_client);
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
            addbundle_btn.Size = new Size(128, 39);
            addbundle_btn.TabIndex = 2;
            addbundle_btn.Text = "ADD BUNDLE (+)";
            addbundle_btn.TextAlign = ContentAlignment.TopCenter;
            addbundle_btn.UseVisualStyleBackColor = false;
            addbundle_btn.Click += addbundle_btn_Click;
            // 
            // add_client
            // 
            add_client.BackColor = Color.White;
            add_client.FlatStyle = FlatStyle.Flat;
            add_client.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            add_client.Location = new Point(153, 0);
            add_client.Margin = new Padding(25, 0, 0, 0);
            add_client.Name = "add_client";
            add_client.Size = new Size(153, 39);
            add_client.TabIndex = 3;
            add_client.Text = "ADD CLIENT (+)";
            add_client.TextAlign = ContentAlignment.TopCenter;
            add_client.UseVisualStyleBackColor = false;
            add_client.Click += add_client_Click;
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
            storeddetailreport_flp.Controls.Add(contentresult_label);
            storeddetailreport_flp.Dock = DockStyle.Fill;
            storeddetailreport_flp.FlowDirection = FlowDirection.TopDown;
            storeddetailreport_flp.Location = new Point(3, 3);
            storeddetailreport_flp.Name = "storeddetailreport_flp";
            storeddetailreport_flp.Size = new Size(635, 446);
            storeddetailreport_flp.TabIndex = 1;
            storeddetailreport_flp.WrapContents = false;
            // 
            // contentresult_label
            // 
            contentresult_label.AutoSize = true;
            contentresult_label.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            contentresult_label.ForeColor = Color.White;
            contentresult_label.Location = new Point(3, 0);
            contentresult_label.Name = "contentresult_label";
            contentresult_label.Size = new Size(94, 19);
            contentresult_label.TabIndex = 0;
            contentresult_label.Text = "<CONTENT>";
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(storedRuleWarning_flp, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 455);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Size = new Size(635, 108);
            tableLayoutPanel4.TabIndex = 0;
            // 
            // storedRuleWarning_flp
            // 
            storedRuleWarning_flp.AutoScroll = true;
            storedRuleWarning_flp.BackColor = Color.OliveDrab;
            storedRuleWarning_flp.Dock = DockStyle.Fill;
            storedRuleWarning_flp.FlowDirection = FlowDirection.TopDown;
            storedRuleWarning_flp.Location = new Point(3, 3);
            storedRuleWarning_flp.Name = "storedRuleWarning_flp";
            storedRuleWarning_flp.Size = new Size(311, 102);
            storedRuleWarning_flp.TabIndex = 0;
            storedRuleWarning_flp.WrapContents = false;
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
            tableLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            storeddetailreport_flp.ResumeLayout(false);
            storeddetailreport_flp.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
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
        private Button add_client;
        private FlowLayoutPanel storedclient_flp;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel storeddetailreport_flp;
        private TableLayoutPanel tableLayoutPanel4;
        private FlowLayoutPanel storedRuleWarning_flp;
        private Label contentresult_label;
    }
}