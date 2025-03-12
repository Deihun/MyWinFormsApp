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

namespace MyWinFormsApp.Sections.ManageBundles
{
    public partial class viewSelectedBundle_Form : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        ManageBundles_Form parent;
        int id;
        public viewSelectedBundle_Form(ManageBundles_Form parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.id = id;

            DataRow row = sql.ExecuteQuery($"SELECT item_id, quantity FROM Bundle_Table WHERE id = {id};").Rows[0];
            int itemID = Convert.ToInt32(row["item_id"]);
            int quantity = Convert.ToInt32(row["quantity"]);


            DataRow rowItem = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE id = {id}").Rows[0];
            DataRow rowFlute = sql.ExecuteQuery($"SELECT _value, code_name FROM Flute_Table WHERE id = {Convert.ToInt32(rowItem["flute_id"])}").Rows[0];
            decimal fluteValue = Convert.ToDecimal(rowFlute["_value"]);
            string FluteType = rowFlute["code_name"].ToString();

            itemname_label.Text = $"{rowItem["item_name"]}(BUNDLE)";
            content_label.Text = $"Quantity      : {quantity} pcs\n" +
                                 $"Length(mm)    : {Convert.ToInt32(rowItem["_length"]) * quantity}\n" +
                                 $"Width(mm)     : {Convert.ToInt32(rowItem["_width"]) * quantity}\n" +
                                 $"Height(mm)    : {fluteValue * quantity}\n" +
                                 $"Dimensions(mm): {(Convert.ToInt32(rowItem["_length"]) * quantity) * (Convert.ToInt32(rowItem["_width"]) * quantity) * (fluteValue * quantity)}";
            flutetype_label.Text = $"FluteType: ({FluteType})";
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DeleteMyValue();
            parent.UpdateVisual();
        }

        private void DeleteMyValue()
        {
            DialogResult result = MessageBox.Show(
                "Once this data is deleted, it can no longer be retrieve. Are you sure?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
            );

            if (result == DialogResult.Yes)
            {
                sql.ExecuteQuery($"DELETE FROM Bundle_Table WHERE id = {id}");
                parent.UpdateVisual();
            }
            else if (result == DialogResult.No)
            {
            }


        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddEditBundle_windowpopupform aebwpuf = new AddEditBundle_windowpopupform(parent, id);
            aebwpuf.ShowDialog();
        }
    }
}
