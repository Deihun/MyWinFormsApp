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
        List<ExistingSelectClient_form> list = new List<ExistingSelectClient_form>();
        List<CheckBox> checkbox_list = new List<CheckBox>();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        public ManageClient_Form()
        {
            InitializeComponent();
            UpdateVisual();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddNewClient_WindowPopupForm ancwpf = new AddNewClient_WindowPopupForm(this);
            ancwpf.ShowDialog();
        }

        public void UpdateVisual()
        {
            resetList();
            DataTable datatable = sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0;");
            foreach (DataRow row in datatable.Rows)
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
            }
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Client_Table WHERE is_deleted = 0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                CheckBox checkbox = new CheckBox();
                checkbox.Text = row["category"].ToString();
                checkbox.ForeColor = Color.White;
                checkbox.AutoSize = true;
                checkbox.Padding = new Padding(20, 0, 0, 0);
                flowLayoutPanel1.Controls.Add(checkbox);
                checkbox_list.Add(checkbox);
                checkbox.CheckedChanged += checkboxcheck;
                checkbox.Show();
            }
            resetFilter();
        }
        private void checkboxcheck(object sender, EventArgs e)
        {
            foreach (CheckBox c in checkbox_list) 
            { 
                if (sender is CheckBox cb) if (cb == c)continue;
                c.Checked = false;
            }
            setFilter();
        }
        private void resetList()
        {
            foreach (ExistingSelectClient_form form in list) form.Dispose();
            foreach (Control c in checkbox_list) c.Dispose();
            checkbox_list.Clear();
            list.Clear();
        }

        private void resetFilter()
        {
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
            setFilter();
        }

        private void ManageClient_Form_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisual();
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
    }
}
