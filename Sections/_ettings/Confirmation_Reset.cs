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

namespace MyWinFormsApp.Sections._ettings
{
    public partial class Confirmation_Reset : Form
    {
        int cooldown = 5;
        public Confirmation_Reset()
        {
            InitializeComponent();
            label2.Text = $"{cooldown}";
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cooldown <= 0)
            {
                button2.Enabled = true;
                label2.Visible = false;
                timer1.Stop();
            }
            else
            {

                cooldown--;
                label2.Text = $"{cooldown}";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
            string a = @"TRUNCATE TABLE AddedClient_Table; 
                        TRUNCATE TABLE AddedBundle_Table;
                        TRUNCATE TABLE Bundle_Table;
                        TRUNCATE TABLE Item_Table;
                        TRUNCATE TABLE Client_Table;
                        TRUNCATE TABLE Flute_Table;
                        TRUNCATE TABLE Truck_Table;
                        TRUNCATE TABLE Record_Table;
                        TRUNCATE TABLE Pallet_Table;
                        TRUNCATE TABLE History_Table;";
            sql.ExecuteQuery(a);
            this.Dispose();
        }
    }
}
