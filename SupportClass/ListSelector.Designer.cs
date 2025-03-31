namespace MyWinFormsApp.SupportClass
{
    partial class ListSelector
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
            Input_tb = new TextBox();
            button1 = new Button();
            stored_flp = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // Input_tb
            // 
            Input_tb.ForeColor = Color.DimGray;
            Input_tb.Location = new Point(4, 5);
            Input_tb.Name = "Input_tb";
            Input_tb.Size = new Size(204, 23);
            Input_tb.TabIndex = 0;
            Input_tb.Text = "Enter new category...";
            Input_tb.Enter += Input_tb_Enter;
            Input_tb.Leave += Input_tb_Leave;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(211, 5);
            button1.Name = "button1";
            button1.Size = new Size(104, 23);
            button1.TabIndex = 1;
            button1.Text = "ADD CATEGORY";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // stored_flp
            // 
            stored_flp.AutoScroll = true;
            stored_flp.FlowDirection = FlowDirection.TopDown;
            stored_flp.Location = new Point(4, 34);
            stored_flp.Name = "stored_flp";
            stored_flp.Size = new Size(311, 413);
            stored_flp.TabIndex = 2;
            stored_flp.WrapContents = false;
            // 
            // ListSelector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 450);
            Controls.Add(stored_flp);
            Controls.Add(button1);
            Controls.Add(Input_tb);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ListSelector";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Input_tb;
        private Button button1;
        private FlowLayoutPanel stored_flp;
    }
}