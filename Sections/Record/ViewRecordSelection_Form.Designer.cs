namespace MyWinFormsApp.Sections.Record
{
    partial class ViewRecordSelection_Form
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
            delete_button = new Button();
            button1 = new Button();
            description_label = new Label();
            panel1 = new Panel();
            truck_label = new Label();
            data_label = new Label();
            stored_bundleitemnames_flp = new FlowLayoutPanel();
            stored_client_flp = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // delete_button
            // 
            delete_button.BackColor = Color.FromArgb(192, 0, 0);
            delete_button.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 0);
            delete_button.FlatStyle = FlatStyle.Flat;
            delete_button.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            delete_button.ForeColor = Color.FromArgb(255, 192, 192);
            delete_button.Location = new Point(463, 198);
            delete_button.Margin = new Padding(0);
            delete_button.Name = "delete_button";
            delete_button.Size = new Size(75, 20);
            delete_button.TabIndex = 4;
            delete_button.Text = "DELETE";
            delete_button.UseVisualStyleBackColor = false;
            delete_button.Click += delete_button_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.FromArgb(64, 0, 0);
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            button1.ForeColor = Color.FromArgb(64, 64, 64);
            button1.Location = new Point(463, 178);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(75, 20);
            button1.TabIndex = 5;
            button1.Text = "FULL VIEW";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.Location = new Point(13, 0);
            description_label.Name = "description_label";
            description_label.Size = new Size(95, 15);
            description_label.TabIndex = 6;
            description_label.Text = "<DESCRIPTION>";
            // 
            // panel1
            // 
            panel1.Controls.Add(description_label);
            panel1.Location = new Point(24, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(422, 70);
            panel1.TabIndex = 7;
            // 
            // truck_label
            // 
            truck_label.AutoSize = true;
            truck_label.Location = new Point(12, 9);
            truck_label.Name = "truck_label";
            truck_label.Size = new Size(103, 15);
            truck_label.TabIndex = 8;
            truck_label.Text = "<PLATENUMBER>";
            // 
            // data_label
            // 
            data_label.AutoSize = true;
            data_label.Location = new Point(488, 9);
            data_label.Name = "data_label";
            data_label.RightToLeft = RightToLeft.Yes;
            data_label.Size = new Size(50, 15);
            data_label.TabIndex = 9;
            data_label.Text = "<DATE>";
            // 
            // stored_bundleitemnames_flp
            // 
            stored_bundleitemnames_flp.Location = new Point(24, 98);
            stored_bundleitemnames_flp.Name = "stored_bundleitemnames_flp";
            stored_bundleitemnames_flp.Size = new Size(219, 100);
            stored_bundleitemnames_flp.TabIndex = 10;
            // 
            // stored_client_flp
            // 
            stored_client_flp.Location = new Point(240, 98);
            stored_client_flp.Name = "stored_client_flp";
            stored_client_flp.Size = new Size(206, 100);
            stored_client_flp.TabIndex = 11;
            // 
            // ViewRecordSelection_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(537, 218);
            Controls.Add(stored_client_flp);
            Controls.Add(stored_bundleitemnames_flp);
            Controls.Add(data_label);
            Controls.Add(truck_label);
            Controls.Add(panel1);
            Controls.Add(button1);
            Controls.Add(delete_button);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ViewRecordSelection_Form";
            Text = "ViewRecordSelection_Form";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button delete_button;
        private Button button1;
        private Label description_label;
        private Panel panel1;
        private Label truck_label;
        private Label data_label;
        private FlowLayoutPanel stored_bundleitemnames_flp;
        private FlowLayoutPanel stored_client_flp;
    }
}