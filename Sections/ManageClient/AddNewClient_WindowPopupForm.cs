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
        private ManageClient_Form parent;
        private RequirementsManagement_class req;
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private FilterInputSupportClass filter = new FilterInputSupportClass();

        private int ID = -1;

        private string category = "";
        public AddNewClient_WindowPopupForm(ManageClient_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            setupRequirementManager();
            updatewarnings();
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
            set_category(row["category"].ToString());
            setCheckmarks(row["filter"].ToString());
            setupRequirementManager();
            clientname_tb.Enabled = false;
            updatewarnings();
        }

        private void setupRequirementManager()
        {
            req = new RequirementsManagement_class(requirepallet_cb, requireclearancespace_cb);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            req = new RequirementsManagement_class(requirepallet_cb, requireclearancespace_cb);

            if (ID == -1) add_client();
            else rewrite_client();
            this.parent.resetFilter();
            this.parent.TriggerVisualUpdate();
            this.parent.updatePageSelector();
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
            Dictionary<string, object> value = new Dictionary<string, object>()
            {
                { "name", clientname_tb.Text },
                {"description", description_rtb.Text },
                {"filter", req.getCheckmarks() },
                {"category", category}
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
            string query = $"UPDATE Client_Table SET name = '{clientname_tb.Text}', description = '{description_rtb.Text}', category = '{category}', filter = '{req.getCheckmarks()}'  WHERE id = {ID}";
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
            updatewarnings();
        }

        private void description_rtb_TextChanged(object sender, EventArgs e)
        {
            description_rtb.Text = description_rtb.Text.Replace("`", "");
            description_rtb.SelectionStart = description_rtb.Text.Length;
            updatewarnings();
        }


        private void updatewarnings()
        {
            description_warning.Visible = description_rtb.Text == string.Empty;
            name_warning.Visible = clientname_tb.Text == string.Empty;
        }

        private void editcategory_btn_Click(object sender, EventArgs e)
        {
            List<string> list_of_category = new List<string>();
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Truck_Table WHERE is_deleted = 0;").Rows) list_of_category.Add(row["category"].ToString());
            ListSelector ls = new ListSelector(set_category, reset_category, list_of_category);
            ls.ShowDialog();
        }
        private void reset_category()
        {
            this.category = "";
            this.category_path.Text = "No Category";
        }
        private void set_category(string _category)
        {
            this.category = _category;
            this.category_path.Text = _category;
        }
    }
}
