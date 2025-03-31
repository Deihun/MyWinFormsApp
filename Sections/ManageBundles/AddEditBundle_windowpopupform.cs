using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp.Sections.ManageBundles
{
    public partial class AddEditBundle_windowpopupform : Form //INCOMPLETE, ADD DETAILS WHEN SELECTING A SPECIFIC COMBOBOX ITEM ON DETAIL LABELS
    {
        private ManageBundles_Form parent;
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);

        private int id = -1;

        private string category = "";
        public AddEditBundle_windowpopupform(ManageBundles_Form parent)
        {
            InitializeComponent();
            instantiateCB();
            this.parent = parent;
            updateWarning();
        }

        public AddEditBundle_windowpopupform(ManageBundles_Form parent, string item_name)
        {
            InitializeComponent();
            instantiateCB();
            this.parent = parent;

            try
            {
                itemlist_cb.SelectedItem = item_name;
            }
            catch
            {
                itemlist_cb.Items.Add(item_name);
                itemlist_cb.SelectedItem = item_name;
            }
            updateWarning();

        }
        public AddEditBundle_windowpopupform(ManageBundles_Form parent, int id)
        {
            InitializeComponent();
            instantiateCB();
            this.parent = parent;
            this.id = id;
            this.Text = "EDIT BUNDLE";
            this.add_btn.Text = "CONFIRM CHANGES";

            DataRow bundleRow = sql.ExecuteQuery($"SELECT * FROM Bundle_Table WHERE id = {id}").Rows[0];
            quantity_tb.Text = bundleRow["quantity"].ToString();
            itemlist_cb.Text = sql.ExecuteQuery($"SELECT item_name FROM Item_Table WHERE id = {Convert.ToInt32(bundleRow["item_id"])}").Rows[0][0].ToString();
            set_category(bundleRow["category"].ToString());
            updateWarning();

        }
        private void instantiateCB()
        {
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT item_name FROM Item_Table WHERE is_deleted = 0").Rows) itemlist_cb.Items.Add(row["item_name"].ToString());
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (itemlist_cb.Text != string.Empty && (quantity_tb.Text != string.Empty || quantity_tb.Text != "0"))
            {
                if (id == -1) AddBundle();
                else rewriteBundle();
                parent.resetFilter();
                parent.updatePageSelector();
                parent.TriggerVisualUpdate();
                parent.updatePageSelector();
                this.Dispose();
            }
            else MessageBox.Show("Please Fill up all the occupied space");
        }

        private void AddBundle() //MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            FilterInputSupportClass filter = new FilterInputSupportClass();
            int itemID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Item_Table WHERE item_name = '{itemlist_cb.Text}';").Rows[0][0]);
            Dictionary<string, object> value = new Dictionary<string, object>()
            {
                {"quantity", Convert.ToInt32(quantity_tb.Text) },
                {"item_id", itemID },
                {"category", category }
            };
            sql.InsertData("Bundle_Table", value);
            sql.commitReport($"A new Data Bundle '{itemlist_cb.Text}' was added");
        }
        private void rewriteBundle()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            int itemID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Item_Table WHERE item_name = '{itemlist_cb.Text}';").Rows[0][0]);
            string query = $"UPDATE Bundle_Table SET quantity = {quantity_tb.Text}, item_id = {itemID}, category = '{category}' WHERE id = {id}";
            sql.ExecuteQuery(query);
            sql.commitReport($"A Data Bundle '{itemlist_cb.Text}' was modified");
        }

        private void itemlist_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow row = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE item_name = '{itemlist_cb.Text}' AND is_deleted = 0").Rows[0];
            DataRow fluterow = sql.ExecuteQuery($"SELECT * FROM Flute_Table WHERE id = {row["flute_id"]}").Rows[0];
            decimal height = Convert.ToDecimal(fluterow["_value"]);
            height = Convert.ToBoolean(row["isFolded"]) ? height * 2 : height;
            details_label.ForeColor = Color.Black;
            details_label.Location = new Point(20, 93);
            details_label.Text = $"Length(mm): {row["_length"]}\n" +
                                 $"Width(mm) :{row["_width"]}\n" +
                                 $"Height(mm) :{height}\n" +
                                 $"FluteType: {fluterow["code_name"]}";
            updateWarning();
        }


        private void updateWarning()
        {
            item_warning.Visible = itemlist_cb.Text == string.Empty;
            quantity_warning.Visible = quantity_tb.Text == string.Empty;
        }

        private void quantity_tb_TextChanged(object sender, EventArgs e)
        {
            FilterInputSupportClass filter = new FilterInputSupportClass();
            filter.ValidateNumericInput(quantity_tb);
            quantity_tb.Text = quantity_tb.Text.Replace(".", "");
            updateWarning();
            ;
        }

        private void AddEditBundle_windowpopupform_Load(object sender, EventArgs e)
        {

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
