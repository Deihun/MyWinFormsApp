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

namespace MyWinFormsApp.Sections.Estimate
{
    public partial class clientselectView_form : Form
    {
        Estimate_Form parent;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);

        public List<string> filter = new List<string>();
        private int id = -1;
        public clientselectView_form(Estimate_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public clientselectView_form(Estimate_Form parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.id = id;
            DataRow client = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE id = {id}").Rows[0];
            clientname_label.Text = client["name"].ToString();
            description_label.Text = client["description"].ToString();
            seperate(client["filter"].ToString());
            create_warning_label();
        }
        public List<string> getFilter()
        {
            return filter;
        }

        public void seperate(string raw_filter)
        {
            raw_filter = raw_filter.Trim('(', ')');
            filter = raw_filter.Split('%').ToList();
        }

        private void create_warning_label()
        {
            foreach (string f in filter)
            {
                Label l = new Label();
                l.ForeColor = Color.DarkRed;
                l.Text = f;
                l.AutoSize = false;
                storedfilter_flp.Controls.Add(l);
                l.Show();
            }
        }

    }
}
