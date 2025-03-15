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

namespace MyWinFormsApp.Sections.ManageItems.Flute
{
    public partial class ManageFlute_WindowPopupForm : Form
    {
        List<ShowExistingFlute_Form> list = new List<ShowExistingFlute_Form>();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        int ID = -1;
        public ManageFlute_WindowPopupForm()
        {
            InitializeComponent();
            UpdateVisual();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void UpdateVisual()
        {
            resetList();
            DataTable dt = sql.ExecuteQuery("SELECT * FROM Flute_Table WHERE is_deleted = 0;");
            foreach (DataRow row in dt.Rows)
            {
                ShowExistingFlute_Form seff = new ShowExistingFlute_Form(
                    Convert.ToInt32(row["id"]), 
                    row["code_name"].ToString(),
                    Convert.ToDecimal(row["_value"]),
                    (decimal)0.0, //CHANGE THIS LATER
                    (decimal)0.0,//CHANGE THIS LATER
                    this
                    );

                seff.TopLevel = false;
                flutecontainer_flp.Controls.Add(seff);
                seff.Show();
                list.Add(seff); 
            }
        }

        private void resetList()
        {
            foreach (ShowExistingFlute_Form form in list) form.Dispose();
            list.Clear();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddOrEditFlute_windowpopupform aoefwpf = new AddOrEditFlute_windowpopupform(this);
            aoefwpf.ShowDialog();
        }
    }
}
