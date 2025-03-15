using MyWinFormsApp.Sections.ManageItems;
using MyWinFormsApp.Sections.ManageItems.Flute;
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

namespace MyWinFormsApp.Sections
{
    public partial class ManageItems_form : Form
    {
        Scalingsupport scalingsupport = new Scalingsupport();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        List<ViewPerItem_Form> list = new List<ViewPerItem_Form>();
        public ManageItems_form()
        {
            InitializeComponent();


        }


        public void UpdateVisual()
        {
            
            searchname_tb.Size = scalingsupport.ScaleObject(searchname_tb.Size);
            flutetype_cb.Size = scalingsupport.ScaleObject(flutetype_cb.Size);
            add_btn.Size = scalingsupport.ScaleObject(add_btn.Size);
            DataTable dt = sql.ExecuteQuery("SELECT * FROM Item_Table WHERE is_deleted = 0");
            resetList();
            foreach (DataRow row in dt.Rows)
            {
                string clientName = sql.ExecuteQuery($"SELECT name FROM Client_Table WHERE id = {Convert.ToInt32(row["client_id"])}").Rows[0][0].ToString();
                string fluteType = sql.ExecuteQuery($"SELECT code_name FROM Flute_Table WHERE id = {Convert.ToInt32(row["flute_id"])}").Rows[0][0].ToString();
                decimal fluteValue = Convert.ToDecimal(sql.ExecuteQuery($"SELECT _value FROM Flute_Table WHERE id = {Convert.ToInt32(row["flute_id"])}").Rows[0][0]);
                ViewPerItem_Form vpif = new ViewPerItem_Form(
                    clientName, row["item_name"].ToString(), Convert.ToDecimal(row["_length"]), Convert.ToDecimal(row["_width"]), fluteValue, fluteType, Convert.ToInt32(row["id"]), this
                    );

                vpif.TopLevel = false;
                storedarea_flt.Controls.Add(vpif);
                vpif.Show();
                list.Add(vpif);
            }
            
        }
        private void resetList()
        {
            foreach (ViewPerItem_Form form in list) form.Dispose();
            list.Clear();
        }

        private void tablelayout_main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_tb_TextChanged(object sender, EventArgs e)
        {

        }




        private void ManageItems_form_VisibleChanged(object sender, EventArgs e)
        {
            UpdateVisual();


        }

        private void flutetype_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void manageflute_btn_Click(object sender, EventArgs e)
        {
            ManageFlute_WindowPopupForm mfwpuf = new ManageFlute_WindowPopupForm();
            mfwpuf.ShowDialog();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            AddNewItems_WindowPopUpForm aniwpuf = new AddNewItems_WindowPopUpForm(this);
            aniwpuf.ShowDialog();
        }
    }
}
