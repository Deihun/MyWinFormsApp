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
            targetrange_from_tb.Text = row["targetrange_from"].ToString();
            targetrange_to_tb.Text = row["targetrange_to"].ToString();
            textBox1.Text = row["tolerance"].ToString();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (ID == -1) addNewFlute();
            else rewriteFlute();
            parent.UpdateVisual();
            
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private bool doesNameExist(string name)
        {
            foreach (DataRow row in sql.ExecuteQuery("SELECT code_name FROM Flute_Table WHERE is_deleted = 0").Rows) if (row["code_name"].ToString() == name) return true;
            return false;
        }
        private void addNewFlute()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARED //INCOMPLETE
        {
            if (!filter.AreAllInputsFilled(codename_tb, standardsize_tb, targetrange_from_tb, targetrange_to_tb, textBox1) && !doesNameExist(codename_tb.Text))
            {
                MessageBox.Show("Fill up all the requirement input or avoid using the same code-name");
                return;
            }
            Dictionary<string, object> value = new Dictionary<string, object>()
            {
                {"code_name", codename_tb.Text },
                {"_value", decimal.Parse(standardsize_tb.Text,CultureInfo.InvariantCulture)},
                {"targetrange_from", decimal.Parse(targetrange_from_tb.Text, CultureInfo.InvariantCulture)},
                {"targetrange_to", decimal.Parse(targetrange_to_tb.Text, CultureInfo.InvariantCulture)},
                {"tolerance", decimal.Parse(textBox1.Text, CultureInfo.InvariantCulture)}
            };
            sql.InsertData("Flute_Table", value);
            sql.commitReport($"A new Data Flute '{codename_tb.Text}' was added");
            this.Dispose();
        }

        private void rewriteFlute()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARED
        {
            if (filter.AreAllInputsFilled(codename_tb, standardsize_tb, targetrange_from_tb, targetrange_to_tb, textBox1) )
            {
                MessageBox.Show("Fill up all the requirement input");
                return;
            }
            string query = "UPDATE Flute_Table" +
                $"code_name = '{codename_tb.Text}', _value={Convert.ToDecimal(standardsize_tb.Text)} WHERE id = {ID};";
            sql.ExecuteQuery(query);
            sql.commitReport($"A Data Flute '{codename_tb.Text}' was modified");
            this.Dispose();
        }

        private void codename_tb_TextChanged(object sender, EventArgs e)
        {
            filter.SanitizeSQLInput(codename_tb);
        }

        private void standardsize_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(standardsize_tb);
        }

        private void targetrange_from_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(targetrange_from_tb);
        }

        private void targetrange_to_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(targetrange_to_tb);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(textBox1);
        }
    }
}
