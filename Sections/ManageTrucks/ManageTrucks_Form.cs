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
    public partial class ManageTrucks_Form : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        List<PreviewSelectedTruck_Form> list = new List<PreviewSelectedTruck_Form>();
        public ManageTrucks_Form()
        {
            InitializeComponent();
            updateVisual();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddTruck_popWindows addtruck = new AddTruck_popWindows(this);
            addtruck.ShowDialog();
        }

        public void updateVisual()
        {
            removeAllTruckDataObject();
            DataTable data = sql.ExecuteQuery("SELECT id FROM Truck_Table WHERE is_deleted = 0;");
            foreach (DataRow row in data.Rows)
            {
                int settedID = Convert.ToInt32(row["id"]);
                PreviewSelectedTruck_Form pstf = new PreviewSelectedTruck_Form(settedID, this);
                pstf.TopLevel = false;
                pstf.Width = storedarea_flt.Width;
                storedarea_flt.Controls.Add(pstf);
                pstf.Show();
                list.Add(pstf);
            }
        }

        private void removeAllTruckDataObject()
        {
            foreach (PreviewSelectedTruck_Form f in list) f.Dispose();
            list.Clear();
        }
    }
}
