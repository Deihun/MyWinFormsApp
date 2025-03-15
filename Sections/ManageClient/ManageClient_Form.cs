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

namespace MyWinFormsApp.Sections.ManageClient
{
    public partial class ManageClient_Form : Form
    {
        List<ExistingSelectClient_form> list = new List<ExistingSelectClient_form>();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        public ManageClient_Form()
        {
            InitializeComponent();
            UpdateVisual();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddNewClient_WindowPopupForm ancwpf = new AddNewClient_WindowPopupForm(this);
            ancwpf.ShowDialog();
        }

        public void UpdateVisual()
        {
            resetList();
            DataTable datatable = sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0;");
            foreach (DataRow row in datatable.Rows)
            {
                ExistingSelectClient_form escf = new ExistingSelectClient_form(
                    Convert.ToInt32(row["id"]),
                    row["name"].ToString(),
                    row["description"].ToString(),
                    row["filter"].ToString(),
                    this
                    );
                escf.TopLevel = false;
                storedarea_flt.Controls.Add(escf);
                escf.Show();
                list.Add(escf);
            }
        }

        private void resetList()
        {
            foreach (ExistingSelectClient_form form in list) form.Dispose();
            list.Clear();
        }
    }
}
