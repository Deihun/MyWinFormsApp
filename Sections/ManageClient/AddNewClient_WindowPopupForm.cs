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

namespace MyWinFormsApp.Sections.ManageClient
{
    public partial class AddNewClient_WindowPopupForm : Form
    {
        int ID = -1;
        ManageClient_Form parent;
        RequirementsManagement_class req;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        FilterInputSupportClass filter = new FilterInputSupportClass();
        public AddNewClient_WindowPopupForm(ManageClient_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            setupRequirementManager();
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
            setupRequirementManager();
        }

        private void setupRequirementManager()
        {
            req = new RequirementsManagement_class(requirepallet_cb, requireclearancespace_cb);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            req = new RequirementsManagement_class(requirepallet_cb, requireclearancespace_cb);
            if (filter.AreAllInputsFilled(clientname_tb, description_rtb) && !sql.DoesDataExist("Client_Table", "name", clientname_tb.Text))
            {
                if (ID == -1) add_client();
                else rewrite_client();
                parent.UpdateVisual();
                this.Dispose();
            }
            else MessageBox.Show("Please fill up all the empty spaces or avoid using exactly the same name of Client that is already added");

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
                {"filter", req.getCheckmarks() }
            };
            sql.InsertData("Client_Table", value);

        }

        private void rewrite_client()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO CONNECTED DB
        {

        }




        private void setCheckmarks(string raw_data)
        {

        }

        private void clientname_tb_TextChanged(object sender, EventArgs e)
        {
            filter.SanitizeSQLInput(clientname_tb);
        }

        private void description_rtb_TextChanged(object sender, EventArgs e)
        {
            description_rtb.Text = description_rtb.Text.Replace("`", "");
            description_rtb.SelectionStart = description_rtb.Text.Length;
        }
    }
}
