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
            this.parent = parent;
            this.id = id;

            DataRow row = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE id = {id}").Rows[0];
            itemname_tb.Text = row["item_name"].ToString();
            length_tb.Text = row["_length"].ToString();
            width_tb.Text = row["_width"].ToString();

            int clientID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Client_Table WHERE id = {Convert.ToInt32(row["client_id"])}").Rows[0][0]);
            int fluteID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Flute_Table WHERE id = {Convert.ToInt32(row["flute_id"])}").Rows[0][0]);

            client_cb.Text = sql.ExecuteQuery($"SELECT name FROM Client_Table WHERE id = {clientID}").Rows[0][0].ToString();
            flutetype_cb.Text = sql.ExecuteQuery($"SELECT code_name FROM Flute_Table WHERE id = {fluteID}").Rows[0][0].ToString();
        }

        private void initializeChoices()
        {
            DataTable dtFlute = sql.ExecuteQuery("SELECT * FROM Flute_Table");
            DataTable dtClient = sql.ExecuteQuery("SELECT * FROM Client_Table");
            
            foreach (DataRow row in dtFlute.Rows)flutetype_cb.Items.Add(row["code_name"].ToString());
            foreach (DataRow row in dtClient.Rows) client_cb.Items.Add(row["name"].ToString());
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (id == -1) addItem();
            else rewriteItem();
            parent.UpdateVisual();
            this.Dispose();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void addItem()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            DataRow rowFlute = sql.ExecuteQuery($"SELECT * FROM Flute_Table WHERE code_name = '{flutetype_cb.Text}';").Rows[0];
            DataRow rowClient = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE name = '{client_cb.Text}';").Rows[0];
            int FluteID = Convert.ToInt32(rowFlute["id"]);
            int clientID = Convert.ToInt32(rowClient["id"]);

            

            Dictionary<string, object> value = new Dictionary<string, object>()
            {

                {"item_name", itemname_tb.Text },
                {"_length", Convert.ToDecimal(length_tb.Text) },
                {"_width", Convert.ToDecimal(width_tb.Text) },
                {"client_id", clientID },
                {"flute_id", FluteID }
            };

            sql.InsertData("Item_Table", value);
        }

        private void rewriteItem()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {

        }
    }
}
