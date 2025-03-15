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
        public string filter = "";
        private int id = -1;
        public clientselectView_form(Estimate_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            instantiateCombobox();
        }

        public clientselectView_form(Estimate_Form parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.id = id;
            DataRow client = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE id = {id}").Rows[0];
            client_combobox.DropDownStyle = ComboBoxStyle.DropDown;
            client_combobox.Text = client["name"].ToString();
            description_label.Text = client["description"].ToString();
            client_combobox.Enabled = false;
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

        public string getFilter()
        {
            return filter;
        }

        public bool canBeSelected()
        {
            return (client_combobox.SelectedIndex != 0);
        }

        private void client_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (client_combobox.SelectedIndex > 0) 
            { 
              DataRow clientrow = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE name = '{client_combobox.Text}' AND is_deleted = 0").Rows[0];
              description_label.Text = clientrow["description"].ToString();
              filter = clientrow["filter"].ToString();
              description_label.ForeColor = Color.Black;
            }
            else if(client_combobox.Items.Count < 0)
            {
                description_label.ForeColor = Color.DimGray;
                description_label.Text = "There's no existing Client data. Please create a new Client Data";
                   
            }
            else
            {
                description_label.ForeColor = Color.DimGray;
                description_label.Text = "Select a Client";
            }
                parent.UpdateSelectionWithinChange();
            parent.UpdateVisual();
        }

    }
}
