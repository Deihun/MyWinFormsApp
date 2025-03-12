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
        public clientselectView_form(Estimate_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            instantiateCombobox();
        }

        public void instantiateCombobox()
        {
            client_combobox.Items.Clear();
            client_combobox.Items.Add("<Select a Client>");
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table").Rows) client_combobox.Items.Add(row["name"]);
            client_combobox.SelectedIndex = 0;
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            parent.clientList.Remove(this);
            this.Dispose();
            parent.UpdateSelectionWithinChange();
            parent.UpdateVisual();
        }

        public int getMyID()
        {
            if (client_combobox.SelectedIndex == 0) return -1;
            return Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Client_Table WHERE name = '{client_combobox.Text}'").Rows[0][0]);
        }

        private void client_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            parent.UpdateSelectionWithinChange();
            parent.UpdateVisual();
        }
    }
}
