namespace MyWinFormsApp.Sections.ManageClient
{
    partial class ExistingSelectClient_form
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
            description_label = new Label();
            clientname_label = new Label();
            conditioncontainer_flp = new FlowLayoutPanel();
            delete_btn = new Button();
            edit_btn = new Button();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.Controls.Add(description_label, 0, 1);
            tableLayoutPanel1.Controls.Add(clientname_label, 0, 0);
            tableLayoutPanel1.Controls.Add(conditioncontainer_flp, 0, 2);
            tableLayoutPanel1.Controls.Add(delete_btn, 1, 3);
            tableLayoutPanel1.Controls.Add(edit_btn, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(15);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.Size = new Size(1030, 170);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.Dock = DockStyle.Fill;
            description_label.Font = new Font("Segoe UI", 10F);
            description_label.Location = new Point(65, 45);
            description_label.Margin = new Padding(50, 0, 200, 0);
            description_label.Name = "description_label";
            description_label.Size = new Size(600, 50);
            description_label.TabIndex = 1;
            description_label.Text = "<DESCRIPTION>";
            // 
            // clientname_label
            // 
            clientname_label.AutoSize = true;
            clientname_label.Font = new Font("Segoe UI", 12F);
            clientname_label.Location = new Point(18, 15);
            clientname_label.Name = "clientname_label";
            clientname_label.Size = new Size(133, 21);
            clientname_label.TabIndex = 0;
            clientname_label.Text = "<CLIENT_NAME>";
            // 
            // conditioncontainer_flp
            // 
            conditioncontainer_flp.AutoScroll = true;
            conditioncontainer_flp.Dock = DockStyle.Fill;
            conditioncontainer_flp.FlowDirection = FlowDirection.TopDown;
            conditioncontainer_flp.Location = new Point(65, 98);
            conditioncontainer_flp.Margin = new Padding(50, 3, 200, 3);
            conditioncontainer_flp.Name = "conditioncontainer_flp";
            conditioncontainer_flp.Size = new Size(600, 24);
            conditioncontainer_flp.TabIndex = 2;
            conditioncontainer_flp.WrapContents = false;
            // 
            // delete_btn
            // 
            delete_btn.Dock = DockStyle.Fill;
            delete_btn.Location = new Point(868, 128);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(144, 24);
            delete_btn.TabIndex = 3;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.Dock = DockStyle.Bottom;
            edit_btn.Location = new Point(868, 98);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(144, 24);
            edit_btn.TabIndex = 4;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // ExistingSelectClient_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1030, 170);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ExistingSelectClient_form";
            Text = "ExistingSelectClient_form";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label clientname_label;
        private Label description_label;
        private FlowLayoutPanel conditioncontainer_flp;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button delete_btn;
        private Button edit_btn;
    }
}