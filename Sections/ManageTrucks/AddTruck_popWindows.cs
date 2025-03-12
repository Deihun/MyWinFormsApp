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
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private int ID = -1;
        public AddTruck_popWindows(ManageTrucks_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public AddTruck_popWindows(ManageTrucks_Form parent, int ID)
        {
            InitializeComponent();
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
            if (ID == -1) CommitAddTruck();
            else RewriteTruck();
            parent.updateVisual();
            this.Dispose();
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

        private void CommitAddTruck() //CHANGE THIS WHEN INTEGRATING IT TO DIFFERENT DB SYSTEM
        {
            Dictionary<string, object> values = new Dictionary<string, object> {
                {"platenumber",platenumber_tb.Text},
                {"trucktype",trucktype_cb.Text },
                {"_length", Convert.ToInt32(length_tb.Text) },
                {"_width", Convert.ToInt32(width_tb.Text) },
                {"_height", Convert.ToInt32(height_tb.Text) }
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

        }
    }
}
