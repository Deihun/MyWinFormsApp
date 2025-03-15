using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * REWORK THIS TO ALSO STORE //INCOMPLETE
        standard

        Target

        Tolerance
 */
namespace MyWinFormsApp.Sections.ManageItems.Flute
{
    public partial class AddOrEditFlute_windowpopupform : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        FilterInputSupportClass filter = new FilterInputSupportClass();
        ManageFlute_WindowPopupForm parent;
        int ID = -1;
        public AddOrEditFlute_windowpopupform(ManageFlute_WindowPopupForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public AddOrEditFlute_windowpopupform(ManageFlute_WindowPopupForm parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.ID = id;
            this.Text = "EDIT";
            this.add_btn.Text = "CONFIRM CHANGES";

            DataRow row = sql.ExecuteQuery($"SELECT * FROM Flute_Table WHERE ID = {ID};").Rows[0];
            codename_tb.Text = row["code_name"].ToString();
            standardsize_tb.Text = row["_value"].ToString();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (ID == -1) addNewFlute();
            else rewriteFlute();
            parent.UpdateVisual();
            this.Dispose();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void addNewFlute()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARED //INCOMPLETE
        {
            Dictionary<string, object> value = new Dictionary<string, object>()
            {
                {"code_name", codename_tb.Text },
                {"_value", decimal.Parse(standardsize_tb.Text,CultureInfo.InvariantCulture) }
            };
            MessageBox.Show($"{decimal.Parse(standardsize_tb.Text, CultureInfo.InvariantCulture)}");
            sql.InsertData("Flute_Table", value);
        }

        private void rewriteFlute()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARED
        {
            string query = "UPDATE Flute_Table" +
                $"code_name = '{codename_tb.Text}', _value={Convert.ToDecimal(standardsize_tb.Text)} WHERE id = {ID};";
            sql.ExecuteQuery(query);
        }

        private void codename_tb_TextChanged(object sender, EventArgs e)
        {
            filter.SanitizeSQLInput(codename_tb);
        }

        private void standardsize_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(standardsize_tb);
        }
    }
}
