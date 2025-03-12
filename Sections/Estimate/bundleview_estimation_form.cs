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

namespace MyWinFormsApp.Sections.Estimate
{
    public partial class bundleview_estimation_form : Form
    {
        Estimate_Form parent;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        public bundleview_estimation_form(Estimate_Form parent)
        {
            InitializeComponent();
            this.parent = parent;

            bundleitem_combobox.SelectedIndex = 0;
            palletchoice_combobox.SelectedIndex = 0;
            initializeBundleCombobox();
        }


        private void updateContent()
        {
            content_label.ForeColor = Color.Black;
            if (bundleitem_combobox.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Item_Table WHERE item_name = '{bundleitem_combobox.Text}' ").Rows[0][0]);
                int bundleIT = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Bundle_Table WHERE item_id = '{id}' ").Rows[0][0]);
                DataRow row = sql.ExecuteQuery($"SELECT item_id, quantity FROM Bundle_Table WHERE id = {bundleIT};").Rows[0];
                int itemID = Convert.ToInt32(row["item_id"]);
                int quantity = Convert.ToInt32(row["quantity"]);


                DataRow rowItem = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE id = {id}").Rows[0];
                DataRow rowFlute = sql.ExecuteQuery($"SELECT _value, code_name FROM Flute_Table WHERE id = {Convert.ToInt32(rowItem["flute_id"])}").Rows[0];
                decimal fluteValue = Convert.ToDecimal(rowFlute["_value"]);
                string FluteType = rowFlute["code_name"].ToString();

                content_label.Text = $"Quantity      : {quantity} pcs\n" +
                                 $"Length(mm)    : {Convert.ToDecimal(rowItem["_length"]) * quantity}\n" +
                                 $"Width(mm)     : {Convert.ToDecimal(rowItem["_width"]) * quantity}\n" +
                                 $"Height(mm)    : {fluteValue * quantity}\n" +
                                 $"Dimensions(mm): {(Convert.ToDecimal(rowItem["_length"]) * quantity) * (Convert.ToDecimal(rowItem["_width"]) * quantity) * (fluteValue * quantity)}\n" +
                                 $"FluteType: ({FluteType})\n";
            }
            if (palletEnabler_checkbox.Checked && palletchoice_combobox.SelectedIndex != 0)
            {
                DataRow row = sql.ExecuteQuery($"SELECT * FROM Pallet_Table WHERE name = '{palletchoice_combobox.Text}';").Rows[0];
                content_label.Text += "\n\nPALLET:\n" +
                    $"\tLength: {row["_length"]}\n" +
                    $"\tWidth : {row["_width"]}\n" +
                    $"\tHeight: {row["_height"]}";
            }
            if (bundleitem_combobox.SelectedIndex == 0)
            {
                content_label.Text = "*Select a Bundle*";
                content_label.ForeColor = Color.DimGray;
            }
        }


        public void initializeBundleCombobox()
        {
            bundleitem_combobox.Items.Clear();
            palletchoice_combobox.Items.Clear();
            bundleitem_combobox.Items.Add("<Select a target Bundle-Item>");
            palletchoice_combobox.Items.Add("<Select a target Pallet>");
            if (parent.clientList.Count > 0)
            {
                foreach (clientselectView_form form in parent.clientList)
                {
                    int ClientID = form.getMyID();
                    if (ClientID == -1) continue;
                    foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Bundle_Table;").Rows)
                    {
                        bundleitem_combobox.Items.Add(
                            sql.ExecuteQuery($"SELECT item_name FROM Item_Table WHERE id = {Convert.ToInt32(row["item_id"])} AND client_id = {ClientID}").Rows[0][0].ToString()
                            );
                    }
                }
            }
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Pallet_Table;").Rows) palletchoice_combobox.Items.Add(row["name"].ToString());
            bundleitem_combobox.SelectedIndex = 0;
            palletchoice_combobox.SelectedIndex = 0;
        }

        public bool isApplicableForComputation()
        {
            return bundleitem_combobox.SelectedIndex != 0;
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            parent.list.Remove(this);
            this.Dispose();
            parent.UpdateVisual();
        }

        public void setVisible(bool visibility = true)
        {
            quantityholder_flp.Visible = visibility;
        }

        public int geTotalBundlesToLoadInTruck()
        {
            totalbundletoload_tb.Text = totalbundletoload_tb.Text.Equals(string.Empty) ? "0" : totalbundletoload_tb.Text;
            return Convert.ToInt32(totalbundletoload_tb.Text);
        }
        public decimal getlength()
        {
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _length FROM Item_Table WHERE item_name = '{bundleitem_combobox.Text}'").Rows[0][0]) * getQuantity();
        }

        public decimal getwidth()
        {
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _width FROM Item_Table WHERE item_name = '{bundleitem_combobox.Text}'").Rows[0][0]) * getQuantity();
        }

        public decimal getheight()
        {
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT f._value\r\nFROM Item_Table i\r\nJOIN Flute_Table f ON i.flute_id = f.id\r\nWHERE i.item_name = '{bundleitem_combobox.Text}';").Rows[0][0]) * getQuantity();
        }

        public int getQuantity()
        {
            int bundleid = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Item_Table WHERE item_name = '{bundleitem_combobox.Text}'").Rows[0][0]);

            return Convert.ToInt32(sql.ExecuteQuery($"SELECT quantity FROM Bundle_Table WHERE item_id = {bundleid}").Rows[0][0]);
        }

        private void palletEnabler_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            palletchoice_combobox.Enabled = palletEnabler_checkbox.Checked;
        }

        private void bundleitem_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContent();
            parent.UpdateVisual();

        }

        private void palletchoice_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContent();
            parent.UpdateVisual();
        }

        private void totalbundletoload_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                // Remove any non-numeric characters
                tb.Text = new string(tb.Text.Where(char.IsDigit).ToArray());
                tb.SelectionStart = tb.Text.Length; // Keep cursor at the end
            }
            parent.UpdateVisual();
        }
    }
}
