using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyWinFormsApp.Sections.Estimate
{
    public partial class bundleview_estimation_form : Form
    {
        // <REFERENCE CLASS>
        Estimate_Form parent;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        FilterInputSupportClass filter = new FilterInputSupportClass();

        public bundleview_estimation_form(Estimate_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            bundleitem_combobox.SelectedIndex = 0;
            palletchoice_combobox.SelectedIndex = 0;
            initializeBundleCombobox();
        }
        public bundleview_estimation_form(Estimate_Form parent, int bundle_id, int? pallet_id, int quantityOfTotal)
        {
            InitializeComponent();
            this.parent = parent;
            DataRow allInformation = sql.ExecuteQuery("SELECT i.item_name, bundle.quantity FROM " +
                                    "[Bundle_Table] bundle JOIN [Item_Table] i " +
                                    "ON bundle.item_id = i.id " +
                                    $"WHERE bundle.id = {bundle_id}").Rows[0];
            string pallet_name = getPalletName(pallet_id);
            bundleitem_combobox.DropDownStyle = ComboBoxStyle.Simple;
            bundleitem_combobox.Text = allInformation["item_name"].ToString();
            bundleitem_combobox.Enabled = false;

            totalbundletoload_tb.Text = quantityOfTotal.ToString();
            totalbundletoload_tb.Enabled = false;

            palletEnabler_checkbox.Enabled = pallet_id != -1;
            palletchoice_combobox.DropDownStyle = ComboBoxStyle.Simple;
            palletchoice_combobox.Text = pallet_name;
            palletchoice_combobox.Enabled = false;
            delete_button.Hide();
            updateContent();
        }

        private string getPalletName(int? pallet_id)
        {
            try
            {
                return sql.ExecuteQuery($"SELECT name FROM Pallet_Table WHERE id = {pallet_id};").Rows[0][0].ToString();
            }
            catch
            {
                return "";
            }
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

                this.Size = new Size(328, 193);
                DataRow rowItem = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE id = {id}").Rows[0];
                DataRow rowFlute = sql.ExecuteQuery($"SELECT _value, code_name FROM Flute_Table WHERE id = {Convert.ToInt32(rowItem["flute_id"])}").Rows[0];
                decimal fluteValue = Convert.ToDecimal(rowFlute["_value"]);
                string FluteType = rowFlute["code_name"].ToString();

                content_label.Text = $"Quantity      : {quantity} pcs\n" +
                                 $"Length(mm)    : {Math.Round(getlength(),2)}\n" +
                                 $"Width(mm)     : {Math.Round(getwidth(), 2)}\n" +
                                 $"Height(mm)    : {Math.Round(getheight(), 2)}\n" +
                                 $"Dimensions(mm): {Math.Round(getlength() * getheight() * getwidth(), 2)}\n" +
                                 $"F.C. Control Number: {rowItem["fc_control_number"]}\n" +
                                 $"FluteType: ({FluteType})\n";
            }
            if (palletEnabler_checkbox.Checked && palletchoice_combobox.SelectedIndex > 0)
            {
                this.Size = new Size(328, 193);
                this.Height += 100;
                DataRow row = sql.ExecuteQuery($"SELECT * FROM Pallet_Table WHERE name = '{palletchoice_combobox.Text}';").Rows[0];
                decimal length = Math.Round(Convert.ToDecimal(row["_length"]), 2);
                decimal width = Math.Round(Convert.ToDecimal(row["_width"]), 2);
                decimal height = Math.Round(Convert.ToDecimal(row["_height"]), 2);
                content_label.Text += "\n\nPALLET:\n" +
                    $"\tLength: {length}\n" +
                    $"\tWidth : {width}\n" +
                    $"\tHeight: {height}";
            }
            if (bundleitem_combobox.SelectedIndex == 0)
            {
                content_label.Text = "*Select a Bundle*";
                content_label.ForeColor = Color.DimGray;
            }
        }



        public string getProductName()
        {
            if (bundleitem_combobox.SelectedIndex == 0) return "<RETURNING NO VALUE>";
            return bundleitem_combobox.Text;
        }

        public void initializeBundleCombobox()
        {
            bundleitem_combobox.Items.Clear();
            palletchoice_combobox.Items.Clear();
            bundleitem_combobox.Items.Add("<Select a target Bundle-Item>");
            palletchoice_combobox.Items.Add("<Select a target Pallet>");
            List<string> bundlelist = new List<string>();
            if (parent.clientList.Count > 0)
            {
                foreach (clientselectView_form form in parent.clientList)
                {
                    int ClientID = form.getMyID();
                    if (ClientID == -1) continue;

                    foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Bundle_Table WHERE is_deleted = 0;").Rows)
                    {
                        bool canProceed = (0 >= sql.ExecuteQuery($"SELECT item_name FROM Item_Table WHERE id = {Convert.ToInt32(row["item_id"])} AND client_id = {ClientID} AND is_deleted = 0").Rows.Count);
                        if (canProceed) continue;
                        bundlelist.Add(
                            sql.ExecuteQuery($"SELECT item_name FROM Item_Table WHERE id = {Convert.ToInt32(row["item_id"])} AND client_id = {ClientID} AND is_deleted = 0").Rows[0][0].ToString()
                            );
                    }
                }
            }
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Pallet_Table;").Rows) palletchoice_combobox.Items.Add(row["name"].ToString());
            bundleitem_combobox.Items.AddRange(bundlelist.Distinct().ToArray());
            bundleitem_combobox.SelectedIndex = 0;
            palletchoice_combobox.SelectedIndex = 0;
        }

        public bool isApplicableForComputation()
        {
            return bundleitem_combobox.SelectedItem != "<Select a target Bundle-Item>";
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            parent.bundle_list.Remove(this);
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
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _length FROM Item_Table WHERE item_name = '{bundleitem_combobox.Text}'").Rows[0][0]);
        }

        public decimal getwidth()
        {
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _width FROM Item_Table WHERE item_name = '{bundleitem_combobox.Text}'").Rows[0][0]);
        }

        public decimal getheight()
        {
            decimal a = Convert.ToDecimal(sql.ExecuteQuery($"SELECT f._value\r\nFROM Item_Table i\r\nJOIN Flute_Table f ON i.flute_id = f.id\r\nWHERE i.item_name = '{bundleitem_combobox.Text}' AND i.is_deleted = 0;").Rows[0][0]) * getQuantity();
            bool b = Convert.ToBoolean(sql.ExecuteQuery($"SELECT isFolded FROM Item_Table WHERE item_name = '{bundleitem_combobox.Text}' AND is_deleted = 0").Rows[0][0]);
            return b ? a * 2 : a;
        }

        public int getQuantityOFTotalBundlesInGroup()
        {
            int a = string.IsNullOrEmpty(totalbundletoload_tb.Text) ? 0 : Convert.ToInt32(totalbundletoload_tb.Text);
            return a;
        }
        public int getQuantity()
        {
            string query = $"SELECT b.quantity FROM Bundle_Table b JOIN Item_Table i ON b.item_id = i.id WHERE b.is_deleted = 0 AND i.item_name = '{bundleitem_combobox.Text}'";
            //int bundleid = Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Item_Table WHERE item_name = '{bundleitem_combobox.Text}'").Rows[0][0]);

            return Convert.ToInt32(sql.ExecuteQuery(query).Rows[0][0]);
        }

        public int getBundleID()
        {
            if (bundleitem_combobox.SelectedIndex == 0) return -1;
            return Convert.ToInt32(sql.ExecuteQuery($"SELECT b.id FROM Bundle_Table b JOIN Item_Table i ON b.item_id = i.id WHERE i.item_name = '{bundleitem_combobox.Text}'").Rows[0][0]);
        }

        public int getPalletID()
        {
            if (palletEnabler_checkbox.Checked || palletchoice_combobox.SelectedIndex == 0) return -1;
            return Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Pallet_Table WHERE name = '{palletchoice_combobox.Text}'").Rows[0][0]);
        }

        private void palletEnabler_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            palletchoice_combobox.Enabled = palletEnabler_checkbox.Checked;
            quantityof_pallet.Enabled = palletEnabler_checkbox.Checked;
            parent.UpdateVisual();
        }

        private void bundleitem_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            parent.UpdateVisual();
            updateContent();
            if (bundleitem_combobox.SelectedIndex == 0) this.BackColor = Color.IndianRed;
            else this.BackColor = Color.Gainsboro;
        }

        private void palletchoice_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContent();
            parent.UpdateVisual();
        }

        private void totalbundletoload_tb_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            if (tb != null)
            {
                // Remove any non-numeric characters
                tb.Text = new string(tb.Text.Where(char.IsDigit).ToArray());
                tb.SelectionStart = tb.Text.Length; // Keep cursor at the end
            }
            parent.UpdateVisual();
        }

        private void quantityof_pallet_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(quantityof_pallet);
            quantityof_pallet.Text = quantityof_pallet.Text.Replace(".", "");
            parent.UpdateVisual();
        }

        private void quantityof_pallet_Enter(object sender, EventArgs e)
        {
            quantityof_pallet.ForeColor = Color.Black;
            if (quantityof_pallet.Text == "qty. of pallet")
            {
                quantityof_pallet.Text = "0";
            }
        }

        private void quantityof_pallet_Leave(object sender, EventArgs e)
        {
            if (quantityof_pallet.Text == string.Empty)
            {
                quantityof_pallet.ForeColor = Color.DimGray;
                quantityof_pallet.Text = "qty. of pallet";
            }
            else quantityof_pallet.ForeColor = Color.Black;
        }

        public string getPalletName()
        {
            return palletchoice_combobox.Text;
        }

        public int getQuantityOfPallet()
        {
            return Convert.ToInt32(quantityof_pallet.Text == "qty. of pallet" || quantityof_pallet.Text == string.Empty ? "0" : quantityof_pallet.Text);
        }
        public decimal getLengthPallet()
        {
            if (palletchoice_combobox.SelectedIndex == 0) return 0m;
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _length FROM Pallet_Table WHERE name = '{palletchoice_combobox.Text}' AND is_deleted = 0").Rows[0][0]);
        }

        public decimal getWidthPallet()
        {
            if (palletchoice_combobox.SelectedIndex == 0) return 0m;
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _width FROM Pallet_Table WHERE name = '{palletchoice_combobox.Text}' AND is_deleted = 0").Rows[0][0]);
        }

        public decimal getHeightPallet()
        {
            if (palletchoice_combobox.SelectedIndex == 0) return 0m;
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _length FROM Pallet_Table WHERE name = '{palletchoice_combobox.Text}' AND is_deleted = 0").Rows[0][0]);
        }

        public bool canPalletComputationBeUse()
        {
            return (palletchoice_combobox.SelectedIndex != 0 && palletEnabler_checkbox.Checked);
        }

        public bool isProvidingPallet()
        {
            try
            {
                return (palletEnabler_checkbox.Checked && Convert.ToInt32(quantityof_pallet.Text) > 0);
            }
            catch
            {
                return false;
            }

        }

        private void bundleitem_combobox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            MessageBox.Show("test");
            string text = bundleitem_combobox.Items[e.Index].ToString();

            // Draw background (needed for selection color)
            e.DrawBackground();

            // Draw text (clipped to the ComboBox bounds)
            using (StringFormat sf = new StringFormat())
            {
                sf.Trimming = StringTrimming.EllipsisCharacter; // Adds "..." if too long
                sf.FormatFlags = StringFormatFlags.NoWrap;

                // Draw text in the available space
                e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds, sf);
            }

            // Draw focus rectangle (for selection highlight)
            e.DrawFocusRectangle();
        }
    }
}
