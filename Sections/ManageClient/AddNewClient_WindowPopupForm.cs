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

        private List<CheckBox> cb_list = new List<CheckBox>();

        private string category = "";
        public AddNewClient_WindowPopupForm(ManageClient_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            updatewarnings();
            instantiate_checkbox();
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

            clientname_tb.Enabled = false;
            updatewarnings();
            instantiate_checkbox();
            check_rules_existing();
        }

        private CheckBox create_checkbox(string name)
        {
            CheckBox check = new CheckBox();
            check.Text = name;
            check.AutoSize = true;
            cb_list.Add(check);
            flowLayoutPanel1.Controls.Add(check);
            check.Show();
            return check;
        }

        private void instantiate_checkbox()
        {
            foreach (DataRow row in sql.ExecuteQuery("SELECT rules FROM client_rules").Rows)
            {
                if (string.IsNullOrEmpty(row["rules"].ToString())) continue;
                create_checkbox(row["rules"].ToString());
            }
        }

        private void check_rules_existing()
        {
           
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (ID == -1) add_client();
            else rewrite_client();
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
                {"filter", get_filter() },
                {"category", category}
            };
            sql.InsertData("Client_Table", value);
            sql.commitReport($"A new Data Client '{clientname_tb.Text}' was added");
            parent.TriggerVisualUpdate();
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
            parent.TriggerVisualUpdate();
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

        private string get_filter()
        {
            List<string> rules_per_checkbox = new List<string>();
            foreach (CheckBox c in cb_list)
            {
                if (c.Checked)rules_per_checkbox.Add(c.Text);
            }
            rules_per_checkbox = rules_per_checkbox.Distinct().ToList();
            return $"({string.Join("%", rules_per_checkbox)})";
        }
    }
}
