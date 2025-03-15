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

namespace MyWinFormsApp.Sections.ManageItems
{
    public partial class ViewPerItem_Form : Form
    {
        ManageItems_form parent;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        int id;
        public ViewPerItem_Form(string clientname, string itemname, decimal length, decimal width, decimal height, string fluteCode, int id, ManageItems_form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.id = id;
            client_label.Text = $"Client: {clientname}";
            itemname_label.Text = itemname;
            flute_label.Text = $"FluteType: {fluteCode}";
            content_label.Text = $"Length(mm):     {length}\n" +
                                 $"Width(mm) :     {width}\n" +
                                 $"Height(mm):     {height}\n" +
                                 $"Dimension (mm): {height * width * width}";
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DeleteMyValue();
            parent.UpdateVisual();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddNewItems_WindowPopUpForm aniwpuf = new AddNewItems_WindowPopUpForm(parent, id);
            aniwpuf.ShowDialog();
            parent.UpdateVisual();
        }
        private void DeleteMyValue()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            sql.ExecuteQuery($"UPDATE Item_Table SET is_deleted = 1 WHERE id = {id}");

        }
    }
}
