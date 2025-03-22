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
    public partial class AddNewClient_WindowPopupForm : Form
    {
        int ID = -1;
        ManageClient_Form parent;
        RequirementsManagement_class req;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        FilterInputSupportClass filter = new FilterInputSupportClass();
        public AddNewClient_WindowPopupForm(ManageClient_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            setupRequirementManager();
        }

        public AddNewClient_WindowPopupForm(ManageClient_Form parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.ID = id;

            this.Text = "EDIT CLIENT";
            this.add_btn.Text = "CONFIRM CHANGES";

            DataRow row = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE id = {ID}").Rows[0];
            clientname_tb.Text = row["name"].ToString();
            description_rtb.Text = row["description"].ToString();
            category_checkbox.Checked = !string.IsNullOrEmpty(row["category"].ToString());
            if (category_checkbox.Checked) category_cb.Text = row["category"].ToString();
            setCheckmarks(row["filter"].ToString());
            setupRequirementManager();
            clientname_tb.Enabled = false;
        }

        private void setupRequirementManager()
        {
            req = new RequirementsManagement_class(requirepallet_cb, requireclearancespace_cb);
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Client_Table").Rows) category_cb.Items.Add(row[0].ToString());
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            req = new RequirementsManagement_class(requirepallet_cb, requireclearancespace_cb);

            if (ID == -1) add_client();
            else rewrite_client();
            parent.UpdateVisual();
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool containsSameName()
        {
            foreach (DataRow row in sql.ExecuteQuery("SELECT name FROM Client_Table WHERE is_deleted = 0").Rows) if (row["name"].ToString() == clientname_tb.Text) return true;
            return false;
        }
        private void add_client() //MODIFY THIS WHEN INTEGRATING FROM LOCAL TO CONNECTED DB
        {
            if (!(filter.AreAllInputsFilled(clientname_tb, description_rtb) && !sql.DoesDataExist("Client_Table", "name", clientname_tb.Text)))
            {
                MessageBox.Show("Please fill up all the empty spaces or avoid using exactly the same name of Client that is already added");
                return;
            }
            if (containsSameName())
            {
                MessageBox.Show("Client name is already taken. Please use a non existing Client name or make it not exactly the same with other existing one.");
                return;
            }
            string a = category_checkbox.Checked ? filter.RemoveSQLInjectionRisks(category_cb.Text) : "";
            Dictionary<string, object> value = new Dictionary<string, object>()
            {
                { "name", clientname_tb.Text },
                {"description", description_rtb.Text },
                {"filter", req.getCheckmarks() },
                {"category", a }
            };
            sql.InsertData("Client_Table", value);
            sql.commitReport($"A new Data Client '{clientname_tb.Text}' was added");
            this.Dispose();
        }
        private void rewrite_client()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO CONNECTED DB
        {
            if (!(filter.AreAllInputsFilled(clientname_tb, description_rtb)))
            {
                MessageBox.Show("Please fill up all the empty spaces");
                return;
            }
            string a = category_checkbox.Checked ? filter.RemoveSQLInjectionRisks(category_cb.Text) : "";
            string query = $"UPDATE Client_Table SET name = '{clientname_tb.Text}', description = '{description_rtb.Text}', category = '{a}', filter = '{req.getCheckmarks()}'  WHERE id = {ID}";
            sql.ExecuteQuery(query);

            sql.commitReport($"A Data Client '{clientname_tb.Text}' was modified");
            this.Dispose();
        }




        private void setCheckmarks(string raw_data)
        {

        }

        private void clientname_tb_TextChanged(object sender, EventArgs e)
        {
            filter.SanitizeSQLInput(clientname_tb);
        }

        private void description_rtb_TextChanged(object sender, EventArgs e)
        {
            description_rtb.Text = description_rtb.Text.Replace("`", "");
            description_rtb.SelectionStart = description_rtb.Text.Length;
        }

        private void category_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            category_cb.Enabled = category_checkbox.Checked;
        }
    }
}
