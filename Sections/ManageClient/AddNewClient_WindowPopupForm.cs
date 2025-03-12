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
    public partial class AddNewClient_WindowPopupForm : Form
    {
        int ID = -1;
        ManageClient_Form parent;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        public AddNewClient_WindowPopupForm(ManageClient_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public AddNewClient_WindowPopupForm(ManageClient_Form parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.ID = id;

            this.Text = "EDIT CLIENT";
            this.add_btn.Text = "CONFIRM CHANGES";

            DataRow row = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE id = {ID}").Rows[0];
            clientname_tb.Text = row["name"].ToString();
            description_rtb.Text = row["description"].ToString();
            setCheckmarks(row["filter"].ToString());
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (ID == -1) add_client();
            else rewrite_client();
            parent.UpdateVisual();
                this.Dispose();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void add_client() //MODIFY THIS WHEN INTEGRATING FROM LOCAL TO CONNECTED DB
        {
            Dictionary<string, object> value = new Dictionary<string, object>()
            {
                { "name", clientname_tb.Text },
                {"description", description_rtb.Text },
                {"filter", getCheckmarks() }
            };
            sql.InsertData("Client_Table", value);
            
        }

        private void rewrite_client()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO CONNECTED DB
        {

        }

        private string getCheckmarks()
        {
            string conditions = $"\"pallet_required\": {requirepallet_cb.Checked.ToString().ToLower()}";

            return $"{{ {conditions} }}";
        }


        private void setCheckmarks(string raw_data)
        {

        }
    }
}
