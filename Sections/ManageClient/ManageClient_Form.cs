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

namespace MyWinFormsApp.Sections.ManageClient
{
    public partial class ManageClient_Form : Form
    {
        private List<ExistingSelectClient_form> list = new List<ExistingSelectClient_form>();
        private List<CheckBox> checkbox_list = new List<CheckBox>();
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private PageSelection page;

        private const int objects_perPage = 7;
        private int selected_page = 1;

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;

        public ManageClient_Form()
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
                UpdateVisual();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 100;
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _start_updatePage_Selector();
            };


            UpdateVisual();
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
            AddNewClient_WindowPopupForm ancwpf = new AddNewClient_WindowPopupForm(this);
            ancwpf.ShowDialog();
        }

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

        public void UpdateVisual()
        {
            resetList();
            foreach (DataRow row in getRecordTable_ID().Rows) create_selectedClient(row);
            noresult();

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
        private void resetList()
        {
            foreach (ExistingSelectClient_form form in list) form.Dispose();
            list.Clear();
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
            setFilter();
        }
        private void setFilter()
        {
            FilterInputSupportClass filter = new FilterInputSupportClass();
            foreach (ExistingSelectClient_form f in list)
            {
                bool isNameApplicable = searchname_tb.Text == "ex. Piattos" || string.IsNullOrEmpty(searchname_tb.Text) || filter.ContainsSimilarSubstring(f.client_name, searchname_tb.Text);
                bool category = isAllUnchecked() || getCheckboxName() == f.category;
                f.Visible = (isNameApplicable && category);
            }
            noresult();
        }
        private bool isAllUnchecked()
        {
            foreach (CheckBox c in checkbox_list) if (c.Checked) return false;
            return true;
        }

        private string getCheckboxName()
        {
            foreach (CheckBox c in checkbox_list) if (c.Checked) return c.Text;
            return "<no-name>";
        }

        private void searchname_tb_TextChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private void ManageClient_Form_VisibleChanged(object sender, EventArgs e)
        {
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
            int a = 0;
            foreach (ExistingSelectClient_form f in list) a += f.Visible ? 1 : 0;
            a = Math.Min(a, list.Count);
            _no_result.Visible = a < 1;
            label3.Visible = checkbox_list.Count > 0;
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

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

        private string getQueryCount()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT COUNT(client.id) FROM\r\nClient_Table client WHERE is_deleted = 0 ";

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
                //MessageBox.Show($"Conversion = {Convert.ToInt32(sql.ExecuteQuery(getQueryCount()).Rows[0][0])} divide by {objects_perPage} = {value}, { Convert.ToInt32(Math.Ceiling(value))}");
                return Convert.ToInt32(Math.Ceiling(value));
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
                return count;
            }
        }

        private void requirements_btn_Click(object sender, EventArgs e)
        {
            Manage_ClientRules mcr = new Manage_ClientRules();
            mcr.ShowDialog();
        }
    }
}
