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
        bool ischeckboxTrigger = false;
        public ManageTrucks_Form()
        {
            InitializeComponent();
            updateVisual();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddTruck_popWindows addtruck = new AddTruck_popWindows(this);
            addtruck.ShowDialog();
        }

        public void updateVisual()
        {
            removeAllTruckDataObject();
            ischeckboxTrigger = false;
            DataTable data = sql.ExecuteQuery("SELECT id FROM Truck_Table WHERE is_deleted = 0;");
            foreach (CheckBox i in checkbox_list) i.Dispose();
            foreach (DataRow row in data.Rows)
            {
                int settedID = Convert.ToInt32(row["id"]);
                PreviewSelectedTruck_Form pstf = new PreviewSelectedTruck_Form(settedID, this);
                pstf.TopLevel = false;
                storedarea_flt.Controls.Add(pstf);
                pstf.Show();
                list.Add(pstf);
            }
            checkbox_list.Clear();
            wheelertype_cb.Items.Clear();
            wheelertype_cb.Items.Add("<select-type-of-truck>");
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT trucktype FROM Truck_Table WHERE is_deleted = 0").Rows) wheelertype_cb.Items.Add(row["trucktype"]);
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Truck_Table WHERE is_deleted = 0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                CheckBox check = new CheckBox();
                check.Text = row["category"].ToString();
                flowLayoutPanel1.Controls.Add(check);
                checkbox_list.Add(check);
                check.Padding = new Padding(20, 0, 0, 0);
                check.ForeColor = Color.White;
                check.AutoSize = true;
                check.Visible = true;
                check.Checked = false;
                check.CheckedChanged += checkboxTrigger;
            }
            resetFilter();
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
            setFilter();
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

        private void resetFilter()
        {
            wheelertype_cb.SelectedIndex = 0;
            platenumbersearch_tb.Text = "<ex. AAU5659>";
            platenumbersearch_tb.ForeColor = Color.Gray;
            foreach (PreviewSelectedTruck_Form f in list) f.Show();
        }

        private void setFilter()
        {
            FilterInputSupportClass filter = new FilterInputSupportClass();

            foreach (PreviewSelectedTruck_Form f in list)
            {
                bool matchesPlate = (string.IsNullOrEmpty(platenumbersearch_tb.Text) || platenumbersearch_tb.Text == "<ex. AAU5659>") ||
                                    filter.ContainsSimilarSubstring(f.platenumber, platenumbersearch_tb.Text);
                bool matchesTruckType = wheelertype_cb.Text == "<select-type-of-truck>" ||
                                    filter.ContainsSimilarSubstring(f.TypeOfTruck, wheelertype_cb.Text, 0);
                bool category = isAllUnchecked() || getCheckboxName() == f.category;
                f.Visible = matchesPlate && matchesTruckType && category;
            }
            noresult();
        }

        private void ManageTrucks_Form_VisibleChanged(object sender, EventArgs e)
        {
            updateVisual();
        }

        private void platenumbersearch_tb_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void wheelertype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
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
    }
}
