namespace TruckEstimation.Sections.ManageBundles
{
    partial class SelectItem_FromBundle_Form
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
            Search_TB = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            flp = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // Search_TB
            // 
            Search_TB.Location = new Point(52, 15);
            Search_TB.Name = "Search_TB";
            Search_TB.Size = new Size(274, 23);
            Search_TB.TabIndex = 0;
            Search_TB.TextChanged += Search_TB_TextChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(Search_TB);
            groupBox1.Location = new Point(5, -3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(332, 47);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 1;
            label1.Text = "Search:";
            // 
            // flp
            // 
            flp.Location = new Point(5, 50);
            flp.Name = "flp";
            flp.Size = new Size(332, 392);
            flp.TabIndex = 2;
            // 
            // SelectItem_FromBundle_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(342, 446);
            Controls.Add(flp);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "SelectItem_FromBundle_Form";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox Search_TB;
        private GroupBox groupBox1;
        private Label label1;
        private FlowLayoutPanel flp;
    }
}