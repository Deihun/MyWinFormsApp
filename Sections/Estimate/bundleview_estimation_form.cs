using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System.Data;
using System.Drawing.Drawing2D;

namespace MyWinFormsApp.Sections.Estimate
{
    public partial class bundleview_estimation_form : Form
    {
        // <REFERENCE CLASS>
        private Estimate_Form parent;
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private FilterInputSupportClass filter = new FilterInputSupportClass();

        // <DICTIONARY>
        private Dictionary<int, string> bundle_item_dictionary = new Dictionary<int, string>();
        private Dictionary<int, string> pallet_item_dictionary = new Dictionary<int, string>();

        // DATATYPES
        private int id = -1;
        private int pallet_id = -1;
        private int pallet_quantity = -1;
        /// <summary>
        /// This is use for creation of Bundle Estimation Form for user to fill up the bundles.
        /// </summary>
        /// <param name="parent">Some functions reference the parent form</param>
            public bundleview_estimation_form(Estimate_Form parent)
            {
                InitializeComponent();
                this.parent = parent;
                initializeBundleCombobox();
            }

        /// <summary>
        /// This is use in loading an existing Estimation. User privilage are only set for read-only
        /// </summary>
        /// <param name="parent">Some functions reference the parent form</param>
        /// <param name="bundle_id">Reference the Bundle ID from SQLs</param>
        /// <param name="pallet_id">Reference the Pallet if it has from SQLs</param>
        /// <param name="quantityOfTotal">Reference the quantity of an a number of pallet in a created group bundle</param>
        public bundleview_estimation_form(Estimate_Form parent, int bundle_id, int pallet_id, int quantityOfTotal, int quantityOfPallet)
            {
                InitializeComponent();
                this.parent = parent;
                this.id = bundle_id;
                this.pallet_id = pallet_id;
                this.pallet_quantity = quantityOfPallet;
                totalbundletoload_tb.Text = quantityOfTotal.ToString();
            }
        public void addAllChoices(bool editable, List<bundleview_estimation_form> list)
        {
            bundleitem_combobox.DropDownStyle = ComboBoxStyle.Simple;
            palletchoice_combobox.DropDownStyle = ComboBoxStyle.Simple;
            DataRow allInformation = sql.ExecuteQuery("SELECT i.item_name, bundle.id, bundle.quantity FROM " +
            "[Bundle_Table] bundle JOIN [Item_Table] i " +
            "ON bundle.item_id = i.id " +
            $"WHERE bundle.id = {id}").Rows[0];
            
            if (editable)
            {
                initializeBundleCombobox();
            }

            try { bundle_item_dictionary.Add(Convert.ToInt32(allInformation["id"]), $"{allInformation["item_name"]} ({allInformation["id"]})"); } catch {}
            bundleitem_combobox.Items.Add($"{allInformation["item_name"]} ({allInformation["id"]})");
            bundleitem_combobox.Text = $"{allInformation["item_name"]} ({allInformation["id"]})";

            string pallet_name = $"{getPalletName(pallet_id)} ({pallet_id})";
            palletEnabler_checkbox.Checked = (this.pallet_quantity != 0) || this.pallet_quantity != null;
            quantityof_pallet.Enabled = true;
            totalbundletoload_tb.Enabled = true;


            
            if (pallet_id != -1)
            {
                palletEnabler_checkbox.Enabled = true;
                try
                {
                pallet_item_dictionary.Add(pallet_id, pallet_name);
                }catch { }
                palletchoice_combobox.Items.Add(pallet_name);
                palletchoice_combobox.Text = pallet_name;
                quantityof_pallet.Text = this.pallet_quantity.ToString();
            }
            //if (editable) try { updateContent(); } catch { list.Remove(this); this.Dispose(); }
            //else updateContent();
            bundleitem_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            palletchoice_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void disable_inputs()
        {
            quantityof_pallet.Enabled = false;
            bundleitem_combobox.Enabled = false;
            totalbundletoload_tb.Enabled = false;
            palletEnabler_checkbox.Enabled = false;
            palletchoice_combobox.Enabled = false;
            delete_button.Hide();
        }



        //VISUAL METHODS
        private void SetGradientBackground(string hexColor1, string hexColor2)
        {
            Color color1 = ColorTranslator.FromHtml(hexColor1);
            Color color2 = ColorTranslator.FromHtml(hexColor2);

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, this.Width, this.Height),
                color1,
                color2,
                LinearGradientMode.Vertical)) // Change direction if needed
            {
                g.FillRectangle(brush, 0, 0, this.Width, this.Height);
            }
            this.BackgroundImage = bmp;
        }
        public int get_int_baseon_selected_pallet()
        {
            string a = "";
            foreach (var item in pallet_item_dictionary) 
            { 
                if (item.Value == palletchoice_combobox.Text) return item.Key;
            }
            throw new Exception();
        }
        public int get_int_baseon_selected_bundle()
        {
            foreach (var item in bundle_item_dictionary) if (item.Value == bundleitem_combobox.Text) return item.Key;
            throw new Exception();
        }

        /// <summary>
        /// Change the appearance of BundleView_Form base on appropriate live existing values it has or depending on user inputs.
        /// </summary>
        private void updateContent()
        {
            content_label.ForeColor = Color.Black;
            if (bundleitem_combobox.SelectedIndex != 0)
            {
                this.Size = new Size(328, 193);
                int id = get_int_baseon_selected_bundle();
                DataRow content = sql.ExecuteQuery("SELECT bundle.quantity, item.fc_control_number, item._length, item._width, flute.code_name, flute._value FROM Bundle_Table bundle JOIN Item_Table item ON bundle.item_id = item.id " +
                    $" JOIN Flute_Table flute ON item.flute_id = flute.id WHERE bundle.id = {id}").Rows[0];

                int quantity = Convert.ToInt32(content["quantity"]);
                decimal fluteValue = Convert.ToDecimal(content["_value"]);
                string FluteType = content["code_name"].ToString();
                content_label.Text = $"Quantity      : {quantity} pcs\n" +
                                 $"Length(mm)    : {Math.Round(getlength(), 2)}\n" +
                                 $"Width(mm)     : {Math.Round(getwidth(), 2)}\n" +
                                 $"Height(mm)    : {Math.Round(getheight(), 2)}\n" +
                                 $"Dimensions(mm): {Math.Round(getlength() * getheight() * getwidth(), 2)}\n" +
                                 $"F.C. Control Number: {content["fc_control_number"]}\n" +
                                 $"FluteType: ({FluteType})\n";
            }
            if (palletEnabler_checkbox.Checked && palletchoice_combobox.Text != "<Select a target Pallet>" && get_int_baseon_selected_pallet() != -1)
            {
                this.Size = new Size(328, 193);
                this.Height += 100;
                DataRow row = sql.ExecuteQuery($"SELECT * FROM Pallet_Table WHERE id = {get_int_baseon_selected_pallet()};").Rows[0];
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
            updatePalletChoiceAsWarning();
        }
        /// <summary>
        /// Reset and Add all existing available bundle items in SQL base on given Client
        /// </summary>
        public void initializeBundleCombobox()
        {
              bundleitem_combobox.Items.Clear();
              palletchoice_combobox.Items.Clear();
              bundle_item_dictionary.Clear();
              pallet_item_dictionary.Clear();
              bundleitem_combobox.Items.Add("<Select a target Bundle-Item>");
              palletchoice_combobox.Items.Add("<Select a target Pallet>");
                foreach (DataRow row in sql.ExecuteQuery("SELECT bundle.id AS ID, item.item_name AS name FROM Bundle_Table bundle JOIN Item_Table item ON bundle.item_id = item.id WHERE bundle.is_deleted = 0 AND item.is_deleted = 0;").Rows) {
                try{
                    bundle_item_dictionary.Add(Convert.ToInt32(row["ID"]), $"{row["name"]} ({row["ID"]})");
                }catch { } }
             bundle_item_dictionary = bundle_item_dictionary.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Pallet_Table WHERE is_deleted = 0").Rows) pallet_item_dictionary.Add(Convert.ToInt32(row["id"]), $"{row["name"]} ({row["id"]})");
              foreach (string item_name in bundle_item_dictionary.Values) bundleitem_combobox.Items.Add(item_name);   
              foreach (string pallet_name in pallet_item_dictionary.Values) palletchoice_combobox.Items.Add(pallet_name);
              bundleitem_combobox.SelectedIndex = 0;
              palletchoice_combobox.SelectedIndex = 0;
        }

        public Dictionary<int, string> get_all_bundle_content()
        {
            return bundle_item_dictionary;
        }
        /// <summary>
        /// Set visibility of Quantity number section input of of Bundles in a Group
        /// </summary>
        /// <param name="visibility"></param>
        public void setVisible(bool visibility = true)
        {
            quantityholder_flp.Visible = visibility;
        }
        /// <summary>
        /// Change the visibility of a warning indicator in Pallet Combobox if the user will be using a pallet but doesn't have any selected items.
        /// </summary>
        private void updatePalletChoiceAsWarning()
        {
            bool isConsideredWarning = palletEnabler_checkbox.Checked && (palletchoice_combobox.SelectedIndex == 0);
            error_provider.Visible = isConsideredWarning;
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

        /// <summary>
        /// Get the seleced item-name
        /// </summary>
        /// <returns>ItemName</returns>
        public string getProductName()
        {
            if (bundleitem_combobox.SelectedIndex == 0) return "<RETURNING NO VALUE>";
            return bundleitem_combobox.Text;
        }

       /// <summary>
       /// Returns true if the user already has selected a Target Bundle in ComboBox
       /// </summary>
       /// <returns></returns>
        public bool isApplicableForComputation()
        {
            return bundleitem_combobox.SelectedItem != "<Select a target Bundle-Item>";
        }


        /// <returns>Return a numbers of number of bundle from Textbox Quantity</returns>
        public int geTotalBundlesToLoadInTruck()
        {
            totalbundletoload_tb.Text = totalbundletoload_tb.Text.Equals(string.Empty) ? "0" : totalbundletoload_tb.Text;
            return Convert.ToInt32(totalbundletoload_tb.Text);
        }

        /// <returns>Returns a length of a selected item</returns>
        public decimal getlength()
        {
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT item._length AS LENGTH FROM Item_Table item JOIN Bundle_Table bundle ON bundle.item_id = item.id WHERE bundle.id = {get_int_baseon_selected_bundle()}").Rows[0][0]);
        }


        /// <returns>Returns a width of a selected item</returns>
        public decimal getwidth()
        {
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT item._width AS WIDTH FROM Item_Table item JOIN Bundle_Table bundle ON bundle.item_id = item.id WHERE bundle.id = {get_int_baseon_selected_bundle()}").Rows[0][0]);
        }


        /// <returns>Returns a height of a selected item, it reference flute and if is Folded</returns>
        public decimal getheight()
        {
            //MessageBox.Show($"SELECT flute._value FROM Item_Table item JOIN Flute_Table flute ON item.flute_id = flute.id JOIN Bundle_Table bundle ON bundle.item_id = item.id WHERE bundle.id = {get_int_baseon_selected_bundle()}");
            decimal a = Convert.ToDecimal(sql.ExecuteQuery($"SELECT flute._value FROM Item_Table item JOIN Flute_Table flute ON item.flute_id = flute.id JOIN Bundle_Table bundle ON bundle.item_id = item.id WHERE bundle.id = {get_int_baseon_selected_bundle()}").Rows[0][0]) * getQuantity();
            bool b = Convert.ToBoolean(sql.ExecuteQuery($"SELECT item.isFolded FROM Item_Table item JOIN Bundle_Table bundle ON bundle.item_id = item.id WHERE bundle.id = {get_int_baseon_selected_bundle()}").Rows[0][0]);
            return b ? a * 2 : a;
        }


        /// <returns>returns </returns>
        public int getQuantityOFTotalBundlesInGroup()
        {
            int a = string.IsNullOrEmpty(totalbundletoload_tb.Text) ? 0 : Convert.ToInt32(totalbundletoload_tb.Text);
            return a;
        }
        public int getQuantity()
        {
            string query = $"SELECT b.quantity FROM Bundle_Table b JOIN Item_Table i ON b.item_id = i.id WHERE b.is_deleted = 0 AND b.id = {get_int_baseon_selected_bundle()}";
            return Convert.ToInt32(sql.ExecuteQuery(query).Rows[0][0]);
        }


        public int getPalletID()
        {
            if (!palletEnabler_checkbox.Checked || palletchoice_combobox.SelectedIndex == 0) return -1;
            return Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Pallet_Table WHERE id = {get_int_baseon_selected_pallet()}").Rows[0][0]);
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
            if (palletchoice_combobox.Text == "<Select a target Pallet>") return 0m;
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _length FROM Pallet_Table WHERE id = {get_int_baseon_selected_pallet()}").Rows[0][0]);
        }

        public decimal getWidthPallet()
        {
            if (palletchoice_combobox.SelectedIndex == 0) return 0m;
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _width FROM Pallet_Table WHERE id = {get_int_baseon_selected_pallet()}").Rows[0][0]);
        }

        public decimal getHeightPallet()
        {
            if (palletchoice_combobox.SelectedIndex == 0) return 0m;
            return Convert.ToDecimal(sql.ExecuteQuery($"SELECT _length FROM Pallet_Table WHERE id = {get_int_baseon_selected_pallet()} ").Rows[0][0]);
        }

        public bool canPalletComputationBeUse()
        {
            List<string> rules = new List<string>()
            {
                "0","qty. of pallet"
            };
            return (palletchoice_combobox.SelectedIndex != 0 && palletEnabler_checkbox.Checked && !(rules.Contains(quantityof_pallet.Text)));
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

                //CONTROL EVENTS
        private void bundleitem_combobox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            string text = bundleitem_combobox.Items[e.Index].ToString();
            e.DrawBackground();
            using (StringFormat sf = new StringFormat())
            {
                sf.Trimming = StringTrimming.EllipsisCharacter;
                sf.FormatFlags = StringFormatFlags.NoWrap;
                e.Graphics.DrawString(text, e.Font, Brushes.Black, e.Bounds, sf);
            }
            e.DrawFocusRectangle();
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
        private void palletEnabler_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            palletchoice_combobox.Enabled = palletEnabler_checkbox.Checked;
            quantityof_pallet.Enabled = palletEnabler_checkbox.Checked;
            updatePalletChoiceAsWarning();
            parent.UpdateVisual();
        }

        private void bundleitem_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            parent.UpdateVisual();
            updateContent();
            if (bundleitem_combobox.SelectedIndex == 0) SetGradientBackground("#FFB28C", "#D15834");
            else SetGradientBackground("#FFFFFF", "#A6A4A4");
        }

        private void palletchoice_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContent();

            parent.UpdateVisual();
            if (bundleitem_combobox.SelectedIndex == 0) SetGradientBackground("#FFB28C", "#D15834");
            else SetGradientBackground("#FFFFFF", "#A6A4A4");
        }

        private void totalbundletoload_tb_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox tb = sender as System.Windows.Forms.TextBox;
            if (tb != null)
            {
                tb.Text = new string(tb.Text.Where(char.IsDigit).ToArray());
                tb.SelectionStart = tb.Text.Length; // Keep cursor at the end
            }
            parent.UpdateVisual();
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            parent.bundle_list.Remove(this);
            this.Dispose();
            parent.UpdateVisual();
        }
    }
}
