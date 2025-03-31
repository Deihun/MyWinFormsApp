using COMBINE_CHECKLIST_2024.DateToText;
using MyWinFormsApp.Sections.ManageItems;
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

namespace MyWinFormsApp.Sections.ManageBundles
{
    public partial class ManageBundles_Form : Form
    {
        private Scalingsupport scale = new Scalingsupport();
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private PageSelection page;

        private List<viewSelectedBundle_Form> list = new List<viewSelectedBundle_Form>();
        private List<CheckBox> categ_list = new List<CheckBox>();

        private const int objects_perPage = 7;
        private int selected_page = 1;

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;

        public ManageBundles_Form()
        {
            InitializeComponent();
            int maxCount = getMaximumCount();
            page = new PageSelection(maxCount, whenPageIsSelected);
            panel2.Controls.Add(page);
            page.Show();

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 100; // Delay for 100ms
            updateTimer.Tick += (s, e) =>
            {
                updateTimer.Stop();
                UpdateVisual();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 100; // Delay for 100ms
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _update_page_selector();

            };

            UpdateVisual();
            updatePageSelector();
        }

        public void TriggerVisualUpdate()
        {
            updateTimer.Stop();
            updateTimer.Start();
        }
        private void whenPageIsSelected(int page)
        {
            selected_page = page;
            TriggerVisualUpdate();
        }

        private void flutetype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePageSelector();
            TriggerVisualUpdate();
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

        public void UpdateVisual()
        {
            resetList();
            client_cb.Size = scale.ScaleObject(client_cb.Size);
            flutetype_cb.Size = scale.ScaleObject(flutetype_cb.Size);
            client_cb.Size = scale.ScaleObject(client_cb.Size);

            foreach (DataRow row in getRecordTable_ID().Rows) create_selectedbundleForm(Convert.ToInt32(row["id"]));

            list = list.OrderBy(vpif => vpif.BackColor == SystemColors.Control ? 0 : 1).ToList();
            storedarea_flt.Controls.Clear();
            foreach (var vpif in list)
            {
                storedarea_flt.Controls.Add(vpif);
                vpif.Show();
            }
            noResult();
        }
        private viewSelectedBundle_Form create_selectedbundleForm(int id)
        {
            viewSelectedBundle_Form vsbf = new viewSelectedBundle_Form(this, Convert.ToInt32(id));
            vsbf.TopLevel = false;
            storedarea_flt.Controls.Add(vsbf);
            vsbf.Show();
            list.Add(vsbf);
            return vsbf;
        }

        public void AddBundleFromCopy(string item_name)
        {
            AddEditBundle_windowpopupform aebwpf = new AddEditBundle_windowpopupform(this,item_name);
            aebwpf.ShowDialog();
        }

        private void check(object sender, EventArgs e)
        {
            foreach (CheckBox c in categ_list)
            {
                if (sender is CheckBox cb) if (cb == c) continue;
                c.Checked = false;
            }
            updatePageSelector();
            TriggerVisualUpdate();
            updatePageSelector();
        }

        private void resetList()
        {
            foreach (viewSelectedBundle_Form form in list) form.Dispose();
            list.Clear();
        }
        public void resetFilter()
        {
            foreach (Control c in categ_list) c.Dispose();
            categ_list.Clear();
            client_cb.Items.Clear();
            client_cb.Items.Add("<select-client>");
            flutetype_cb.Items.Clear();
            flutetype_cb.Items.Add("<select-flutetype>");
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Flute_Table WHERE is_deleted =0").Rows) flutetype_cb.Items.Add(row["code_name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted =0").Rows) client_cb.Items.Add(row["name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Bundle_Table WHERE is_deleted =0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                CheckBox check = new CheckBox();
                check.Text = row["category"].ToString();
                check.Tag = row["category"].ToString();
                check.AutoSize = true;
                check.ForeColor = Color.White;
                flowLayoutPanel1.Controls.Add(check);
                categ_list.Add(check);
                check.Padding = new Padding(20, 0, 0, 0);
                check.Show();
                check.CheckedChanged += this.check;
            }
            searchname_tb.Text = "ex. Piattos Small";
            searchname_tb.ForeColor = Color.Gray;
            client_cb.SelectedIndex = 0;
            flutetype_cb.SelectedIndex = 0;
        }

        private string getCheckboxName()
        {
            foreach (CheckBox c in categ_list) if (c.Checked) return c.Text;
            return "<no-text>";
        }

        private bool isAllUnchecked()
        {
            foreach (CheckBox c in categ_list) if (c.Checked) return false;
            return true;
        }



        private void ManageBundles_Form_VisibleChanged(object sender, EventArgs e)
        {
            resetFilter();
            TriggerVisualUpdate();
            updatePageSelector();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddEditBundle_windowpopupform aebwpuf = new AddEditBundle_windowpopupform(this);
            aebwpuf.ShowDialog();
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

        private void searchname_tb_Enter(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "ex. Piattos Small")
            {
                searchname_tb.Text = "";
                searchname_tb.ForeColor = Color.Black;
            }
        }

        private void searchname_tb_Leave(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "")
            {
                searchname_tb.Text = "ex. Piattos Small";
                searchname_tb.ForeColor = Color.Gray;
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            resetFilter();
            updatePageSelector();
            TriggerVisualUpdate();
        }

        private void noResult()
        {
            storedarea_flt.Controls.Add(_no_result);
            int a = 0;
            foreach (viewSelectedBundle_Form f in list) a += f.Visible ? 1 : 0;
            a = Math.Min(a, list.Count);
            _no_result.Visible = a < 1;
            label1.Visible = categ_list.Count > 0;
        }

        private DataTable getRecordTable_ID()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT DISTINCT bundle.id, item.item_name FROM \r\nBundle_Table bundle JOIN Item_Table item ON bundle.item_id = item.id JOIN\r\nFlute_Table flute ON item.flute_id = flute.id JOIN Client_Table client ON item.client_id = client.id \r\nWHERE bundle.is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piattos Small")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>" && !string.IsNullOrEmpty(client_cb.Text))
                conditions.Add($"client.name LIKE '%{client_cb.Text}%'");

            if (flutetype_cb.Text != "<select-flutetype>" && !string.IsNullOrEmpty(client_cb.Text))
                conditions.Add($"flute.code_name LIKE '%{flutetype_cb.Text}%'");

            foreach (CheckBox checkbox in categ_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"bundle.category = '{checkbox.Tag}'");
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

        private string getQueryCount()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT COUNT(bundle.id) FROM \r\nBundle_Table bundle JOIN Item_Table item ON bundle.item_id = item.id JOIN\r\nFlute_Table flute ON item.flute_id = flute.id JOIN Client_Table client ON item.client_id = client.id \r\nWHERE bundle.is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piattos Small")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>" && !string.IsNullOrEmpty(client_cb.Text))
                conditions.Add($"client.name LIKE '%{client_cb.Text}%'");

            if (flutetype_cb.Text != "<select-flutetype>" && !string.IsNullOrEmpty(client_cb.Text))
                conditions.Add($"flute.code_name LIKE '%{flutetype_cb.Text}%'");
            foreach (CheckBox checkbox in categ_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;

                category.Add($"bundle.category = '{checkbox.Tag}'");
            }

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
    }
}
