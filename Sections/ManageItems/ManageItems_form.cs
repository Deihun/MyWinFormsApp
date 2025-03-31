using COMBINE_CHECKLIST_2024.DateToText;
using MyWinFormsApp.Sections.ManageItems;
using MyWinFormsApp.Sections.ManageItems.Flute;
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

namespace MyWinFormsApp.Sections
{
    public partial class ManageItems_form : Form
    {
        Scalingsupport scalingsupport = new Scalingsupport();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        PageSelection page;
        main_startup_form parent; 

        List<ViewPerItem_Form> list = new List<ViewPerItem_Form>();
        List<CheckBox> categ_list = new List<CheckBox>();

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;

        private const int object_perPage = 7;
        private int selected_page = 1;

        public ManageItems_form(main_startup_form parent)
        {
            InitializeComponent();
            int maxCount = getMaximumCount();
            page = new PageSelection(2, whenPageIsSelected);
            panel1.Controls.Add(page);
            page.Show();

            this.parent = parent;

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
                _update_page_selection();
            };
            UpdateVisual();
            resetFilter();
            updatePageSelection();
            
            
        }

        public void TriggerVisualUpdate()
        {
            updateTimer.Stop();
            updateTimer.Start();
        }

        // UPDATE VISUALS
        private ViewPerItem_Form create_viewPerItem(int id)
        {
            ViewPerItem_Form form = new ViewPerItem_Form(id, this, parent);
            form.TopLevel = false;
            storedarea_flt.Controls.Add(form);
            form.Show();
            list.Add(form);
            return form;
        }

        private CheckBox create_category(string text)
        {
            CheckBox cb = new CheckBox();
            cb.Tag = text;
            cb.Text = text;
            cb.ForeColor = Color.White;
            cb.AutoSize = true;
            cb.Padding = new Padding(20, 0, 0, 0);
            flowLayoutPanel1.Controls.Add(cb);
            categ_list.Add(cb);
            cb.Show();
            cb.CheckedChanged += this.check;
            return cb;
        }

        
        public void UpdateVisual()
        {
            searchname_tb.Size = scalingsupport.ScaleObject(searchname_tb.Size);
            flutetype_cb.Size = scalingsupport.ScaleObject(flutetype_cb.Size);
            add_btn.Size = scalingsupport.ScaleObject(add_btn.Size);
            resetList();

            foreach (DataRow row in get_ItemTable_IDs().Rows)
            {
                create_viewPerItem(Convert.ToInt32(row["id"]));
            }

            list = list.OrderBy(vpif => vpif.BackColor == SystemColors.Control ? 0 : 1).ToList();
            storedarea_flt.Controls.Clear();  
            foreach (var vpif in list)
            {
                storedarea_flt.Controls.Add(vpif);
                vpif.Show();
            }
            updatePageSelection();
            _NoResult();
        }

        private void _update_page_selection()
        {
            page.reinstantiate(getMaximumCount());
            _NoResult();
        }
        public void updatePageSelection()
        {
            pageTimer.Stop();
            pageTimer.Start();
        }

        private void whenPageIsSelected(int page)
        {
            selected_page = page;
            TriggerVisualUpdate();
        }


        private void check(object sender, EventArgs e)
        {
            foreach(CheckBox c in categ_list)
            {
                if (sender is CheckBox cb) if (cb == c) continue;
                c.Checked = false;
            }
            updatePageSelection();
            TriggerVisualUpdate();
            updatePageSelection();
        }
        private void resetList()
        {
            foreach (ViewPerItem_Form form in list) form.Dispose();
            list.Clear();
        }

        public void resetFilter()
        {
            foreach (CheckBox c in categ_list) c.Dispose();
            categ_list.Clear();
            client_cb.Items.Clear();
            flutetype_cb.Items.Clear();
            client_cb.Items.Add("<select-client>");
            flutetype_cb.Items.Add("<select-flutetype>");

            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Flute_Table WHERE is_deleted = 0").Rows) flutetype_cb.Items.Add(row["code_name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0").Rows) client_cb.Items.Add(row["name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Item_Table WHERE is_deleted = 0").Rows)
            {
            if (string.IsNullOrEmpty(row["category"].ToString())) continue;
            create_category(row["category"].ToString());
            }

            client_cb.SelectedIndex = 0;
            flutetype_cb.SelectedIndex = 0;
            searchname_tb.Text = "ex. Piatos Small";
            searchname_tb.ForeColor = Color.Gray;
        }
        private bool isAllUnchecked()
        {
            foreach (CheckBox c in categ_list) if (c.Checked) return false;
            return true;
        }

