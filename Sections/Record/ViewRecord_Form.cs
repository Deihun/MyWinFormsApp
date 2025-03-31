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

            year_cb.Items.Clear();
            client_cb.Items.Clear();
            truck_cb.Items.Clear();
            year_cb.Items.Add("<year>");
            client_cb.Items.Add("<select-client>");
            truck_cb.Items.Add("<select-truck>");

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

        private string getQueryCount()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT COUNT(record.id) FROM \r\nRecord_Table record JOIN AddedBundle_Table aBt ON aBt.record_id = record.id JOIN\r\nBundle_Table bundle ON aBt.bundle_id = bundle.id JOIN\r\nItem_Table item ON bundle.item_id = item.id JOIN\r\nAddedClient_Table aCt ON record.id = aCt.record_id JOIN\r\nClient_Table client ON aCt.client_id = client.id JOIN\r\nTruck_Table truck ON record.truck_id = truck.id JOIN Pallet_Table pallet ON aBt.pallet_id = pallet.id WHERE record.is_deleted = 0 AND bundle.is_deleted = 0 AND item.is_deleted = 0 AND client.is_deleted = 0 AND truck.is_deleted = 0 AND pallet.is_deleted = 0";

            List<string> conditions = new List<string>();

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

            if (conditions.Count > 0)
                preset_query += " AND " + string.Join(" AND ", conditions);
            //MessageBox.Show(preset_query);
            return preset_query;
        }

        private DataTable getRecordTable_ID()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT DISTINCT record.id, item.item_name FROM \r\nRecord_Table record JOIN AddedBundle_Table aBt ON aBt.record_id = record.id JOIN\r\nBundle_Table bundle ON aBt.bundle_id = bundle.id JOIN\r\nItem_Table item ON bundle.item_id = item.id JOIN\r\nAddedClient_Table aCt ON record.id = aCt.record_id JOIN\r\nClient_Table client ON aCt.client_id = client.id JOIN\r\nTruck_Table truck ON record.truck_id = truck.id JOIN Pallet_Table pallet ON aBt.pallet_id = pallet.id WHERE record.is_deleted = 0 AND bundle.is_deleted = 0 AND item.is_deleted = 0 AND client.is_deleted = 0 AND truck.is_deleted = 0 AND pallet.is_deleted = 0";

            List<string> conditions = new List<string>();

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

            if (conditions.Count > 0)
                preset_query += " AND " + string.Join(" AND ", conditions);
            preset_query += $" ORDER BY item.item_name OFFSET {(objects_perPage * (selected_page - 1))} ROWS FETCH NEXT {objects_perPage} ROWS ONLY;";
            //MessageBox.Show(preset_query);
            DataTable table = sql.ExecuteQuery(preset_query);
            return table;
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
        }
    }
}
