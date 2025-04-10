namespace MyWinFormsApp.Sections.ManageItems.Flute
{
    partial class ManageFlute_WindowPopupForm
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
            add_btn = new Button();
            flutecontainer_flp = new FlowLayoutPanel();
            button1 = new Button();
            SuspendLayout();
            // 
            // add_btn
            // 
            add_btn.Location = new Point(4, 7);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(114, 44);
            add_btn.TabIndex = 0;
            add_btn.Text = "ADD NEW FLUTE";
            add_btn.UseVisualStyleBackColor = true;
            add_btn.Click += add_btn_Click;
            // 
            // flutecontainer_flp
            // 
            flutecontainer_flp.AutoScroll = true;
            flutecontainer_flp.BackColor = Color.FromArgb(224, 224, 224);
            flutecontainer_flp.FlowDirection = FlowDirection.TopDown;
            flutecontainer_flp.Location = new Point(122, 7);
            flutecontainer_flp.Margin = new Padding(0);
            flutecontainer_flp.Name = "flutecontainer_flp";
            flutecontainer_flp.Size = new Size(754, 487);
            flutecontainer_flp.TabIndex = 1;
            flutecontainer_flp.WrapContents = false;
            // 
            // button1
            // 
            button1.Location = new Point(4, 57);
            button1.Name = "button1";
            button1.Size = new Size(114, 44);
            button1.TabIndex = 2;
            button1.Text = "CLOSE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ManageFlute_WindowPopupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 503);
            Controls.Add(button1);
            Controls.Add(flutecontainer_flp);
            Controls.Add(add_btn);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ManageFlute_WindowPopupForm";
            Text = "MANAGE FLUTE";
            ResumeLayout(false);
        }

        #endregion

        private Button add_btn;
        private FlowLayoutPanel flutecontainer_flp;
        private Button button1;
    }
}