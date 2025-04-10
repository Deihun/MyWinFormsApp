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
using TruckEstimation.Sections.ManageBundles;

namespace MyWinFormsApp.Sections.ManageBundles
{
    public partial class AddEditBundle_windowpopupform : Form //INCOMPLETE, ADD DETAILS WHEN SELECTING A SPECIFIC COMBOBOX ITEM ON DETAIL LABELS
    {
        private ManageBundles_Form parent;
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);

        private int id = -1;
        private int item_id = -1;

        private string category = "";

        public AddEditBundle_windowpopupform(int id, bool a)
        {
            InitializeComponent();
            set_item(id);
            updateWarning();
        }

        public AddEditBundle_windowpopupform(ManageBundles_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            updateWarning();
        }
        public void set_item(int id)
        {
            this.item_id = id;
            pathItem_label.Text = sql.ExecuteQuery($"SELECT item_name FROM Item_Table WHERE id = {id}").Rows[0][0].ToString();
        }

        public AddEditBundle_windowpopupform(ManageBundles_Form parent, int id, bool a)
        {
            InitializeComponent();
            this.parent = parent;
            set_item(id);
            updateWarning();
        }
        public AddEditBundle_windowpopupform(ManageBundles_Form parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.id = id;
            this.Text = "EDIT BUNDLE";
            this.add_btn.Text = "CONFIRM CHANGES";

            DataRow Content = sql.ExecuteQuery($"SELECT bundle.quantity, bundle.category, item.item_name, item.id FROM Item_Table item JOIN Bundle_Table bundle ON bundle.item_id = item.id WHERE bundle.id = {id}").Rows[0];
            set_item(Convert.ToInt32(Content["id"]));
            quantity_tb.Text = Content["quantity"].ToString();
            set_category(Content["category"].ToString());
            updateWarning();

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (item_id != -1 && (quantity_tb.Text != string.Empty || quantity_tb.Text != "0"))
            {
                if (id == -1) AddBundle();
                else rewriteBundle();
                try
                {
                    parent.resetFilter();
                    parent.updatePageSelector();
                    parent.TriggerVisualUpdate();
                    parent.updatePageSelector();
                } catch { }

                this.Dispose();
            }
            else MessageBox.Show("Please Fill up all the occupied space");
        }

        private void AddBundle() //MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            FilterInputSupportClass filter = new FilterInputSupportClass();
            Dictionary<string, object> value = new Dictionary<string, object>()
            {
                {"quantity", Convert.ToInt32(quantity_tb.Text) },
                {"item_id", item_id },
                {"category", category }
            };
            sql.InsertData("Bundle_Table", value);
            sql.commitReport($"A new Data Bundle '{pathItem_label.Text}' was added");
        }
        private void rewriteBundle()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            int itemID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Item_Table WHERE item_name = '{pathItem_label.Text}';").Rows[0][0]);
            string query = $"UPDATE Bundle_Table SET quantity = {quantity_tb.Text}, item_id = {itemID}, category = '{category}' WHERE id = {id}";
            sql.ExecuteQuery(query);
            sql.commitReport($"A Data Bundle '{pathItem_label.Text}' was modified");
        }

        private void itemlist_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow row = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE item_name = '{pathItem_label.Text}' AND is_deleted = 0").Rows[0];
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
            item_warning.Visible = item_id == -1;
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

        private void itemEdit_btn_Click(object sender, EventArgs e)
        {
            Dictionary<int, string> items = new Dictionary<int, string>();
            foreach (DataRow row in sql.ExecuteQuery("SELECT item_name, id FROM Item_Table WHERE is_deleted = 0").Rows) items.Add(Convert.ToInt32(row["id"]), row["item_name"].ToString());
            SelectItem_FromBundle_Form sfbf = new SelectItem_FromBundle_Form(items, set_item);
            sfbf.ShowDialog();
        }

        private void pathItem_label_TextChanged(object sender, EventArgs e)
        {
            item_warning.Visible = item_id == -1;
        }
    }
}
