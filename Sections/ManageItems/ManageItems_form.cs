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
        List<ViewPerItem_Form> list = new List<ViewPerItem_Form>();
        List<CheckBox> categ_list = new List<CheckBox>();
        public ManageItems_form()
        {
            InitializeComponent();


        }


        public void UpdateVisual()
        {
            searchname_tb.Size = scalingsupport.ScaleObject(searchname_tb.Size);
            flutetype_cb.Size = scalingsupport.ScaleObject(flutetype_cb.Size);
            add_btn.Size = scalingsupport.ScaleObject(add_btn.Size);
            DataTable dt = sql.ExecuteQuery("SELECT * FROM Item_Table WHERE is_deleted = 0");
            resetList();
            foreach (DataRow row in dt.Rows)
            {
                DataRow client_table = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE id = {Convert.ToInt32(row["client_id"])}").Rows[0];
                bool isDeleted = Convert.ToBoolean(client_table["is_deleted"]);
                string clientName = client_table["name"].ToString();
                clientName = isDeleted ? clientName + "(DELETED)" : clientName;
                string fluteType = sql.ExecuteQuery($"SELECT code_name FROM Flute_Table WHERE id = {Convert.ToInt32(row["flute_id"])}").Rows[0][0].ToString();
                decimal fluteValue =  Convert.ToDecimal(sql.ExecuteQuery($"SELECT _value FROM Flute_Table WHERE id = {Convert.ToInt32(row["flute_id"])}").Rows[0][0]);
                fluteValue = Convert.ToBoolean(row["isFolded"]) ? fluteValue * 2 : fluteValue;
                ViewPerItem_Form vpif = new ViewPerItem_Form(
                    clientName, row["item_name"].ToString(), Convert.ToDecimal(row["_length"]), Convert.ToDecimal(row["_width"]), fluteValue, fluteType, Convert.ToInt32(row["id"]), row["category"].ToString(), row["fc_control_number"].ToString(), this, isDeleted
                    );

                vpif.TopLevel = false;
                storedarea_flt.Controls.Add(vpif);
                vpif.Show();
                list.Add(vpif);
            }

            client_cb.Items.Clear();
            flutetype_cb.Items.Clear();
            client_cb.Items.Add("<select-client>");
            flutetype_cb.Items.Add("<select-flutetype>");

            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Flute_Table WHERE is_deleted = 0").Rows) flutetype_cb.Items.Add(row["code_name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0").Rows) client_cb.Items.Add(row["name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Item_Table WHERE is_deleted = 0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                CheckBox cb = new CheckBox();
                cb.Text = row["category"].ToString();
                cb.ForeColor = Color.White;
                cb.AutoSize = true;
                cb.Padding = new Padding(20, 0, 0, 0);
                flowLayoutPanel1.Controls.Add(cb);
                categ_list.Add(cb);
                cb.Show();
                cb.CheckedChanged += this.check;
            }
            resetFilter();
        }

        private void check(object sender, EventArgs e)
        {
            foreach(CheckBox c in categ_list)
            {
                if (sender is CheckBox cb) if (cb == c) continue;
                c.Checked = false;
            }
            setFilter();
        }
        private void resetList()
        {
            foreach (ViewPerItem_Form form in list) form.Dispose();
            foreach (Control c in categ_list) c.Dispose();
            list.Clear();
            categ_list.Clear();
        }

        private void resetFilter()
        {
            client_cb.SelectedIndex = 0;
            flutetype_cb.SelectedIndex = 0;
            searchname_tb.Text = "ex. Piatos Small";
            searchname_tb.ForeColor = Color.Gray;
            setFilter();
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
        private void setFilter()
        {
            FilterInputSupportClass filter = new FilterInputSupportClass();
            foreach (ViewPerItem_Form f in list)
            {
                bool isNameApplicable = searchname_tb.Text == "ex. Piatos Small" || string.IsNullOrEmpty(searchname_tb.Text) || filter.ContainsSimilarSubstring(f.itemname, searchname_tb.Text);
                bool isClientApplicable = client_cb.SelectedItem == "<select-client>" || client_cb.SelectedItem == "" || filter.ContainsSimilarSubstring(f.clientname, client_cb.Text);
                bool isFluteApplicable = flutetype_cb.SelectedItem == "<select-flutetype>" || flutetype_cb.SelectedItem == "" || filter.ContainsSimilarSubstring(f.flutecode, flutetype_cb.Text);
                bool category = isAllUnchecked() || getCheckboxName() == f.category;
                f.Visible = isClientApplicable && isFluteApplicable && isNameApplicable && category;
            }
            _NoResult();
        }

        private void tablelayout_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }




        private void ManageItems_form_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void flutetype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void manageflute_btn_Click(object sender, EventArgs e)
        {
            ManageFlute_WindowPopupForm mfwpuf = new ManageFlute_WindowPopupForm();
            mfwpuf.ShowDialog();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddNewItems_WindowPopUpForm aniwpuf = new AddNewItems_WindowPopUpForm(this);
            aniwpuf.ShowDialog();
        }

        private void client_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void searchname_tb_TextChanged(object sender, EventArgs e)
        {
            setFilter();
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
            int _noresult = 0;
            foreach (ViewPerItem_Form f in list) _noresult += f.Visible ? 1 : 0;
            _noresult = Math.Min(_noresult, list.Count);
            _no_result.Visible = _noresult < 1;
            label1.Visible = categ_list.Count > 0;
        }
    }
}
