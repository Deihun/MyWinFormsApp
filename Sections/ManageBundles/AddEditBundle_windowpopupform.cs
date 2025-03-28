﻿using MyWinFormsApp.SupportClass;
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
        ManageBundles_Form parent;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        int id = -1;
        public AddEditBundle_windowpopupform(ManageBundles_Form parent)
        {
            InitializeComponent();
            instantiateCB();
            this.parent = parent;
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
            category_checkbox.Checked = !string.IsNullOrEmpty(bundleRow["category"].ToString());
            if (category_checkbox.Checked) category_cb.Text = bundleRow["category"].ToString();

        }
        private void instantiateCB()
        {
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT item_name FROM Item_Table WHERE is_deleted = 0").Rows) itemlist_cb.Items.Add(row["item_name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Bundle_Table WHERE is_deleted = 0").Rows) category_cb.Items.Add(row["category"].ToString());
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
                parent.UpdateVisual();
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
                {"category", filter.RemoveSQLInjectionRisks(category_cb.Text.ToUpper()) }
            };
            sql.InsertData("Bundle_Table", value);
            sql.commitReport($"A new Data Bundle '{itemlist_cb.Text}' was added");
        }
        private void rewriteBundle()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            int itemID = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Item_Table WHERE item_name = '{itemlist_cb.Text}';").Rows[0][0]);
            string query = $"UPDATE Bundle_Table SET quantity = {quantity_tb.Text}, item_id = {itemID}, category = '{category_cb.Text}' WHERE id = {id}";
            sql.ExecuteQuery(query);
            sql.commitReport($"A Data Bundle '{itemlist_cb.Text}' was modified");
        }

        private void itemlist_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow row = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE item_name = '{itemlist_cb.Text}' AND is_deleted = 0").Rows[0];
            DataRow fluterow = sql.ExecuteQuery($"SELECT * FROM Flute_Table WHERE id = {row["flute_id"]}").Rows[0];
            decimal height = Convert.ToDecimal(fluterow["_value"]);
            height = Convert.ToBoolean(row["isFolded"]) ? height * 2: height;
            details_label.ForeColor = Color.Black;
            details_label.Location = new Point(20, 93);
            details_label.Text = $"Length(mm): {row["_length"]}\n" +
                                 $"Width(mm) :{row["_width"]}\n" +
                                 $"Height(mm) :{height}\n" +
                                 $"FluteType: {fluterow["code_name"]}";
        }

        private void category_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            category_cb.Enabled = category_checkbox.Checked;
        }
    }
}
