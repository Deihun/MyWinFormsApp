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

namespace MyWinFormsApp.Sections.ManageBundles
{
    public partial class ManageBundles_Form : Form
    {
        Scalingsupport scale = new Scalingsupport();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        List<viewSelectedBundle_Form> list = new List<viewSelectedBundle_Form>();
        public ManageBundles_Form()
        {
            InitializeComponent();
        }

        private void flutetype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void UpdateVisual()
        {
            resetList();
            client_cb.Size = scale.ScaleObject(client_cb.Size);
            flutetype_cb.Size = scale.ScaleObject(flutetype_cb.Size);
            client_cb.Size = scale.ScaleObject(client_cb.Size);

            foreach(DataRow row in sql.ExecuteQuery("SELECT * FROM Bundle_Table WHERE is_deleted = 0;").Rows)
            {
                viewSelectedBundle_Form vsbf = new viewSelectedBundle_Form(this, Convert.ToInt32(row["id"]));
                vsbf.TopLevel = false;
                storedarea_flt.Controls.Add(vsbf);
                vsbf.Show();
                list.Add(vsbf);
            }
        }

        private void resetList()
        {
            foreach (viewSelectedBundle_Form form in list) form.Dispose();
            list.Clear();
        }
        private void ManageBundles_Form_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisual();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddEditBundle_windowpopupform aebwpuf = new AddEditBundle_windowpopupform(this);
            aebwpuf.ShowDialog();
        }
    }
}
