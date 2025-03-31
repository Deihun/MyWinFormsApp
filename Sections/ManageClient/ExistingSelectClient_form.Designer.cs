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
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            delete_btn = new Button();
            edit_btn = new Button();
            clientname_label = new Label();
            panel1 = new Panel();
            description_label = new Label();
            conditioncontainer_flp = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            stored_itemname_flp = new FlowLayoutPanel();
            panel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.FromArgb(192, 0, 0);
            delete_btn.FlatStyle = FlatStyle.Flat;
            delete_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            delete_btn.ForeColor = Color.FromArgb(255, 192, 192);
            delete_btn.Location = new Point(0, 204);
            delete_btn.Margin = new Padding(0);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(92, 22);
            delete_btn.TabIndex = 2;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.FlatStyle = FlatStyle.Flat;
            edit_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            edit_btn.Location = new Point(0, 184);
            edit_btn.Margin = new Padding(0);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(92, 20);
            edit_btn.TabIndex = 3;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // clientname_label
            // 
            clientname_label.AutoSize = true;
            clientname_label.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            clientname_label.Location = new Point(19, 6);
            clientname_label.Name = "clientname_label";
            clientname_label.Size = new Size(153, 28);
            clientname_label.TabIndex = 4;
            clientname_label.Text = "<client_name>";
            clientname_label.Click += clientname_label_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(description_label);
            panel1.Location = new Point(60, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 82);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.Dock = DockStyle.Fill;
            description_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            description_label.ForeColor = Color.FromArgb(64, 64, 64);
            description_label.Location = new Point(0, 0);
            description_label.Name = "description_label";
            description_label.Size = new Size(138, 25);
            description_label.TabIndex = 5;
            description_label.Text = "<description>";
            // 
            // conditioncontainer_flp
            // 
            conditioncontainer_flp.AutoScroll = true;
            conditioncontainer_flp.BackColor = Color.White;
            conditioncontainer_flp.FlowDirection = FlowDirection.TopDown;
            conditioncontainer_flp.Location = new Point(403, 124);
            conditioncontainer_flp.Name = "conditioncontainer_flp";
            conditioncontainer_flp.Size = new Size(342, 90);
            conditioncontainer_flp.TabIndex = 6;
            conditioncontainer_flp.WrapContents = false;
            conditioncontainer_flp.Paint += conditioncontainer_flp_Paint;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(delete_btn);
            flowLayoutPanel2.Controls.Add(edit_btn);
            flowLayoutPanel2.Dock = DockStyle.Right;
            flowLayoutPanel2.FlowDirection = FlowDirection.BottomUp;
            flowLayoutPanel2.Location = new Point(751, 0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(89, 226);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // stored_itemname_flp
            // 
            stored_itemname_flp.AutoScroll = true;
            stored_itemname_flp.BackColor = Color.White;
            stored_itemname_flp.FlowDirection = FlowDirection.TopDown;
            stored_itemname_flp.Location = new Point(60, 124);
            stored_itemname_flp.Name = "stored_itemname_flp";
            stored_itemname_flp.Size = new Size(337, 90);
            stored_itemname_flp.TabIndex = 8;
            stored_itemname_flp.WrapContents = false;
            // 
            // ExistingSelectClient_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 226);
            Controls.Add(stored_itemname_flp);
            Controls.Add(conditioncontainer_flp);
            Controls.Add(panel1);
            Controls.Add(clientname_label);
            Controls.Add(flowLayoutPanel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ExistingSelectClient_form";
            Text = "ExistingSelectClient_form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Button delete_btn;
        private Button edit_btn;
        private Label clientname_label;
        private Panel panel1;
        private Label description_label;
        private FlowLayoutPanel conditioncontainer_flp;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel stored_itemname_flp;
    }
}