        private string getCheckboxName()
        {
            foreach (CheckBox c in categ_list) if (c.Checked) return c.Text;
            return "<no-text>";
        }

        private void tablelayout_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            updatePageSelection();
            TriggerVisualUpdate();
        }

        private void ManageItems_form_VisibleChanged(object sender, EventArgs e)
        {
            resetFilter();
            updatePageSelection();
            TriggerVisualUpdate();
            updatePageSelection(); 
            
        }

        private void flutetype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePageSelection();
            TriggerVisualUpdate();
        }

        private void manageflute_btn_Click(object sender, EventArgs e)
        {
            ManageFlute_WindowPopupForm mfwpuf = new ManageFlute_WindowPopupForm();
            mfwpuf.ShowDialog();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddNewItems_WindowPopUpForm aniwpuf = new AddNewItems_WindowPopUpForm(this, parent);
            aniwpuf.ShowDialog();
        }

        private void client_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatePageSelection();
            TriggerVisualUpdate();
        }

        private void searchname_tb_TextChanged(object sender, EventArgs e)
        {
            updatePageSelection();
            TriggerVisualUpdate();
        }

        private void searchname_tb_Enter(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "ex. Piatos Small")
            {
                searchname_tb.Text = "";
                searchname_tb.ForeColor = Color.Black;
            }
        }

        private void searchname_tb_Leave(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "")
            {
                searchname_tb.Text = "ex. Piatos Small";
                searchname_tb.ForeColor = Color.Gray;
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            resetFilter();
        }

        private void _NoResult()
        {
            storedarea_flt.Controls.Add(_no_result);
            int _noresult = 0;
            foreach (ViewPerItem_Form f in list) _noresult += f.Visible ? 1 : 0;
            _noresult = Math.Min(_noresult, list.Count);

            _no_result.Visible = _noresult < 1;
            label1.Visible = categ_list.Count > 0;
        }




        private string getQueryCount()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT COUNT(item.id) FROM \r\nItem_Table item JOIN Flute_Table flute ON item.flute_id = flute.id JOIN\r\nClient_Table client ON item.client_id = client.id WHERE item.is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piatos Small")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>" && !string.IsNullOrEmpty(client_cb.Text))
                conditions.Add($"client.name = '{client_cb.Text}'");

            if ((flutetype_cb.Text != "<select-flutetype>") && (flutetype_cb.Text != string.Empty))
                conditions.Add($"flute.code_name = '{flutetype_cb.Text}'");

            foreach (CheckBox checkbox in categ_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"item.category = '{checkbox.Tag}'");
            }

            if (category.Count > 0) preset_query += $" AND ({string.Join(" OR ", category)})";

            if (conditions.Count > 0) preset_query += " AND " + string.Join(" AND ", conditions);
            //MessageBox.Show(preset_query);
            return preset_query;
        }
        private DataTable get_ItemTable_IDs()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "SELECT DISTINCT item.id, item.item_name FROM \r\nItem_Table item JOIN Flute_Table flute ON item.flute_id = flute.id JOIN\r\nClient_Table client ON item.client_id = client.id WHERE item.is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piatos Small")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>")
                conditions.Add($"client.name LIKE '%{client_cb.Text}%'");

            if ((flutetype_cb.Text != "<select-flutetype>") && (flutetype_cb.Text != string.Empty))
                conditions.Add($"flute.code_name LIKE '%{flutetype_cb.Text}%'");
            foreach (CheckBox checkbox in categ_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"item.category = '{checkbox.Tag}'");
            }

            if (conditions.Count > 0)
                preset_query += $" AND ({string.Join(" AND ", conditions)})";
            if (category.Count > 0)
                preset_query += $" AND ({string.Join(" OR ", category)})";
            preset_query += $" ORDER BY item.item_name OFFSET {(object_perPage * (selected_page - 1))} ROWS FETCH NEXT {object_perPage} ROWS ONLY;";
            
            DataTable data = sql.ExecuteQuery(preset_query);
            return data;
        }
        private int getMaximumCount()
        {
            int count = 0;
            try
            {
                decimal value = (Convert.ToDecimal(sql.ExecuteQuery(getQueryCount()).Rows[0][0]) / object_perPage);
                
                //MessageBox.Show($"Conversion = {Convert.ToInt32(sql.ExecuteQuery(getQueryCount()).Rows[0][0])} divide by {object_perPage} = {value} ceiling = {Convert.ToInt32(Math.Ceiling(value))}");
                return Convert.ToInt32(Math.Ceiling(value));
            }
            catch
            {
                return count;
            }
        }
    }
}
