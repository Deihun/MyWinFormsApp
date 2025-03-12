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

namespace MyWinFormsApp.Sections.ManageTrucks
{
    public partial class PreviewSelectedTruck_Form : Form //INCOMPLETE
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        ManageTrucks_Form parent;
        public int ID = -1;
        public PreviewSelectedTruck_Form(int iD, ManageTrucks_Form parent)
        {
            InitializeComponent();
            ID = iD;
            setup();
            this.parent = parent;
        }

        public void setup() //SQLQUERY FOR LOCAL
        {
            string query = $"SELECT * FROM Truck_Table WHERE id = {ID}";
            DataTable data = sql.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                int _length = Convert.ToInt32(row["_length"]);
                int _width = Convert.ToInt32(row["_width"]);
                int _height = Convert.ToInt32(row["_height"]);
                int dimension = _length * _width * _height;

                platenumber_label.Text = row["platenumber"].ToString();
                trucktype_label.Text = row["trucktype"].ToString();

                dimensions_label.Text = $"Length: {_length}\nWidth: {_width}\nHeight: {_height}\nDimension: {dimension}";
            }
        }

        private void DeleteMyData()
        {
            sql.ExecuteQuery($"DELETE FROM Truck_Table WHERE id = {ID}");
            parent.updateVisual();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Once this data is deleted, it can no longer be retrieve. Are you sure?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation
);

            if (result == DialogResult.Yes)
            {
                DeleteMyData();
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddTruck_popWindows edit = new AddTruck_popWindows(parent, ID);
            edit.ShowDialog();
        }

        public void updateSizes()
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
