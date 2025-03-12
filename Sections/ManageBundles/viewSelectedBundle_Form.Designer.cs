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
            panel1 = new Panel();
            panel2 = new Panel();
            itemname_label = new Label();
            content_label = new Label();
            flutetype_label = new Label();
            delete_btn = new Button();
            edit_btn = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonShadow;
            panel1.Location = new Point(-9, 217);
            panel1.Name = "panel1";
            panel1.Size = new Size(905, 14);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Location = new Point(-4, -7);
            panel2.Name = "panel2";
            panel2.Size = new Size(905, 14);
            panel2.TabIndex = 1;
            // 
            // itemname_label
            // 
            itemname_label.AutoSize = true;
            itemname_label.Font = new Font("Segoe UI", 12F);
            itemname_label.Location = new Point(12, 10);
            itemname_label.Name = "itemname_label";
            itemname_label.Size = new Size(186, 21);
            itemname_label.TabIndex = 2;
            itemname_label.Text = "<ITEM_NAME>(BUNDLE)";
            // 
            // content_label
            // 
            content_label.AutoSize = true;
            content_label.Font = new Font("Segoe UI", 12F);
            content_label.Location = new Point(135, 59);
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
            flutetype_label.Location = new Point(754, 0);
            flutetype_label.Margin = new Padding(0);
            flutetype_label.Name = "flutetype_label";
            flutetype_label.Padding = new Padding(0, 5, 0, 0);
            flutetype_label.Size = new Size(83, 26);
            flutetype_label.TabIndex = 4;
            flutetype_label.Text = "FluteType: \r\n";
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(729, 177);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(108, 37);
            delete_btn.TabIndex = 5;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.Location = new Point(729, 137);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(108, 37);
            edit_btn.TabIndex = 6;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // viewSelectedBundle_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 226);
            Controls.Add(edit_btn);
            Controls.Add(delete_btn);
            Controls.Add(panel2);
            Controls.Add(flutetype_label);
            Controls.Add(content_label);
            Controls.Add(itemname_label);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "viewSelectedBundle_Form";
            Text = "viewSelectedBundle_Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label itemname_label;
        private Label content_label;
        private Label flutetype_label;
        private Button delete_btn;
        private Button edit_btn;
    }
}