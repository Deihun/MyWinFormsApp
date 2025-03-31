using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWinFormsApp.SupportClass;
using Newtonsoft.Json;
using SQLSupportLibrary;

namespace MyWinFormsApp.Sections.ManageClient
{
    public partial class ExistingSelectClient_form : Form
    {
        int ID;
        public string client_name;
        public string category = "";
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        ManageClient_Form parent;
        public ExistingSelectClient_form(int id, string name, string description, string raw_condition, string category, ManageClient_Form parent)
        {
            InitializeComponent();
            this.ID = id;
            this.parent = parent;
            clientname_label.Text = name;
            client_name = name;
            this.category = category;
            description_label.Text = description;
            instantiateConditions(raw_condition);
            instantiateItemName();
        }
        private void instantiateItemName()
        {
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Segoe",12,FontStyle.Bold);
            label1.ForeColor = ColorTranslator.FromHtml("#282828");
            label1.Text = "ITEM OF THIS CLIENT";
            label1.Padding = new Padding(10, 0, 0, 0);
            stored_itemname_flp.Controls.Add(label1);
            label1.Show();
            foreach (DataRow row in sql.ExecuteQuery($"SELECT item_name FROM Item_Table WHERE client_id = {ID} AND is_deleted = 0").Rows)
            {
                Label label = new Label();
                label.AutoSize = true;
                label.ForeColor = ColorTranslator.FromHtml("#414040");
                label.Text = row["item_name"].ToString();
                label.Margin = new Padding(30, 0, 5, 0);
                stored_itemname_flp.Controls.Add(label);
                label.Show();
            }
        }
        private void instantiateConditions(string raw_condition)
        {
            raw_condition = raw_condition.Trim('(', ')');
            foreach (string _req in raw_condition.Split('%').ToList())
            {
                Label label = new Label();
                label.AutoSize = true;
                label.Text = _req;
                label.ForeColor = Color.DarkRed;
                conditioncontainer_flp.Controls.Add(label);
                label.Show();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DeleteMyValue();
            this.parent.resetFilter();
            this.parent.TriggerVisualUpdate();
            this.parent.updatePageSelector();
        }

        private void DeleteMyValue()//MODIFY THIS IF INTEGRATING FROM LOCAL TO SHARE
        {
            DialogResult result = MessageBox.Show(
            "Once this data is deleted, it can no longer be retrieve. Are you sure?",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes) 
            {
                sql.ExecuteQuery($"UPDATE Client_Table SET is_deleted = 1 WHERE id = {ID}");
                sql.commitReport($"A Data Client '{clientname_label.Text}' was modified");
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddNewClient_WindowPopupForm ancwpf = new AddNewClient_WindowPopupForm(parent, ID);
            ancwpf.ShowDialog();
        }

        private void clientname_label_Click(object sender, EventArgs e)
        {

        }

        private void conditioncontainer_flp_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clientname_label_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
