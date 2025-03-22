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
        Scalingsupport scale = new Scalingsupport();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        List<viewSelectedBundle_Form> list = new List<viewSelectedBundle_Form>();
        List<CheckBox> categ_list = new List<CheckBox>();
        public ManageBundles_Form()
        {
            InitializeComponent();
        }

        private void flutetype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        public void UpdateVisual()
        {
            resetList();
            client_cb.Size = scale.ScaleObject(client_cb.Size);
            flutetype_cb.Size = scale.ScaleObject(flutetype_cb.Size);
            client_cb.Size = scale.ScaleObject(client_cb.Size);

            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Bundle_Table WHERE is_deleted = 0;").Rows)
            {
                viewSelectedBundle_Form vsbf = new viewSelectedBundle_Form(this, Convert.ToInt32(row["id"]));
                vsbf.TopLevel = false;
                storedarea_flt.Controls.Add(vsbf);
                vsbf.Show();
                list.Add(vsbf);
            }

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
                check.AutoSize = true;
                check.ForeColor = Color.White;
                flowLayoutPanel1.Controls.Add(check);
                categ_list.Add(check);
                check.Padding = new Padding(20, 0, 0, 0);
                check.Show();
                check.CheckedChanged += this.check;
            }
            resetFilter();
        }

        private void check(object sender, EventArgs e)
        {
            foreach (CheckBox c in categ_list)
            {
                if (sender is CheckBox cb) if (cb == c) continue;
                c.Checked = false;
            }
            setFilter();
        }

        private void resetList()
        {
            foreach (viewSelectedBundle_Form form in list) form.Dispose();
            foreach (Control c in categ_list) c.Dispose();
            categ_list.Clear();
            list.Clear();
        }
        private void resetFilter()
        {
            searchname_tb.Text = "ex. Piattos Small";
            searchname_tb.ForeColor = Color.Gray;
            client_cb.SelectedIndex = 0;
            flutetype_cb.SelectedIndex = 0;
            setFilter();
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
        private void setFilter()
        {
            FilterInputSupportClass filter = new FilterInputSupportClass();
            foreach (viewSelectedBundle_Form f in list)
            {
                bool isNameApplicable = searchname_tb.Text == "ex. Piattos Small" || string.IsNullOrEmpty(searchname_tb.Text) || filter.ContainsSimilarSubstring(f.itemname, searchname_tb.Text);
                bool isClientApplicable = client_cb.SelectedItem == "<select-client>" || client_cb.SelectedItem == "" || filter.ContainsSimilarSubstring(f.clientname, client_cb.Text);
                bool isFluteApplicable = flutetype_cb.SelectedItem == "<select-flutetype>" || flutetype_cb.SelectedItem == "" || filter.ContainsSimilarSubstring(f.flutetype, flutetype_cb.Text);
                bool category = isAllUnchecked() || getCheckboxName() == f.category;
                f.Visible = isClientApplicable && isNameApplicable && isFluteApplicable && category;
            }
            noresult();
        }


        private void ManageBundles_Form_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddEditBundle_windowpopupform aebwpuf = new AddEditBundle_windowpopupform(this);
            aebwpuf.ShowDialog();
        }

        private void searchname_tb_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void client_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
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
        }

        private void noresult()
        {
            int a = 0;
            foreach (viewSelectedBundle_Form f in list) a += f.Visible ? 1 : 0;
            a = Math.Min(a, list.Count);
            _no_result.Visible = a < 1;
            label1.Visible = categ_list.Count > 0;
        }
    }
}
