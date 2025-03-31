using COMBINE_CHECKLIST_2024.DateToText;
using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System.Data;

namespace MyWinFormsApp.Sections.ManageTrucks
{
    public partial class ManageTrucks_Form : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        List<PreviewSelectedTruck_Form> list = new List<PreviewSelectedTruck_Form>();
        List<CheckBox> checkbox_list = new List<CheckBox>();
        private PageSelection page;

        bool ischeckboxTrigger = false;

        private const int objects_perPage = 7;
        private int selected_page = 1;

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;
        public ManageTrucks_Form()
        {
            InitializeComponent();
            int maxCount = getMaximumCount();
            page = new PageSelection(maxCount, whenPageIsSelected);
            panel2.Controls.Add(page);
            page.Show();

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 100;
            updateTimer.Tick += (s, e) =>
            {
                updateTimer.Stop();
                updateVisual();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 100;
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _start_updatePage_Selector();
            };


            updateVisual();
            updatePageSelector();
        }

        private void _start_updatePage_Selector()
        {
            page.reinstantiate(getMaximumCount());
        }
        public void updatePageSelector()
        {
            pageTimer.Stop();
            pageTimer.Start();
        }
        private void whenPageIsSelected(int page)
        {
            selected_page = page;
            TriggerVisualUpdate();
        }

        public void TriggerVisualUpdate()
        {
            updateTimer.Stop();
            updateTimer.Start();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddTruck_popWindows addtruck = new AddTruck_popWindows(this);
            addtruck.ShowDialog();
        }

        private PreviewSelectedTruck_Form create_viewTruck(int id)
        {
            PreviewSelectedTruck_Form pstf = new PreviewSelectedTruck_Form(id, this);
            pstf.TopLevel = false;
            storedarea_flt.Controls.Add(pstf);
            pstf.Show();
            list.Add(pstf);
            return pstf;
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

        public void updateVisual()
        {
            removeAllTruckDataObject();
            ischeckboxTrigger = false;
            foreach (DataRow row in getRecordTable_ID().Rows) create_viewTruck(Convert.ToInt32(row["id"]));
            noresult();
        }


        private bool isAllUnchecked()
        {
            foreach (CheckBox c in checkbox_list) if (c.Checked) return false;
            return true;
        }
        private void checkboxTrigger(object sender, EventArgs e)
        {
            ischeckboxTrigger = true;
            foreach (CheckBox cb in checkbox_list)
            { if(sender is CheckBox s) if (cb == s) continue;
                cb.Checked = false;
            }
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private string getCheckboxName()
        {
            foreach (CheckBox cb in checkbox_list)
            {
                if (cb.Checked) return cb.Text; 
            }
            return "<no-combobox-are-checked>";
        }

        private void removeAllTruckDataObject()
        {
            foreach (PreviewSelectedTruck_Form f in list) f.Dispose();
            list.Clear();
        }

        public void resetFilter()
        {
            foreach (CheckBox i in checkbox_list) i.Dispose();
            checkbox_list.Clear();
            wheelertype_cb.Items.Clear();
            wheelertype_cb.Items.Add("<select-type-of-truck>");
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT trucktype FROM Truck_Table WHERE is_deleted = 0").Rows) wheelertype_cb.Items.Add(row["trucktype"]);
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Truck_Table WHERE is_deleted = 0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                create_check(row["category"].ToString());
            }

            wheelertype_cb.SelectedIndex = 0;
            platenumbersearch_tb.Text = "<ex. AAU5659>";
            platenumbersearch_tb.ForeColor = Color.Gray;
            
        }

        private void ManageTrucks_Form_VisibleChanged(object sender, EventArgs e)
        {
            resetFilter();
            TriggerVisualUpdate();
            updatePageSelector();
        }

        private void platenumbersearch_tb_TextChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private void wheelertype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private void platenumbersearch_tb_Enter(object sender, EventArgs e)
        {
            if (platenumbersearch_tb.Text == "<ex. AAU5659>")
            {
                platenumbersearch_tb.Text = "";
                platenumbersearch_tb.ForeColor = Color.Black;
            }
        }

        private void platenumbersearch_tb_Leave(object sender, EventArgs e)
        {
            if (platenumbersearch_tb.Text == "")
            {
                platenumbersearch_tb.Text = "<ex. AAU5659>";
                platenumbersearch_tb.ForeColor = Color.Gray;
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            resetFilter();
        }
        private void noresult()
        {
            int a = 0;
            foreach (Form f in list) a += f.Visible ? 1 : 0;
            a = Math.Min(a, list.Count);
            _no_result.Visible = a < 1;
            label1.Visible = checkbox_list.Count > 0;
           
        }

        private DataTable getRecordTable_ID()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "\r\nSELECT DISTINCT truck.id, truck.platenumber FROM Truck_Table truck WHERE is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();
            if (!string.IsNullOrEmpty(platenumbersearch_tb.Text) && platenumbersearch_tb.Text != "<ex. AAU5659>")
                conditions.Add($"truck.platenumber LIKE '%{platenumbersearch_tb.Text}%'");
            if (!string.IsNullOrEmpty(wheelertype_cb.Text) && wheelertype_cb.Text != "<select-type-of-truck>")
                conditions.Add($"truck.trucktype = '{wheelertype_cb.Text}'");

            foreach (CheckBox checkbox in checkbox_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"truck.category = '{checkbox.Tag}'");
            }
            if (conditions.Count > 0)
                preset_query += $" AND ({string.Join(" AND ", conditions)})";
            if (category.Count > 0)
                preset_query += $" AND ({string.Join(" OR ", category)})";
            preset_query += $" ORDER BY truck.platenumber OFFSET {(objects_perPage * (selected_page - 1))} ROWS FETCH NEXT {objects_perPage} ROWS ONLY;";
            //MessageBox.Show(preset_query);
            DataTable table = sql.ExecuteQuery(preset_query);
            return table;
        }
        private string getQueryCount()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT COUNT(truck.id) FROM Truck_Table truck WHERE is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(platenumbersearch_tb.Text) && platenumbersearch_tb.Text != "<ex. AAU5659>")
                conditions.Add($"truck.platenumber LIKE '%{platenumbersearch_tb.Text}%'");
            if (!string.IsNullOrEmpty(wheelertype_cb.Text) && wheelertype_cb.Text != "<select-type-of-truck>")
                conditions.Add($"truck.trucktype = '{wheelertype_cb.Text}'");

            foreach (CheckBox checkbox in checkbox_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"truck.category = '{checkbox.Tag}'");
            }

            if (conditions.Count > 0)
                preset_query += $" AND ({string.Join(" AND ", conditions)})";
            if (category.Count > 0)
                preset_query += $" AND ({string.Join(" OR ", category)})";

            if (conditions.Count > 0)
                preset_query += " AND " + string.Join(" AND ", conditions);
            //MessageBox.Show(preset_query);
            return preset_query;
        }

        private int getMaximumCount()
        {
            int count = 0;
            try
            {
                decimal value = (Convert.ToDecimal(sql.ExecuteQuery(getQueryCount()).Rows[0][0]) / objects_perPage);
                //MessageBox.Show($"Conversion = {Convert.ToDecimal(sql.ExecuteQuery(getQueryCount()).Rows[0][0])} divide by {objects_perPage} = {value}, { Convert.ToInt32(Math.Ceiling(value))}, {Convert.ToInt32(sql.ExecuteQuery(getQueryCount()).Rows[0][0]) / objects_perPage}");
                return Convert.ToInt32(Math.Ceiling(value));
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
                return count;
            }
        }
    }
}
