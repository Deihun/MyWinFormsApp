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

namespace MyWinFormsApp.Sections.Record
{
    public partial class ViewRecord_Form : Form
    {
        //<REFERENCE CLASS>
        public main_startup_form parent;

        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private PageSelection page;

        //<LIST>
        private List<FlowLayoutPanel> pages = new List<FlowLayoutPanel>();
        private List<CheckBox> checkbox_list = new List<CheckBox>();
        private List<string> yearDate = new List<string>();

        private const int objects_perPage = 5;
        private int max_count = 0;

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;


        public ViewRecord_Form()
        {
            InitializeComponent();
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 50;
            updateTimer.Tick += (s, e) =>
            {
                updateTimer.Stop();
                UpdateVisuals();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 50;
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _update_page_selector();
            };

            _no_result.Visible = false;
        }






        //** VISUAL CHANGES METHODS
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
                LinearGradientMode.Vertical)) 
            {
                g.FillRectangle(brush, 0, 0, this.Width, this.Height);
            }
            this.BackgroundImage = bmp;
        }

        /// <summary>
        /// Update the visual appearance of the ViewRecord Form
        /// </summary>
        public void TriggerVisualUpdate()
        {
            if (updateTimer.Enabled) return;
            updateTimer.Start();
        }
        
        /// <summary>
        /// Update the PageSelector Object
        /// </summary>
        public void updatePageSelector()
        {
            if (pageTimer.Enabled) return;
            pageTimer.Start();
        }


        private void _update_page_selector()
        {
            foreach (Control control in panel1.Controls)control.Dispose();
            panel1.Controls.Clear();
            decimal result = (decimal)max_count / objects_perPage; 
            var pages = Convert.ToInt32(Math.Ceiling(result));
            page = new PageSelection(pages, whenPageIsSelected);
            panel1.Controls.Add(page);
            page.Show();
            Debug.WriteLine($"UPDATEPAGESELECTOR // {max_count} maxCount/{objects_perPage} objectperpage ={pages} or {result}");
        }


        private void UpdateVisuals()//MODIFY THIS METHOD WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            foreach (FlowLayoutPanel control in pages)control.Dispose();
            pages.Clear();

            List<string> year_data = new List<string>();
            int object_created_count = 0;
            int current_page_now = 0;
            yearDate.Clear();
            add_page();

            foreach (DataRow row in getRecordTable_ID().Rows)
            {
                var form = create_viewRecordSelection(Convert.ToInt32(row["id"]));
                pages[current_page_now].Controls.Add(form);
                form.Show();
                year_data.Add(form.datecreated.Year.ToString());
                object_created_count++;
                Debug.WriteLine($"CurrentObjectNo: {object_created_count}, pageCodeNumber:{current_page_now}, id {row["id"]}");
                if (object_created_count % objects_perPage == 0)
                {
                    add_page();
                    current_page_now++;
                }
            }
            max_count = object_created_count;
            year_data = year_data.Distinct().ToList();
            year_cb.Items.Clear();
            year_cb.Items.AddRange(year_data.ToArray());

            Debug.WriteLine($"DEBUG" +
                $"\n number_of_page = {current_page_now}, number_of_object = {max_count}");
            noResult();
            updatePageSelector();
            whenPageIsSelected(0);
        }


        private void resetFilter()
        {
            foreach (CheckBox check in checkbox_list) check.Dispose();

            checkbox_list.Clear();
            year_cb.Items.Clear();
            client_cb.Items.Clear();
            truck_cb.Items.Clear();
            year_cb.Items.Add("<year>");
            client_cb.Items.Add("<select-client>");
            truck_cb.Items.Add("<select-truck>");

            foreach (DataRow row in sql.ExecuteQuery("SELECT category FROM Record_Table WHERE is_deleted = 0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                create_check(row["category"].ToString());
            }
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0").Rows) client_cb.Items.Add(row["name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Truck_Table WHERE is_deleted = 0").Rows) truck_cb.Items.Add(row["platenumber"].ToString());
            foreach (string s in yearDate) year_cb.Items.Add(s);

            searchname_tb.Text = "ex. Piatos";
            searchname_tb.ForeColor = Color.Gray;
            year_cb.SelectedIndex = 0;
            client_cb.SelectedIndex = 0;
            truck_cb.SelectedIndex = 0;
            month_cb.SelectedIndex = 0;
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


        private void noResult()
        {
            _no_result.Visible = max_count < 1;
            label6.Visible = checkbox_list.Count > 0;
        }




        //OBJECT SETTER
        private DataTable getRecordTable_ID()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = @"
                SELECT record.id, MIN(item.item_name) AS item_name
                FROM Record_Table record 
                JOIN AddedBundle_Table aBt ON aBt.record_id = record.id 
                JOIN Bundle_Table bundle ON aBt.bundle_id = bundle.id 
                JOIN Item_Table item ON bundle.item_id = item.id 
                JOIN Client_Table client ON item.client_id = client.id 
                JOIN Truck_Table truck ON record.truck_id = truck.id 
                LEFT JOIN Pallet_Table pallet ON aBt.pallet_id = pallet.id 
                WHERE record.is_deleted = 0";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piatos")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>")
                conditions.Add($"client.name LIKE '%{client_cb.Text}%'");

            if (truck_cb.Text != "<select-truck>")
                conditions.Add($"truck.platenumber LIKE '%{truck_cb.Text}%'");

            if (month_cb.Text != "<month>")
                conditions.Add($"MONTH(record.date_added) = {datetotext.getMonth(month_cb.Text)}");

            if (year_cb.Text != "<year>")
                conditions.Add($"YEAR(record.date_added) = {year_cb.Text}");

            foreach (CheckBox checkbox in checkbox_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"record.category = '{checkbox.Tag}'");
            }

            if (category.Count > 0)
                preset_query += $" AND ({string.Join(" OR ", category)})";

            if (conditions.Count > 0)
                preset_query += " AND " + string.Join(" AND ", conditions);

            preset_query += " GROUP BY record.id";

            DataTable table = sql.ExecuteQuery(preset_query);
            Debug.WriteLine($"ReturningDataTable: {table.Rows.Count}");
            return table;
        }


        private ViewRecordSelection_Form create_viewRecordSelection(int id)
        {
            ViewRecordSelection_Form form = new ViewRecordSelection_Form(id, this, parent);
            form.TopLevel = false;
            form.Show();
            return form;
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


        private CheckBox create_check(string category)
        {
            CheckBox check = new CheckBox();
            check.Text = category;
            check.Tag = category;
            flowLayoutPanel1.Controls.Add(check);
            checkbox_list.Add(check);
            check.Padding = new Padding(20, 0, 0, 0);
            check.ForeColor = Color.White;
            check.AutoSize = true;
            check.Visible = true;
            check.Checked = false;
            check.CheckedChanged += checkboxTrigger;
            return check;
        }






        // ** CONTROL EVENTS
        private void ViewRecord_Form_VisibleChanged(object sender, EventArgs e)
        {
            SetGradientBackground("#D4ECD7", "#B2E2B8");
            TriggerVisualUpdate();
            resetFilter();
        }


        private void searchname_tb_Enter(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "ex. Piatos")
            {
                searchname_tb.Text = "";
                searchname_tb.ForeColor = Color.Black;
            }
        }


        private void searchname_tb_Leave(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "")
            {
                searchname_tb.Text = "ex. Piatos";
                searchname_tb.ForeColor = Color.Gray;
            }
        }


        private void clear_btn_Click(object sender, EventArgs e)
        {
            resetFilter();
            TriggerVisualUpdate();
        }


        private void checkboxTrigger(object sender, EventArgs e)
        {
            foreach (CheckBox cb in checkbox_list)
            {
                if (sender is CheckBox s) if (cb == s) continue;
                cb.Checked = false;
            }
        }


        private void search_btn_Click(object sender, EventArgs e)
        {
            UpdateVisuals();
        }
    }
}
