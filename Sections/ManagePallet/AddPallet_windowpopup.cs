using MyWinFormsApp.SupportClass;
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

namespace MyWinFormsApp.Sections.ManagePallet
{
    public partial class AddPallet_windowpopup : Form
    {
        FilterInputSupportClass filter = new FilterInputSupportClass();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        ManagePallet_Form parent;
        ReferenceDimensionObject rdo;
        private int ID = -1;
        public AddPallet_windowpopup(ManagePallet_Form parent)
        {
            InitializeComponent();
            instantiateReferencePallet();
            this.parent = parent;
            updateWarning();
        }
        public AddPallet_windowpopup(ManagePallet_Form parent, int id)
        {
            InitializeComponent();
            instantiateReferencePallet();
            this.parent = parent;
            this.ID = id;

            DataRow row = sql.ExecuteQuery($"SELECT * FROM Pallet_Table WHERE id = {ID}").Rows[0];
            name_tb.Text = row["name"].ToString();
            length_tb.Text = row["_length"].ToString();
            width_tb.Text = row["_width"].ToString();
            height_tb.Text = row["_height"].ToString();
            this.Text = "EDIT PALLET";
            this.add_btn.Text = "CONFIRM CHANGES";
            updateWarning();
        }

        public void instantiateReferencePallet()
        {
            referencepalletsize_cb.Items.Clear();
            foreach (DataRow row in sql.ExecuteQuery("SELECT name FROM Pallet_Table WHERE is_deleted = 0").Rows) referencepalletsize_cb.Items.Add(row["name"].ToString());
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (filter.AreAllInputsFilled(length_tb, width_tb, height_tb, name_tb) && !sql.DoesDataExist("Pallet_Table", "name", name_tb.Text))
            {
                if (ID == -1) AddPallet();
                else RewritePallet();
                parent.UpdateVisual();
                this.Close();
            }
            else MessageBox.Show("Please fill up all the required to be inserted data or avoid reusing existing inserted name of Pallet");
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private bool containsSameName()
        {
            foreach (DataRow row in sql.ExecuteQuery("SELECT name FROM Pallet_Table WHERE is_deleted = 0").Rows) if (row["name"].ToString() == name_tb.Text) return true;
            return false;
        }
        private void AddPallet() //REWRITE THIS WHEN INTEGRATING TO DATABASE
        {
            if (containsSameName())
            {
                MessageBox.Show("Pallet name is already taken. Please use a non existing Pallet name or make it not exactly the same with other existing one.");
                return;
            }
            Dictionary<string, object> value = new Dictionary<string, object>(){
                { "name", name_tb.Text},
                { "_length", Convert.ToDecimal(length_tb.Text) },
                 { "_width", Convert.ToDecimal(width_tb.Text) },
                  { "_height", Convert.ToDecimal(height_tb.Text) }
            };

            sql.InsertData("Pallet_Table", value);
            sql.commitReport($"A new data Pallet '{name_tb.Text}' was added");
        }

        private void RewritePallet() //REWRITE THIS WHEN INTEGRATING TO DATABASE
        {
            string query = "UPDATE Pallet_Table " +
                $"SET name =  '{name_tb.Text}', _length = {Convert.ToInt32(length_tb.Text)}, _width = {Convert.ToInt32(width_tb.Text)}, _height = {Convert.ToInt32(height_tb.Text)};";
            sql.ExecuteQuery(query);
            sql.commitReport($"A data Pallet '{name_tb.Text}' was modified");
        }

        private void name_tb_TextChanged(object sender, EventArgs e)
        {
            filter.SanitizeSQLInput(name_tb);
            updateWarning();
        }

        private void referencepalletsize_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdo = new(referencepalletsize_cb.Text);
            length_tb.Text = rdo.length.ToString();
            width_tb.Text = rdo.width.ToString();
            height_tb.Text = rdo.height.ToString();
        }

        private void length_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(length_tb);
            updateWarning();
        }

        private void width_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(width_tb);
            updateWarning();
        }

        private void height_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(height_tb);
            updateWarning();
        }

        private void updateWarning()
        {
            name_warning.Visible = name_tb.Text == string.Empty;
            length_warning.Visible = length_tb.Text == string.Empty;
            width_warning.Visible = width_tb.Text == string.Empty;
            height_warning.Visible = height_tb.Text == string.Empty;
        }
    }

    class ReferenceDimensionObject
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem",null,null);
        public decimal length;
        public decimal width;
        public decimal height;

        public ReferenceDimensionObject(string name)
        {
            DataRow rowDimension = sql.ExecuteQuery($"SELECT * FROM Pallet_Table WHERE name = '{name}' AND is_deleted = 0").Rows[0];
            length = Convert.ToDecimal(rowDimension["_length"]);
            width = Convert.ToDecimal(rowDimension["_width"]);
            height = Convert.ToDecimal(rowDimension["_height"]);
        }
    }
}
