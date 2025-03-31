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
            description_label = new Label();
            storedfilter_flp = new FlowLayoutPanel();
            clientname_label = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // description_label
            // 
            description_label.AutoSize = true;
            description_label.ForeColor = Color.DimGray;
            description_label.Location = new Point(3, 21);
            description_label.Name = "description_label";
            description_label.Size = new Size(83, 15);
            description_label.TabIndex = 1;
            description_label.Text = "<Description>";
            // 
            // storedfilter_flp
            // 
            storedfilter_flp.AutoScroll = true;
            storedfilter_flp.Location = new Point(12, 102);
            storedfilter_flp.Name = "storedfilter_flp";
            storedfilter_flp.Size = new Size(243, 62);
            storedfilter_flp.TabIndex = 3;
            storedfilter_flp.WrapContents = false;
            // 
            // clientname_label
            // 
            clientname_label.AutoSize = true;
            clientname_label.Font = new Font("Segoe UI", 12F);
            clientname_label.ForeColor = Color.FromArgb(64, 64, 64);
            clientname_label.Location = new Point(3, 0);
            clientname_label.Name = "clientname_label";
            clientname_label.Size = new Size(133, 21);
            clientname_label.TabIndex = 5;
            clientname_label.Text = "<CLIENT_NAME>";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(clientname_label);
            flowLayoutPanel1.Controls.Add(description_label);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 6);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(243, 90);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.WrapContents = false;
            // 
            // clientselectView_form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 181);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(storedfilter_flp);
            FormBorderStyle = FormBorderStyle.None;
            Name = "clientselectView_form";
            Text = "clientselectView_form";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label description_label;
        private FlowLayoutPanel storedfilter_flp;
        private Label clientname_label;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}