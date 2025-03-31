namespace MyWinFormsApp.SupportClass
{
    partial class PageSelection
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            back_btn = new Button();
            next_btn = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(back_btn);
            flowLayoutPanel1.Controls.Add(next_btn);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(5);
            flowLayoutPanel1.Size = new Size(1077, 43);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // back_btn
            // 
            back_btn.BackColor = Color.White;
            back_btn.FlatStyle = FlatStyle.Flat;
            back_btn.Font = new Font("Segoe UI", 10F);
            back_btn.Location = new Point(8, 8);
            back_btn.Name = "back_btn";
            back_btn.Size = new Size(75, 26);
            back_btn.TabIndex = 1;
            back_btn.Text = "BACK";
            back_btn.TextAlign = ContentAlignment.TopCenter;
            back_btn.UseVisualStyleBackColor = false;
            back_btn.Click += back_btn_Click;
            // 
            // next_btn
            // 
            next_btn.BackColor = Color.White;
            next_btn.FlatStyle = FlatStyle.Flat;
            next_btn.Font = new Font("Segoe UI", 10F);
            next_btn.Location = new Point(89, 8);
            next_btn.Margin = new Padding(3, 3, 90, 3);
            next_btn.Name = "next_btn";
            next_btn.Size = new Size(75, 26);
            next_btn.TabIndex = 0;
            next_btn.Text = "NEXT";
            next_btn.TextAlign = ContentAlignment.TopCenter;
            next_btn.UseVisualStyleBackColor = false;
            next_btn.Click += next_btn_Click;
            // 
            // PageSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(flowLayoutPanel1);
            Name = "PageSelection";
            Size = new Size(1077, 43);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button back_btn;
        private Button next_btn;
    }
}
