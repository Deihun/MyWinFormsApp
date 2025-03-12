namespace MyWinFormsApp;

partial class main_startup_form
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tableLayoutPanel_main = new TableLayoutPanel();
        flowLayoutPanel_dashboard = new FlowLayoutPanel();
        estimation_dashboard_btn = new Button();
        viewrecords_dashboard_btn = new Button();
        manageitems_dashboard_btn = new Button();
        managebundle_dashboard_btn = new Button();
        manageclient_dashboard_btn = new Button();
        managepallet_dashboard_btn = new Button();
        managetruck_dashboard_btn = new Button();
        exit_dashboard_btn = new Button();
        workpanel = new Panel();
        tableLayoutPanel_main.SuspendLayout();
        flowLayoutPanel_dashboard.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel_main
        // 
        tableLayoutPanel_main.BackColor = Color.PaleGreen;
        tableLayoutPanel_main.ColumnCount = 2;
        tableLayoutPanel_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
        tableLayoutPanel_main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85F));
        tableLayoutPanel_main.Controls.Add(flowLayoutPanel_dashboard, 0, 0);
        tableLayoutPanel_main.Controls.Add(workpanel, 1, 0);
        tableLayoutPanel_main.Dock = DockStyle.Fill;
        tableLayoutPanel_main.Location = new Point(0, 0);
        tableLayoutPanel_main.Margin = new Padding(0);
        tableLayoutPanel_main.Name = "tableLayoutPanel_main";
        tableLayoutPanel_main.RowCount = 1;
        tableLayoutPanel_main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tableLayoutPanel_main.Size = new Size(1604, 881);
        tableLayoutPanel_main.TabIndex = 0;
        // 
        // flowLayoutPanel_dashboard
        // 
        flowLayoutPanel_dashboard.BackColor = Color.SeaGreen;
        flowLayoutPanel_dashboard.Controls.Add(estimation_dashboard_btn);
        flowLayoutPanel_dashboard.Controls.Add(viewrecords_dashboard_btn);
        flowLayoutPanel_dashboard.Controls.Add(manageitems_dashboard_btn);
        flowLayoutPanel_dashboard.Controls.Add(managebundle_dashboard_btn);
        flowLayoutPanel_dashboard.Controls.Add(manageclient_dashboard_btn);
        flowLayoutPanel_dashboard.Controls.Add(managepallet_dashboard_btn);
        flowLayoutPanel_dashboard.Controls.Add(managetruck_dashboard_btn);
        flowLayoutPanel_dashboard.Controls.Add(exit_dashboard_btn);
        flowLayoutPanel_dashboard.Dock = DockStyle.Fill;
        flowLayoutPanel_dashboard.Location = new Point(0, 0);
        flowLayoutPanel_dashboard.Margin = new Padding(0);
        flowLayoutPanel_dashboard.Name = "flowLayoutPanel_dashboard";
        flowLayoutPanel_dashboard.Size = new Size(240, 881);
        flowLayoutPanel_dashboard.TabIndex = 0;
        // 
        // estimation_dashboard_btn
        // 
        estimation_dashboard_btn.BackColor = Color.SeaGreen;
        estimation_dashboard_btn.FlatAppearance.BorderSize = 0;
        estimation_dashboard_btn.FlatStyle = FlatStyle.Flat;
        estimation_dashboard_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        estimation_dashboard_btn.ForeColor = Color.White;
        estimation_dashboard_btn.Location = new Point(3, 3);
        estimation_dashboard_btn.Name = "estimation_dashboard_btn";
        estimation_dashboard_btn.Size = new Size(234, 51);
        estimation_dashboard_btn.TabIndex = 0;
        estimation_dashboard_btn.Text = "ESTIMATE";
        estimation_dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
        estimation_dashboard_btn.UseVisualStyleBackColor = false;
        estimation_dashboard_btn.Click += estimation_dashboard_btn_Click;
        // 
        // viewrecords_dashboard_btn
        // 
        viewrecords_dashboard_btn.BackColor = Color.SeaGreen;
        viewrecords_dashboard_btn.FlatAppearance.BorderSize = 0;
        viewrecords_dashboard_btn.FlatStyle = FlatStyle.Flat;
        viewrecords_dashboard_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        viewrecords_dashboard_btn.ForeColor = Color.White;
        viewrecords_dashboard_btn.Location = new Point(3, 60);
        viewrecords_dashboard_btn.Name = "viewrecords_dashboard_btn";
        viewrecords_dashboard_btn.Size = new Size(234, 51);
        viewrecords_dashboard_btn.TabIndex = 1;
        viewrecords_dashboard_btn.Text = "VIEW RECORDS";
        viewrecords_dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
        viewrecords_dashboard_btn.UseVisualStyleBackColor = false;
        viewrecords_dashboard_btn.Click += viewrecords_dashboard_btn_Click;
        // 
        // manageitems_dashboard_btn
        // 
        manageitems_dashboard_btn.BackColor = Color.SeaGreen;
        manageitems_dashboard_btn.FlatAppearance.BorderSize = 0;
        manageitems_dashboard_btn.FlatStyle = FlatStyle.Flat;
        manageitems_dashboard_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        manageitems_dashboard_btn.ForeColor = Color.White;
        manageitems_dashboard_btn.Location = new Point(3, 117);
        manageitems_dashboard_btn.Name = "manageitems_dashboard_btn";
        manageitems_dashboard_btn.Size = new Size(234, 51);
        manageitems_dashboard_btn.TabIndex = 2;
        manageitems_dashboard_btn.Text = "MANAGE ITEMS";
        manageitems_dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
        manageitems_dashboard_btn.UseVisualStyleBackColor = false;
        manageitems_dashboard_btn.Click += manageitems_dashboard_btn_Click;
        // 
        // managebundle_dashboard_btn
        // 
        managebundle_dashboard_btn.BackColor = Color.SeaGreen;
        managebundle_dashboard_btn.FlatAppearance.BorderSize = 0;
        managebundle_dashboard_btn.FlatStyle = FlatStyle.Flat;
        managebundle_dashboard_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        managebundle_dashboard_btn.ForeColor = Color.White;
        managebundle_dashboard_btn.Location = new Point(3, 174);
        managebundle_dashboard_btn.Name = "managebundle_dashboard_btn";
        managebundle_dashboard_btn.Size = new Size(234, 51);
        managebundle_dashboard_btn.TabIndex = 3;
        managebundle_dashboard_btn.Text = "MANAGE BUNDLES";
        managebundle_dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
        managebundle_dashboard_btn.UseVisualStyleBackColor = false;
        managebundle_dashboard_btn.Click += managebundle_dashboard_btn_Click;
        // 
        // manageclient_dashboard_btn
        // 
        manageclient_dashboard_btn.BackColor = Color.SeaGreen;
        manageclient_dashboard_btn.FlatAppearance.BorderSize = 0;
        manageclient_dashboard_btn.FlatStyle = FlatStyle.Flat;
        manageclient_dashboard_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        manageclient_dashboard_btn.ForeColor = Color.White;
        manageclient_dashboard_btn.Location = new Point(3, 231);
        manageclient_dashboard_btn.Name = "manageclient_dashboard_btn";
        manageclient_dashboard_btn.Size = new Size(234, 51);
        manageclient_dashboard_btn.TabIndex = 4;
        manageclient_dashboard_btn.Text = "MANAGE CLIENT";
        manageclient_dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
        manageclient_dashboard_btn.UseVisualStyleBackColor = false;
        manageclient_dashboard_btn.Click += manageclient_dashboard_btn_Click;
        // 
        // managepallet_dashboard_btn
        // 
        managepallet_dashboard_btn.BackColor = Color.SeaGreen;
        managepallet_dashboard_btn.FlatAppearance.BorderSize = 0;
        managepallet_dashboard_btn.FlatStyle = FlatStyle.Flat;
        managepallet_dashboard_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        managepallet_dashboard_btn.ForeColor = Color.White;
        managepallet_dashboard_btn.Location = new Point(3, 288);
        managepallet_dashboard_btn.Name = "managepallet_dashboard_btn";
        managepallet_dashboard_btn.Size = new Size(234, 51);
        managepallet_dashboard_btn.TabIndex = 5;
        managepallet_dashboard_btn.Text = "MANAGE PALLET";
        managepallet_dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
        managepallet_dashboard_btn.UseVisualStyleBackColor = false;
        managepallet_dashboard_btn.Click += managepallet_dashboard_btn_Click;
        // 
        // managetruck_dashboard_btn
        // 
        managetruck_dashboard_btn.BackColor = Color.SeaGreen;
        managetruck_dashboard_btn.FlatAppearance.BorderSize = 0;
        managetruck_dashboard_btn.FlatStyle = FlatStyle.Flat;
        managetruck_dashboard_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        managetruck_dashboard_btn.ForeColor = Color.White;
        managetruck_dashboard_btn.Location = new Point(3, 345);
        managetruck_dashboard_btn.Name = "managetruck_dashboard_btn";
        managetruck_dashboard_btn.Size = new Size(234, 51);
        managetruck_dashboard_btn.TabIndex = 6;
        managetruck_dashboard_btn.Text = "MANAGE TRUCK";
        managetruck_dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
        managetruck_dashboard_btn.UseVisualStyleBackColor = false;
        managetruck_dashboard_btn.Click += managetruck_dashboard_btn_Click;
        // 
        // exit_dashboard_btn
        // 
        exit_dashboard_btn.BackColor = Color.SeaGreen;
        exit_dashboard_btn.FlatAppearance.BorderSize = 0;
        exit_dashboard_btn.FlatStyle = FlatStyle.Flat;
        exit_dashboard_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        exit_dashboard_btn.ForeColor = Color.White;
        exit_dashboard_btn.Location = new Point(3, 402);
        exit_dashboard_btn.Name = "exit_dashboard_btn";
        exit_dashboard_btn.Size = new Size(234, 51);
        exit_dashboard_btn.TabIndex = 7;
        exit_dashboard_btn.Text = "EXIT";
        exit_dashboard_btn.TextAlign = ContentAlignment.MiddleLeft;
        exit_dashboard_btn.UseVisualStyleBackColor = false;
        exit_dashboard_btn.Click += exit_dashboard_btn_Click;
        // 
        // workpanel
        // 
        workpanel.Dock = DockStyle.Fill;
        workpanel.Location = new Point(240, 0);
        workpanel.Margin = new Padding(0);
        workpanel.Name = "workpanel";
        workpanel.Size = new Size(1364, 881);
        workpanel.TabIndex = 1;
        // 
        // main_startup_form
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1604, 881);
        Controls.Add(tableLayoutPanel_main);
        FormBorderStyle = FormBorderStyle.None;
        Name = "main_startup_form";
        Text = "Record";
        WindowState = FormWindowState.Maximized;
        tableLayoutPanel_main.ResumeLayout(false);
        flowLayoutPanel_dashboard.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tableLayoutPanel_main;
    private FlowLayoutPanel flowLayoutPanel_dashboard;
    private Panel workpanel;
    private Button estimation_dashboard_btn;
    private Button viewrecords_dashboard_btn;
    private Button manageitems_dashboard_btn;
    private Button managebundle_dashboard_btn;
    private Button manageclient_dashboard_btn;
    private Button managepallet_dashboard_btn;
    private Button managetruck_dashboard_btn;
    private Button exit_dashboard_btn;
}
