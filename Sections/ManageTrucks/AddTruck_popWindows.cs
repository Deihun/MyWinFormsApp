using MyWinFormsApp.SupportClass;
using MyWinFormsApp.SupportClass.SupportSQLClass;
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

namespace MyWinFormsApp.Sections.ManageTrucks
{
    public partial class AddTruck_popWindows : Form
    {
        ManageTrucks_Form parent = new ManageTrucks_Form(); //INCOMPLETE, LACKS SELECTION AND OTHERS
        FilterInputSupportClass filter = new FilterInputSupportClass();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        ReferenceTruckSizes rts;
        private int ID = -1;
        public AddTruck_popWindows(ManageTrucks_Form parent)
        {
            InitializeComponent();
            referenceSizeInitialize();
            truckTypeInitialize();
            this.parent = parent;
        }

        public AddTruck_popWindows(ManageTrucks_Form parent, int ID)
        {
            InitializeComponent();
            referenceSizeInitialize();
            truckTypeInitialize();
            this.Text = "EDIT TRUCK";
            this.parent = parent;
            this.ID = ID;
            add_btn.Text = "CONFIRM CHANGES";
            reupdateItself();
        }

        private void reupdateItself()
        {
            DataTable data = sql.ExecuteQuery($"SELECT * FROM Truck_Table WHERE id = {ID};");
            foreach (DataRow row in data.Rows)
            {
                platenumber_tb.Text = row["platenumber"].ToString();
                trucktype_cb.Text = row["trucktype"].ToString();
                length_tb.Text = row["_length"].ToString();
                width_tb.Text = row["_width"].ToString();
                height_tb.Text = row["_height"].ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (filter.AreAllInputsFilled(trucktype_cb, platenumber_tb, length_tb, width_tb, height_tb) && !sql.DoesDataExist("Truck_Table","platenumber",platenumber_tb.Text))
            {
                if (ID == -1) CommitAddTruck();
                else RewriteTruck();
                parent.updateVisual();
                this.Dispose();
            }
            else MessageBox.Show("Please fill up all the empty boxes or avoid using exactly the same platenumber");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void truckTypeInitialize()
        {
            trucktype_cb.Items.Clear();
            foreach (DataRow row in sql.ExecuteQuery("SELECT trucktype FROM Truck_Table WHERE is_deleted = 0").Rows) trucktype_cb.Items.Add(row[0].ToString());
        }
        private void referenceSizeInitialize()
        {
            referencesize_cb.Items.Clear();
            foreach (DataRow row in sql.ExecuteQuery("SELECT platenumber FROM Truck_Table WHERE is_deleted = 0").Rows) referencesize_cb.Items.Add(row[0].ToString());
        }

        private void CommitAddTruck() //CHANGE THIS WHEN INTEGRATING IT TO DIFFERENT DB SYSTEM
        {

                Dictionary<string, object> values = new Dictionary<string, object> {
                {"platenumber",platenumber_tb.Text},
                {"trucktype",trucktype_cb.Text },
                {"_length", Convert.ToDecimal(length_tb.Text) },
                {"_width", Convert.ToDecimal(width_tb.Text) },
                {"_height", Convert.ToDecimal(height_tb.Text) }
            };

                sql.InsertData("Truck_Table", values);



        }

        private void RewriteTruck()// CHANGE THIS WHEN INTEGRATING IT TO DIFFERENT DB SYSTEM, 
        {
            string query = $"UPDATE Truck_Table " +
                           $"SET platenumber = '{platenumber_tb.Text}', " +
                           $"trucktype = '{trucktype_cb.Text}', " +
                           $"_length = {length_tb.Text}, " +
                           $"_width = {width_tb.Text}, " +
                           $"_height = {height_tb.Text} " +
                           $"WHERE id = {ID};";

            sql.ExecuteQuery(query);

        }

        private void platenumber_tb_TextChanged(object sender, EventArgs e)
        {
            filter.SanitizeSQLInput(platenumber_tb);
        }

        private void width_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(width_tb);
        }

        private void height_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(height_tb);
        }

        private void trucktype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            filter.SanitizeSQLInput(trucktype_cb);
        }

        private void length_tb_TextChanged(object sender, EventArgs e)
        {
            filter.ValidateNumericInput(length_tb);
        }

        private void referencesize_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            rts = new ReferenceTruckSizes(referencesize_cb.Text);
            length_tb.Text = rts.length.ToString();
            width_tb.Text = rts.width.ToString();
            height_tb.Text = rts.height.ToString();
        }
    }

    class ReferenceTruckSizes
    {
        public decimal length;
        public decimal width;
        public decimal height;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        public ReferenceTruckSizes(string plate_number)
        {
            DataRow rowDimension = sql.ExecuteQuery($"SELECT * FROM Truck_Table WHERE platenumber = '{plate_number}' AND is_deleted = 0;").Rows[0];
            length = Convert.ToDecimal(rowDimension["_length"]);
            width = Convert.ToDecimal(rowDimension["_width"]);
            height = Convert.ToDecimal(rowDimension["_height"]);
        }
    }
}
