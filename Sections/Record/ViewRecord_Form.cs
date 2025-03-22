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
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        //<LIST>
        private List<ViewRecordSelection_Form> viewrecordselection_form_list = new List<ViewRecordSelection_Form>();
        private List<string> yearDate = new List<string>();
        public ViewRecord_Form()
        {
            InitializeComponent();
            _no_result.Visible = false;
        }



        //** VISUAL CHANGES METHODS
        public void UpdateVisuals()//MODIFY THIS METHOD WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            yearDate.Clear();
            foreach (Form f in viewrecordselection_form_list) f.Dispose();
            viewrecordselection_form_list.Clear();
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Record_Table WHERE is_deleted = 0;").Rows)
            {
                ViewRecordSelection_Form form = new ViewRecordSelection_Form(Convert.ToInt32(row["id"]), this);
                form.TopLevel = false;
                storedarea_flt.Controls.Add(form);
                viewrecordselection_form_list.Add(form);
                form.Show();
            }
            foreach (ViewRecordSelection_Form f in viewrecordselection_form_list) yearDate.Add(f.datecreated.Year.ToString());
            yearDate = yearDate.Distinct().ToList();

            year_cb.Items.Clear();
            client_cb.Items.Clear();
            truck_cb.Items.Clear();
            year_cb.Items.Add("<year>");
            client_cb.Items.Add("<select-client>");
            truck_cb.Items.Add("<select-truck>");

            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0").Rows) client_cb.Items.Add(row["name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Truck_Table WHERE is_deleted = 0").Rows) truck_cb.Items.Add(row["platenumber"].ToString());
            foreach (string s in yearDate) year_cb.Items.Add(s);

            resetFilter();
        }

        private void resetFilter()
        {
            searchname_tb.Text = "ex. Piatos";
            searchname_tb.ForeColor = Color.Gray;
            year_cb.SelectedIndex = 0;
            client_cb.SelectedIndex = 0;
            truck_cb.SelectedIndex = 0;
            month_cb.SelectedIndex = 0;
            setFilter();
        }
        private void setFilter()
        {
            Datetotext datetotext = new Datetotext();
            FilterInputSupportClass filter = new FilterInputSupportClass();
            foreach (ViewRecordSelection_Form f in viewrecordselection_form_list)
            {
                bool isNameAcceptable = searchname_tb.Text == "ex. Piatos" || string.IsNullOrEmpty(searchname_tb.Text) || f.containsItemName(searchname_tb.Text);
                bool isClientAcceptable = client_cb.SelectedItem == "<select-client>" || client_cb.Text == "" || f.containsClientName(client_cb.Text);
                bool isTruckType = truck_cb.SelectedItem == "<select-truck>" || truck_cb.Text == "" || f.containsTruck(truck_cb.Text);
                bool isMonth = month_cb.SelectedItem == "<month>" || month_cb.Text == datetotext.getMonthAsShortText(f.datecreated);
                bool isYear = year_cb.SelectedItem == "<year>" || year_cb.Text == f.datecreated.Year.ToString();

                f.Visible = isClientAcceptable && isNameAcceptable && isTruckType && isMonth;
            }
            noResult();
        }


        // ** CONTROL EVENTS
        private void ViewRecord_Form_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisuals();
        }

        private void searchname_tb_TextChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void client_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void truck_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
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
        }

        private void month_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
        }

        private void year_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            setFilter();
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
