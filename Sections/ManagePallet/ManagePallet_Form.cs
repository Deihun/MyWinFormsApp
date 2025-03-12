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
    public partial class ManagePallet_Form : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        Scalingsupport scale = new Scalingsupport();
        List<PalletSelectView_Form> list = new List<PalletSelectView_Form>();
        public ManagePallet_Form()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddPallet_windowpopup adwp = new AddPallet_windowpopup(this);
            adwp.ShowDialog();
        }

        public void UpdateVisual()
        {
            add_btn.Size = scale.ScaleObject(add_btn.Size);
            resetList();
            DataTable data = sql.ExecuteQuery("SELECT * FROM Pallet_Table");
            foreach (DataRow row in data.Rows)
            {
                PalletSelectView_Form psvf = new PalletSelectView_Form(
                    Convert.ToInt32(row["id"]),
                    Convert.ToInt32(row["_length"]),
                    Convert.ToInt32(row["_width"]),
                    Convert.ToInt32(row["_height"]),
                    row["name"].ToString(),
                    this
                    );
                psvf.TopLevel = false;
                storedarea_flt.Controls.Add(psvf);
                psvf.Show();
                list.Add(psvf);
            }
        }

        private void resetList()
        {
            foreach (PalletSelectView_Form form in list)
            {
                form.Dispose();
            }
            list.Clear();
        }

        private void ManagePallet_Form_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void storedarea_flt_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
