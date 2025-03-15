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

namespace MyWinFormsApp.Sections.Record
{
    public partial class ViewRecord_Form : Form
    {
        //<REFERENCE CLASS>
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        //<LIST>
        private List<ViewRecordSelection_Form> viewrecordselection_form_list = new List<ViewRecordSelection_Form>();
        public ViewRecord_Form()
        {
            InitializeComponent();
        }



        //** VISUAL CHANGES METHODS
        public void UpdateVisuals()//MODIFY THIS METHOD WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            foreach (Form f in viewrecordselection_form_list) f.Dispose();
            viewrecordselection_form_list.Clear();
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Record_Table WHERE is_deleted = 0;").Rows)
            {
                ViewRecordSelection_Form form = new ViewRecordSelection_Form(Convert.ToInt32(row["id"]), this);
                form.TopLevel = false;
                storedarea_flt.Controls.Add(form);
                viewrecordselection_form_list.Add(form);
                form.Show();
            }
        }




        // ** CONTROL EVENTS
        private void ViewRecord_Form_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisuals();
        }
    }
}
