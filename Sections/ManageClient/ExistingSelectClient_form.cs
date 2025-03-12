using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using SQLSupportLibrary;

namespace MyWinFormsApp.Sections.ManageClient
{
    public partial class ExistingSelectClient_form : Form
    {
        int ID;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        ManageClient_Form parent;
        public ExistingSelectClient_form(int id, string name, string description, string raw_condition, ManageClient_Form parent)
        {
            InitializeComponent();
            this.ID = id;
            this.parent = parent;
            clientname_label.Text = name;
            description_label.Text = description;
            instantiateConditions(raw_condition);
        }

        private void instantiateConditions(string raw_condition)
        {
            Dictionary<string, bool> rawcondition = JsonConvert.DeserializeObject<Dictionary<string, bool>>(raw_condition);

            foreach (var condition in rawcondition)
            {
                if (condition.Value)
                {
                    string content = "";

                    switch (condition.Key)
                    {
                        case "pallet_required":
                            content = "* Requiring Pallet";
                            break;
                        case "clearance_space_required":
                            content = "* Requiring Clearance Space";
                            break;
                    }

                    Label label = new Label();
                    label.Text = content;
                    label.ForeColor = Color.DarkRed;
                    conditioncontainer_flp.Controls.Add(label);
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DeleteMyValue();
            parent.UpdateVisual();
        }

        private void DeleteMyValue()//MODIFY THIS IF INTEGRATING FROM LOCAL TO SHARE
        {
            DialogResult result = MessageBox.Show(
            "Once this data is deleted, it can no longer be retrieve. Are you sure?",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes) sql.ExecuteQuery($"DELETE FROM Client_Table WHERE id = {ID}");
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddNewClient_WindowPopupForm ancwpf = new AddNewClient_WindowPopupForm(parent, ID);
            ancwpf.ShowDialog();
        }
    }
}
