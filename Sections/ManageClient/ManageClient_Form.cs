using COMBINE_CHECKLIST_2024.DateToText;
using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp.Sections.ManageClient
{
    public partial class ManageClient_Form : Form
    {
        private List<ExistingSelectClient_form> list = new List<ExistingSelectClient_form>();
        private List<CheckBox> checkbox_list = new List<CheckBox>();
        private List<FlowLayoutPanel> pages = new List<FlowLayoutPanel>();
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private PageSelection page;

        private const int objects_perPage = 4;
        private int max_count = 0;
        private int selected_page = 1;

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;

        public ManageClient_Form()
        {
            InitializeComponent();

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 50;
            updateTimer.Tick += (s, e) =>
            {
                updateTimer.Stop();
                UpdateVisual();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 50;
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _start_updatePage_Selector();
            };


            TriggerVisualUpdate();
            updatePageSelector();
        }


        //UPDATE VISUAL
        private void SetGradientBackground(string hexColor1, string hexColor2)
        {
            Color color1 = ColorTranslator.FromHtml(hexColor1);
            Color color2 = ColorTranslator.FromHtml(hexColor2);

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, this.Width, this.Height),
                color1,
                color2,
                LinearGradientMode.Vertical)) // Change direction if needed
            {
                g.FillRectangle(brush, 0, 0, this.Width, this.Height);
            }
            this.BackgroundImage = bmp;
        }


        private void _start_updatePage_Selector()
        {
            foreach (Control control in panel2.Controls) control.Dispose();
            panel2.Controls.Clear();
            decimal result = (decimal)max_count / objects_perPage;
            var pages = Convert.ToInt32(Math.Ceiling(result));
            page = new PageSelection(pages, whenPageIsSelected);
            panel2.Controls.Add(page);
            page.Show();
        }


        public void UpdateVisual()
        {
            foreach (FlowLayoutPanel control in pages) control.Dispose();
            pages.Clear();

            List<string> year_data = new List<string>();
            int object_created_count = 0;
            int current_page_now = 0;
            add_page();

            foreach (DataRow row in getRecordTable_ID().Rows)
            {
                var form = create_selectedClient(row);
                pages[current_page_now].Controls.Add(form);
                form.Show();
                object_created_count++;
                Debug.WriteLine($"CurrentObjectNo: {object_created_count}, pageCodeNumber:{current_page_now}, id {row["id"]}");
                if (object_created_count % objects_perPage == 0)
                {
                    current_page_now++;
                }
            }
            max_count = object_created_count;


            Debug.WriteLine($"DEBUG" +
                $"\n number_of_page = {current_page_now}, number_of_object = {max_count}");
            noresult();
            updatePageSelector();
            whenPageIsSelected(0);
        }


        public void updatePageSelector()
        {
            if (pageTimer.Enabled) return;
            pageTimer.Start();
        }


        private void whenPageIsSelected(int page)
        {
            foreach (FlowLayoutPanel flp in pages) flp.Hide();
            try
            {
                Debug.WriteLine($"Changing Page: {page}");
                pages[page].Show();
            }
            catch
            {
                MessageBox.Show("not normal paging detected");
                page = 0;
                pages[page].Show();
            }
        }


        public void resetFilter()
        {
            foreach (Control c in checkbox_list) c.Dispose();
            checkbox_list.Clear();
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                CheckBox checkbox = new CheckBox();
                checkbox.Text = row["category"].ToString();
                checkbox.Tag = row["category"].ToString();
                checkbox.ForeColor = Color.White;
                checkbox.AutoSize = true;
                checkbox.Padding = new Padding(20, 0, 0, 0);
                flowLayoutPanel1.Controls.Add(checkbox);
                checkbox_list.Add(checkbox);
                checkbox.CheckedChanged += checkboxcheck;
                checkbox.Show();
            }
            searchname_tb.Text = "ex. Piattos";
            searchname_tb.ForeColor = Color.Gray;
        }


        public void TriggerVisualUpdate()
        {
            if (updateTimer.Enabled) return;
            updateTimer.Start();
        }




        //OBJECT SETTER
        private ExistingSelectClient_form create_selectedClient(DataRow row)
        {
            ExistingSelectClient_form escf = new ExistingSelectClient_form(
                Convert.ToInt32(row["id"]),
                row["name"].ToString(),
                row["description"].ToString(),
                row["filter"].ToString(),
                row["category"].ToString(),
                this
                );
            escf.TopLevel = false;
            storedarea_flt.Controls.Add(escf);
            escf.Show();
            list.Add(escf);
            return escf;
        }


        private FlowLayoutPanel add_page()
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            pages.Add(flp);
            storedarea_flt.Controls.Add(flp);
            flp.FlowDirection = FlowDirection.TopDown;
            flp.WrapContents = false;
            flp.AutoScroll = true;
            flp.BackColor = TransparencyKey;
            flp.Width = storedarea_flt.Width - 30;
            flp.Height = Height - 100;
            flp.Hide();
            return flp;
        }


        private DataTable getRecordTable_ID()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "\r\nSELECT DISTINCT client.id, client.name, client.description, client.filter, client.category FROM\r\nClient_Table client WHERE is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();
            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piattos")
                conditions.Add($"client.name LIKE '%{searchname_tb.Text}%'");
            foreach (CheckBox checkbox in checkbox_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;

                category.Add($"client.category = '{checkbox.Tag}'");
            }
            if (conditions.Count > 0)
                preset_query += $" AND ({string.Join(" AND ", conditions)})";
            if (category.Count > 0)
                preset_query += $" AND ({string.Join(" OR ", category)})";
            preset_query += $" ORDER BY client.name OFFSET {(objects_perPage * (selected_page - 1))} ROWS FETCH NEXT {objects_perPage} ROWS ONLY;";
            //MessageBox.Show(preset_query);
            DataTable table = sql.ExecuteQuery(preset_query);
            return table;
        }




        //CONTROL EVENTS
        private void add_btn_Click(object sender, EventArgs e)
        {
            AddNewClient_WindowPopupForm ancwpf = new AddNewClient_WindowPopupForm(this);
            ancwpf.ShowDialog();
        }


        private void checkboxcheck(object sender, EventArgs e)
        {
            foreach (CheckBox c in checkbox_list)
            {
                if (sender is CheckBox cb) if (cb == c) continue;
                c.Checked = false;
            }
            updatePageSelector();
            TriggerVisualUpdate();
        }


        private void ManageClient_Form_VisibleChanged(object sender, EventArgs e)
        {
            SetGradientBackground("#D4ECD7", "#B2E2B8");
            resetFilter();
            TriggerVisualUpdate();
        }


        private void searchname_tb_Enter(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "ex. Piattos")
            {
                searchname_tb.Text = "";
                searchname_tb.ForeColor = Color.Black;
            }
        }


        private void searchname_tb_Leave(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "")
            {
                searchname_tb.Text = "ex. Piattos";
                searchname_tb.ForeColor = Color.Gray;
            }
        }


        private void noresult()
        {
            _no_result.Visible = max_count < 1;
            label3.Visible = checkbox_list.Count > 0;
        }


        private void requirements_btn_Click(object sender, EventArgs e)
        {
            Manage_ClientRules mcr = new Manage_ClientRules();
            mcr.ShowDialog();
        }


        private void search_btn_Click(object sender, EventArgs e)
        {
            TriggerVisualUpdate();
        }
    }
}
