namespace MyWinFormsApp.Sections.ManageBundles
{
    partial class viewSelectedBundle_Form
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
            itemname_label = new Label();
            content_label = new Label();
            flutetype_label = new Label();
            delete_btn = new Button();
            edit_btn = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            client_label = new Label();
            panel3 = new Panel();
            id_label = new Label();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // itemname_label
            // 
            itemname_label.AutoSize = true;
            itemname_label.BackColor = Color.Transparent;
            itemname_label.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            itemname_label.Location = new Point(9, 9);
            itemname_label.Name = "itemname_label";
            itemname_label.Size = new Size(236, 25);
            itemname_label.TabIndex = 2;
            itemname_label.Text = "<ITEM_NAME>(BUNDLE)";
            // 
            // content_label
            // 
            content_label.AutoSize = true;
            content_label.Dock = DockStyle.Fill;
            content_label.Font = new Font("Segoe UI", 12F);
            content_label.ForeColor = Color.FromArgb(64, 64, 64);
            content_label.Location = new Point(50, 0);
            content_label.Margin = new Padding(20, 0, 3, 0);
            content_label.Name = "content_label";
            content_label.Size = new Size(126, 84);
            content_label.TabIndex = 3;
            content_label.Text = "Length (mm):\r\nWidth (mm) :\r\nHeight(mm) :\r\nDimension(mm):";
            // 
            // flutetype_label
            // 
            flutetype_label.AutoSize = true;
            flutetype_label.BackColor = Color.Transparent;
            flutetype_label.Dock = DockStyle.Right;
            flutetype_label.Font = new Font("Segoe UI", 12F);
            flutetype_label.ImageAlign = ContentAlignment.MiddleRight;
            flutetype_label.Location = new Point(141, 0);
            flutetype_label.Margin = new Padding(0);
            flutetype_label.Name = "flutetype_label";
            flutetype_label.Padding = new Padding(0, 5, 0, 0);
            flutetype_label.Size = new Size(83, 26);
            flutetype_label.TabIndex = 4;
            flutetype_label.Text = "FluteType: \r\n";
            // 
            // delete_btn
            // 
            delete_btn.BackColor = Color.FromArgb(192, 0, 0);
            delete_btn.FlatStyle = FlatStyle.Flat;
            delete_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            delete_btn.ForeColor = Color.FromArgb(255, 192, 192);
            delete_btn.Location = new Point(732, 155);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(108, 21);
            delete_btn.TabIndex = 5;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = false;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.FlatStyle = FlatStyle.Flat;
            edit_btn.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            edit_btn.Location = new Point(732, 134);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(108, 21);
            edit_btn.TabIndex = 6;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(flutetype_label);
            panel1.Location = new Point(616, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(224, 30);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(content_label);
            panel2.Location = new Point(34, 62);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(50, 0, 0, 0);
            panel2.Size = new Size(557, 112);
            panel2.TabIndex = 8;
            // 
            // client_label
            // 
            client_label.AutoSize = true;
            client_label.BackColor = Color.Transparent;
            client_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            client_label.ForeColor = Color.FromArgb(64, 64, 64);
            client_label.Location = new Point(51, 30);
            client_label.Name = "client_label";
            client_label.Size = new Size(86, 21);
            client_label.TabIndex = 9;
            client_label.Text = "<CLIENT>";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Location = new Point(-2, 175);
            panel3.Name = "panel3";
            panel3.Size = new Size(923, 11);
            panel3.TabIndex = 10;
            // 
            // id_label
            // 
            id_label.AutoSize = true;
            id_label.Dock = DockStyle.Right;
            id_label.Font = new Font("Segoe UI", 25F);
            id_label.Location = new Point(84, 0);
            id_label.Name = "id_label";
            id_label.Size = new Size(140, 46);
            id_label.TabIndex = 11;
            id_label.Text = "ID:####";
            // 
            // panel4
            // 
            panel4.Controls.Add(id_label);
            panel4.Location = new Point(616, 37);
            panel4.Name = "panel4";
            panel4.Size = new Size(224, 43);
            panel4.TabIndex = 12;
            // 
            // viewSelectedBundle_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 186);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(client_label);
            Controls.Add(panel1);
            Controls.Add(edit_btn);
            Controls.Add(delete_btn);
            Controls.Add(itemname_label);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "viewSelectedBundle_Form";
            Text = "viewSelectedBundle_Form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label itemname_label;
        private Label content_label;
        private Label flutetype_label;
        private Button delete_btn;
        private Button edit_btn;
        private Panel panel1;
        private Panel panel2;
        private Label client_label;
        private Panel panel3;
        private Label id_label;
        private Panel panel4;
    }
}