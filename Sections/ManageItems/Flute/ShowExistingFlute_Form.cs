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

namespace MyWinFormsApp.Sections.ManageItems.Flute
{
    public partial class ShowExistingFlute_Form : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        ManageFlute_WindowPopupForm parent;
        int ID;
        public ShowExistingFlute_Form(int ID, string name, decimal standard, decimal target_from,decimal target_to, decimal tolerance, ManageFlute_WindowPopupForm parent)
        {
            InitializeComponent();
            this.ID = ID;
            this.parent = parent;
            this.flutetype_label.Text = name;
            this.content_label.Text = $"Standard(mm): {standard}\n" +
                                      $"Target(mm):   {target_from}-{target_to}\n" +
                                      $"Tolerance(mm):{tolerance}";
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
                sql.ExecuteQuery($"UPDATE Flute_Table SET is_deleted = 1 WHERE id = {ID}");
                parent.UpdateVisual();
                sql.commitReport($"A Data Flute '{flutetype_label.Text}' was deleted");
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddOrEditFlute_windowpopupform aoefwpuf = new AddOrEditFlute_windowpopupform(parent, ID);
            aoefwpuf.ShowDialog();
        }
    }
}
