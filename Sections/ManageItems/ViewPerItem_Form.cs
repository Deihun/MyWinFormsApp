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
        public string itemname = "";
        public string clientname = "";
        public string flutecode = "";
        public string category = "";
        public ViewPerItem_Form(string clientname, string itemname, decimal length, decimal width, decimal height, string fluteCode, int id, string category, string fcc, ManageItems_form parent, bool giveWarning = false)
        {
            InitializeComponent();
            this.parent = parent;
            this.id = id;
            client_label.Text = $"{clientname}";
            itemname_label.Text = itemname;
            flute_label.Text = $"FluteType: ({fluteCode.ToUpper()})";
            content_label.Text = $"Length(mm):     {Math.Round(length,2)}\n" +
                                 $"Width(mm) :     {Math.Round(width,2)}\n" +
                                 $"Height(mm):     {Math.Round(height,2)}\n" +
                                 $"Dimension (mm): {Math.Round(height * width * height, 0)}";
            this.fcc_label.Text = $"F.C. CONTROL No.:\n    {fcc}";
            this.category = category;
            this.itemname = itemname;
            this.clientname = clientname;
            this.flutecode = fluteCode;
            if (giveWarning) this.BackColor = Color.MistyRose;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Once this data is deleted, it can no longer be retrieve. Are you sure?",
"Warning",
MessageBoxButtons.YesNo,
MessageBoxIcon.Exclamation
);
            if (result == DialogResult.Yes)
            {
                sql.commitReport($"A data Item '{itemname}' was deleted");
                DeleteMyValue();
                parent.UpdateVisual();
            }
            else if (result == DialogResult.No)
            {
            }
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
