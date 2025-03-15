namespace MyWinFormsApp.Sections.Estimate
{
    partial class clientselectView_form
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
            client_combobox = new ComboBox();
            description_label = new Label();
            panel1 = new Panel();
            storedfilter_flp = new FlowLayoutPanel();
            delete_button = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // client_combobox
            // 
            client_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            client_combobox.FormattingEnabled = true;
            client_combobox.Location = new Point(12, 12);
            client_combobox.Name = "client_combobox";
            client_combobox.Size = new Size(243, 23);
            client_combobox.TabIndex = 0;
            client_combobox.SelectedIndexChanged += client_combobox_SelectedIndexChanged;
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.Dock = DockStyle.Fill;
            description_label.Location = new Point(0, 0);
            description_label.Name = "description_label";
            description_label.Size = new Size(83, 15);
            description_label.TabIndex = 1;
            description_label.Text = "<Description>";
            // 
            // panel1
            // 
            panel1.Controls.Add(description_label);
            panel1.Location = new Point(12, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(243, 71);
            panel1.TabIndex = 2;
            // 
            // storedfilter_flp
            // 
            storedfilter_flp.Location = new Point(12, 114);
            storedfilter_flp.Name = "storedfilter_flp";
            storedfilter_flp.Size = new Size(243, 117);
            storedfilter_flp.TabIndex = 3;
            // 
            // delete_button
            // 
            delete_button.BackColor = Color.FromArgb(192, 0, 0);
            delete_button.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 0);
            delete_button.FlatStyle = FlatStyle.Flat;
            delete_button.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            delete_button.ForeColor = Color.FromArgb(255, 192, 192);
            delete_button.Location = new Point(194, 234);
            delete_button.Margin = new Padding(0);
            delete_button.Name = "delete_button";
            delete_button.Size = new Size(75, 20);
            delete_button.TabIndex = 4;
            delete_button.Text = "DELETE";
            delete_button.UseVisualStyleBackColor = false;
            delete_button.Click += delete_button_Click;
            // 
            // clientselectView_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 254);
            Controls.Add(delete_button);
            Controls.Add(storedfilter_flp);
            Controls.Add(panel1);
            Controls.Add(client_combobox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "clientselectView_form";
            Text = "clientselectView_form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox client_combobox;
        private Label description_label;
        private Panel panel1;
        private FlowLayoutPanel storedfilter_flp;
        private Button delete_button;
    }
}