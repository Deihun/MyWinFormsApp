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

namespace MyWinFormsApp.Sections.ManageItems
{
    public partial class AddNewItems_WindowPopUpForm : Form
    {
        private ManageItems_form parent;
        private main_startup_form mainparent;
        private FilterInputSupportClass filter = new FilterInputSupportClass();
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);

        private int id = -1;

        private string category = "";

        public AddNewItems_WindowPopUpForm(ManageItems_form parent, main_startup_form mainparent)
        {
            InitializeComponent();
            initializeChoices();
            this.mainparent = mainparent;
            this.parent = parent;
            updateWarnings();
        }

        public AddNewItems_WindowPopUpForm(ManageItems_form parent, int id, main_startup_form mainparent)
        {
            InitializeComponent();
            initializeChoices();
            client_cb.DropDownStyle = ComboBoxStyle.DropDown;
            this.mainparent = mainparent;
            this.parent = parent;
            this.id = id;

            DataRow row = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE id = {id}").Rows[0];
            set_category(row["category"].ToString());
            itemdescription_rtb.Text = row["item_name"].ToString();
            length_tb.Text = row["_length"].ToString();
            width_tb.Text = row["_width"].ToString();
            fccontrol_tb.Text = row["fc_control_number"].ToString();
            fold_rb.Checked = Convert.ToBoolean(row["isFolded"]);
            button1.Text = "CONFIRM && COPY";

            int clientID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Client_Table WHERE id = {Convert.ToInt32(row["client_id"])}").Rows[0][0]);
            int fluteID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Flute_Table WHERE id = {Convert.ToInt32(row["flute_id"])}").Rows[0][0]);

            client_cb.Text = sql.ExecuteQuery($"SELECT name FROM Client_Table WHERE id = {clientID}").Rows[0][0].ToString();
            flutetype_cb.Text = sql.ExecuteQuery($"SELECT code_name FROM Flute_Table WHERE id = {fluteID}").Rows[0][0].ToString();

            this.add_btn.Text = "CONFIRM CHANGES";
            this.Text = "EDIT ITEM";
            this.itemdescription_rtb.Enabled = false;

            client_cb.DropDownStyle = ComboBoxStyle.DropDownList;
            updateWarnings();
        }

        private void initializeChoices()
        {
            DataTable dtFlute = sql.ExecuteQuery("SELECT * FROM Flute_Table WHERE is_deleted = 0");
            DataTable dtClient = sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0");

            foreach (DataRow row in dtFlute.Rows) flutetype_cb.Items.Add(row["code_name"].ToString());
            foreach (DataRow row in dtClient.Rows) client_cb.Items.Add(row["name"].ToString());
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            bool dispose = false;
            if (id == -1) dispose = addItem();
            else dispose = rewriteItem();
            if (dispose)
            {
                this.parent.resetFilter();
                this.parent.updatePageSelection();
                this.parent.TriggerVisualUpdate();
                this.parent.updatePageSelection();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool containsSameName()
        {
            foreach (DataRow row in sql.ExecuteQuery("SELECT item_name FROM Item_Table WHERE is_deleted = 0").Rows) if (row["item_name"].ToString() == itemdescription_rtb.Text) return true;
            return false;
        }

        private int getClientID()
        {
            DataRow rowClient = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE name = '{client_cb.Text}';").Rows[0];
            return Convert.ToInt32(rowClient["id"]);
        }

        private int getFluteID()
        {
            DataRow rowFlute = sql.ExecuteQuery($"SELECT * FROM Flute_Table WHERE code_name = '{flutetype_cb.Text}';").Rows[0];
            return Convert.ToInt32(rowFlute["id"]);
        }

        private bool addItem(bool dispose = true)//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            if (!filter.AreAllInputsFilled(itemdescription_rtb, client_cb, flutetype_cb, length_tb, width_tb, fccontrol_tb))
            {
                MessageBox.Show("Please input all required empty spaces or avoid using existing name that is already added");
                return false;
            }
            DataRow rowClient = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE name = '{client_cb.Text}';").Rows[0];
            if (containsSameName())
            {
                MessageBox.Show("Item Name is already taken. Please use a non existing Item name or make it not exactly the same with other existing one.");
                return false;
            }



            Dictionary<string, object> value = new Dictionary<string, object>()
            {

                {"item_name", filter.RemoveSQLInjectionRisks(itemdescription_rtb.Text)},
                {"_length", Convert.ToDecimal(length_tb.Text) },
                {"_width", Convert.ToDecimal(width_tb.Text) },
                {"client_id", getClientID() },
                {"flute_id", getFluteID() },
                {"category", category},
                {"isFolded", fold_rb.Checked },
                {"fc_control_number", filter.RemoveSQLInjectionRisks(fccontrol_tb.Text) }
            };

            sql.InsertData("Item_Table", value);
            sql.commitReport($"A new data Item '{itemdescription_rtb.Text}' was added");
            if (dispose) this.Dispose();
            return true;
        }

        private bool rewriteItem()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            if (filter.AreAllInputsFilled(itemdescription_rtb, client_cb, flutetype_cb, length_tb, width_tb, fccontrol_tb))
            {
                int dabool = fold_rb.Checked ? 1 : 0;
                string query = $"UPDATE Item_Table SET item_name = '{filter.RemoveSQLInjectionRisks(itemdescription_rtb.Text)}', fc_control_number = '{filter.RemoveSQLInjectionRisks(fccontrol_tb.Text)}', _length = {length_tb.Text}, _width = {width_tb.Text} " +
                    $", category = '{category}', client_id = {getClientID()}, flute_id = {getFluteID()}, isFolded = {dabool}  WHERE id = {id}";
                sql.ExecuteQuery(query);
                sql.commitReport($"A data Item '{itemdescription_rtb.Text}' was modified");
                return true;
            }
            else
            {
                MessageBox.Show("Please input all required empty spaces or avoid using existing name that is already added");
                return false;
            }

        }

        private void itemname_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void length_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(length_tb);
            updateWarnings();
        }

        private void width_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(width_tb);
            updateWarnings();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string a = itemdescription_rtb.Text;
            bool confirm = false;

            if (id == -1) confirm = addItem();
            else confirm = rewriteItem();
            if (confirm)
            {
                this.Dispose();
                mainparent.copyFromItem_To_Bundle(a);
            }
        }

        private void updateWarnings()
        {
            client_warning.Visible = client_cb.Text == string.Empty;
            itemdescription_warning.Visible = itemdescription_rtb.Text == string.Empty;
            fcControl_warning.Visible = fccontrol_tb.Text == string.Empty;
            flute_warning.Visible = flutetype_cb.Text == string.Empty;
            length_warning.Visible = length_tb.Text == string.Empty;
            width_warning.Visible = width_tb.Text == string.Empty;
        }

        private void itemdescription_rtb_TextChanged(object sender, EventArgs e)
        {
            updateWarnings();
        }

        private void client_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateWarnings();
        }

        private void fccontrol_tb_TextChanged(object sender, EventArgs e)
        {
            updateWarnings();
        }

        private void flutetype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateWarnings();
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

        private void editcategory_btn_Click(object sender, EventArgs e)
        {
            List<string> list_of_category = new List<string>();
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Item_Table WHERE is_deleted = 0;").Rows) list_of_category.Add(row["category"].ToString());
            ListSelector ls = new ListSelector(set_category, reset_category, list_of_category);
            ls.ShowDialog();
        }
    }
}
