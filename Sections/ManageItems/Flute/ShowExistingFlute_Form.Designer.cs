namespace MyWinFormsApp.Sections.ManageItems.Flute
{
    partial class ShowExistingFlute_Form
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
            flutetype_label = new Label();
            content_label = new Label();
            delete_btn = new Button();
            edit_btn = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Location = new Point(0, 190);
            panel1.Name = "panel1";
            panel1.Size = new Size(755, 12);
            panel1.TabIndex = 0;
            // 
            // flutetype_label
            // 
            flutetype_label.AutoSize = true;
            flutetype_label.Font = new Font("Segoe UI", 15F);
            flutetype_label.Location = new Point(25, 9);
            flutetype_label.Name = "flutetype_label";
            flutetype_label.Size = new Size(143, 28);
            flutetype_label.TabIndex = 1;
            flutetype_label.Text = "<FLUTE_TYPE>";
            // 
            // content_label
            // 
            content_label.AutoSize = true;
            content_label.Font = new Font("Segoe UI", 12F);
            content_label.Location = new Point(114, 52);
            content_label.Name = "content_label";
            content_label.Size = new Size(161, 63);
            content_label.TabIndex = 2;
            content_label.Text = "Standard (mm) : XXXX\r\nTarget (mm):      XXXX\r\nTolerance (mm):XXXX\r\n";
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(581, 146);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(95, 41);
            delete_btn.TabIndex = 3;
            delete_btn.Text = "DELETE";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // edit_btn
            // 
            edit_btn.Location = new Point(581, 99);
            edit_btn.Name = "edit_btn";
            edit_btn.Size = new Size(95, 41);
            edit_btn.TabIndex = 4;
            edit_btn.Text = "EDIT";
            edit_btn.UseVisualStyleBackColor = true;
            edit_btn.Click += edit_btn_Click;
            // 
            // ShowExistingFlute_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(680, 200);
            Controls.Add(edit_btn);
            Controls.Add(delete_btn);
            Controls.Add(content_label);
            Controls.Add(flutetype_label);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ShowExistingFlute_Form";
            Text = "ShowExistingFlute_Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label flutetype_label;
        private Label content_label;
        private Button delete_btn;
        private Button edit_btn;
    }
}