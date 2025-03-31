using COMBINE_CHECKLIST_2024.DateToText;
using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private List<ViewRecordSelection_Form> viewrecordselection_form_list = new List<ViewRecordSelection_Form>();
        private List<string> yearDate = new List<string>();

        private const int objects_perPage = 7;
        private int selected_page = 1;

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;

        private List<CheckBox> checkbox_list = new List<CheckBox>();

        public ViewRecord_Form()
        {
            InitializeComponent();
            int maxCount = getMaximumCount();
            page = new PageSelection(maxCount, whenPageIsSelected);
            panel1.Controls.Add(page);
            page.Show();

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 100; // Delay for 100ms
            updateTimer.Tick += (s, e) =>
            {
                updateTimer.Stop(); 
                UpdateVisuals();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 100; // Delay for 100ms
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _update_page_selector();
            };

            UpdateVisuals();
            updatePageSelector();
            _no_result.Visible = false;

        }


        private void TriggerVisualUpdate()
        {
            updateTimer.Stop(); 
            updateTimer.Start(); 
        }

        //** VISUAL CHANGES METHODS
        public void UpdateVisuals()//MODIFY THIS METHOD WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            yearDate.Clear();
            foreach (Form f in viewrecordselection_form_list) f.Dispose();
            viewrecordselection_form_list.Clear();

            foreach (DataRow row in getRecordTable_ID().Rows)
            {
                create_viewRecordSelection(Convert.ToInt32(row["id"]));
            }
            foreach (ViewRecordSelection_Form f in viewrecordselection_form_list) yearDate.Add(f.datecreated.Year.ToString());
            yearDate = yearDate.Distinct().ToList();

            noResult();
            updatePageSelector();

        }

        private ViewRecordSelection_Form create_viewRecordSelection(int id)
        {
            //MessageBox.Show(id.ToString());
            ViewRecordSelection_Form form = new ViewRecordSelection_Form(id, this, parent);
            form.TopLevel = false;
            storedarea_flt.Controls.Add(form);
            viewrecordselection_form_list.Add(form);
            form.Show();
            return form;
        }

        private void _update_page_selector()
        {
            page.reinstantiate(getMaximumCount());
        }
        public void updatePageSelector()
        {
            pageTimer.Stop();
            pageTimer.Start();
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
            selected_page = page;
            TriggerVisualUpdate();
        }


        // ** CONTROL EVENTS
        private void ViewRecord_Form_VisibleChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
            resetFilter();
        }

        private void searchname_tb_TextChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();             
        }

        private void client_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private void truck_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
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
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private void month_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private void year_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private void checkboxTrigger(object sender, EventArgs e)
        {
            foreach (CheckBox cb in checkbox_list)
            {
                if (sender is CheckBox s) if (cb == s) continue;
                cb.Checked = false;
            }
            updatePageSelector();
            TriggerVisualUpdate();
            updatePageSelector();
        }

        private string getQueryCount()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "  SELECT COUNT(DISTINCT record.id) FROM Record_Table record JOIN AddedBundle_Table aBt ON aBt.record_id = record.id\r\nJOIN Bundle_Table bundle ON aBt.bundle_id = bundle.id\r\nJOIN Item_Table item ON bundle.item_id = item.id\r\nJOIN Client_Table client ON item.client_id = client.id\r\nJOIN Truck_Table truck ON record.truck_id = truck.id LEFT JOIN Pallet_Table pallet ON aBt.pallet_id = pallet.id\r\nWHERE record.is_deleted = 0";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piatos")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>")
                conditions.Add($"client.name LIKE '%{client_cb.Text}%'");

            if (truck_cb.Text != "<select-truck>")
                conditions.Add($"truck.platenumber LIKE '%{truck_cb.Text}%'");

            if (month_cb.Text != "<month>")
                conditions.Add($"MONTH(record.date_added) LIKE '%{datetotext.getMonth(month_cb.Text)}%'");

            if (year_cb.Text != "<year>")
                conditions.Add($"YEAR(record.date_added) LIKE '%{year_cb.Text}%'");

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
            //MessageBox.Show(preset_query);
            return preset_query;
        }

        private DataTable getRecordTable_ID()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT DISTINCT record.id, item.item_name FROM Record_Table record JOIN AddedBundle_Table aBt ON aBt.record_id = record.id JOIN\r\nBundle_Table bundle ON aBt.bundle_id = bundle.id JOIN\r\nItem_Table item ON bundle.item_id = item.id JOIN Client_Table client ON item.client_id = client.id JOIN Truck_Table truck ON record.truck_id = truck.id LEFT JOIN Pallet_Table pallet ON aBt.pallet_id = pallet.id WHERE record.is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piatos")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>")
                conditions.Add($"client.name LIKE '%{client_cb.Text}%'");

            if (truck_cb.Text != "<select-truck>")
                conditions.Add($"truck.platenumber LIKE '%{truck_cb.Text}%'");

            if (month_cb.Text != "<month>")
                conditions.Add($"MONTH(record.date_added) LIKE '%{datetotext.getMonth(month_cb.Text)}%'");

            if (year_cb.Text != "<year>")
                conditions.Add($"YEAR(record.date_added) LIKE '%{year_cb.Text}%'");

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
            preset_query += $" ORDER BY item.item_name OFFSET {(objects_perPage * (selected_page - 1))} ROWS FETCH NEXT {objects_perPage} ROWS ONLY;";
            //MessageBox.Show(preset_query);
            DataTable table = sql.ExecuteQuery(preset_query);
            return table;
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


        private int getMaximumCount()
        {
            int count = 0;
            try
            {
                decimal value = (Convert.ToDecimal(sql.ExecuteQuery(getQueryCount()).Rows[0][0]) / objects_perPage);
                //MessageBox.Show($"Conversion = {Convert.ToInt32(sql.ExecuteQuery(getQueryCount()).Rows[0][0])} divide by {objects_perPage} = {value}");
                return Convert.ToInt32(Math.Ceiling(value));
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
                return count;
            }
        }
        private void noResult()
        {
            int numberOfVisible = 0;
            foreach (ViewRecordSelection_Form f in viewrecordselection_form_list) numberOfVisible += f.Visible ? 1 : 0;
            numberOfVisible = Math.Min(numberOfVisible, viewrecordselection_form_list.Count);

            _no_result.Visible = numberOfVisible < 1;
            label6.Visible = checkbox_list.Count > 0;
        }
    }
}
