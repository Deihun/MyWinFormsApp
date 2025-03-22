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
        ManageItems_form parent;
        FilterInputSupportClass filter = new FilterInputSupportClass();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        int id = -1;
        public AddNewItems_WindowPopUpForm(ManageItems_form parent)
        {
            InitializeComponent();
            initializeChoices();
            this.parent = parent;
        }

        public AddNewItems_WindowPopUpForm(ManageItems_form parent, int id)
        {
            InitializeComponent();
            initializeChoices();
            client_cb.DropDownStyle = ComboBoxStyle.DropDown;
            this.parent = parent;
            this.id = id;

            DataRow row = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE id = {id}").Rows[0];
            category_checkbox.Checked = !string.IsNullOrEmpty(row["category"].ToString());
            if (category_checkbox.Checked)category_cb.Text = row["category"].ToString();
            itemdescription_rtb.Text = row["item_name"].ToString();
            length_tb.Text = row["_length"].ToString();
            width_tb.Text = row["_width"].ToString();
            fccontrol_tb.Text = row["fc_control_number"].ToString();
            fold_rb.Checked = Convert.ToBoolean(row["isFolded"]);


            int clientID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Client_Table WHERE id = {Convert.ToInt32(row["client_id"])}").Rows[0][0]);
            int fluteID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Flute_Table WHERE id = {Convert.ToInt32(row["flute_id"])}").Rows[0][0]);

            client_cb.Text = sql.ExecuteQuery($"SELECT name FROM Client_Table WHERE id = {clientID}").Rows[0][0].ToString();
            flutetype_cb.Text = sql.ExecuteQuery($"SELECT code_name FROM Flute_Table WHERE id = {fluteID}").Rows[0][0].ToString();

            this.add_btn.Text = "CONFIRM CHANGES";
            this.Text = "EDIT ITEM";
            this.itemdescription_rtb.Enabled = false;

            client_cb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void initializeChoices()
        {
            DataTable dtFlute = sql.ExecuteQuery("SELECT * FROM Flute_Table WHERE is_deleted = 0");
            DataTable dtClient = sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0");

            foreach (DataRow row in dtFlute.Rows) flutetype_cb.Items.Add(row["code_name"].ToString());
            foreach (DataRow row in dtClient.Rows) client_cb.Items.Add(row["name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Item_Table WHERE is_deleted = 0").Rows) category_cb.Items.Add(row["category"].ToString());
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
                if (id == -1) addItem();
                else rewriteItem();
                parent.UpdateVisual();
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

        private void addItem()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            if (!filter.AreAllInputsFilled(itemdescription_rtb, client_cb, flutetype_cb, length_tb, width_tb, fccontrol_tb))
            {
                MessageBox.Show("Please input all required empty spaces or avoid using existing name that is already added");
                return;
            }
                DataRow rowClient = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE name = '{client_cb.Text}';").Rows[0];
                if (containsSameName())
                {
                    MessageBox.Show("Item Name is already taken. Please use a non existing Item name or make it not exactly the same with other existing one.");
                    return;
                }

                string a = category_checkbox.Checked ? filter.RemoveSQLInjectionRisks(category_cb.Text) : "";

                Dictionary<string, object> value = new Dictionary<string, object>()
            {

                {"item_name", filter.RemoveSQLInjectionRisks(itemdescription_rtb.Text)},
                {"_length", Convert.ToDecimal(length_tb.Text) },
                {"_width", Convert.ToDecimal(width_tb.Text) },
                {"client_id", getClientID() },
                {"flute_id", getFluteID() },
                {"category", a},
                {"isFolded", fold_rb.Checked },
                {"fc_control_number", filter.RemoveSQLInjectionRisks(fccontrol_tb.Text) }
            };

                sql.InsertData("Item_Table", value);
                sql.commitReport($"A new data Item '{itemdescription_rtb.Text}' was added");
            this.Dispose();
        }

        private void rewriteItem()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            if (!filter.AreAllInputsFilled(itemdescription_rtb, client_cb, flutetype_cb, length_tb, width_tb, fccontrol_tb))
            {
                int dabool = fold_rb.Checked ? 1 : 0;
                string query = $"UPDATE Item_Table SET item_name = '{filter.RemoveSQLInjectionRisks(itemdescription_rtb.Text)}', fc_control_number = '{filter.RemoveSQLInjectionRisks(fccontrol_tb.Text)}', _length = {length_tb.Text}, _width = {width_tb.Text} " +
                    $", category = '{category_cb.Text}', client_id = {getClientID()}, flute_id = {getFluteID()}, isFolded = {dabool}  WHERE id = {id}";
                sql.ExecuteQuery(query);
                sql.commitReport($"A data Item '{itemdescription_rtb.Text}' was modified");
            }
            else MessageBox.Show("Please input all required empty spaces or avoid using existing name that is already added");
            this.Dispose();
        }

        private void itemname_tb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void length_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(length_tb);
        }

        private void width_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(width_tb);
        }

        private void category_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            category_cb.Enabled = category_checkbox.Checked;
        }
    }
}
