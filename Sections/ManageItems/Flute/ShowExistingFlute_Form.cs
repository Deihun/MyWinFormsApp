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
        public ShowExistingFlute_Form(int ID, string name, decimal standard, decimal target, decimal tolerance, ManageFlute_WindowPopupForm parent)
        {
            InitializeComponent();
            this.ID = ID;
            this.parent = parent;
            this.flutetype_label.Text = name;
            this.content_label.Text = $"Standard(mm): {standard}\n" +
                                      $"Target(mm):   {target}\n" +
                                      $"Tolerance(mm):{tolerance}";
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            sql.ExecuteQuery($"UPDATE Flute_Table SET is_deleted = 1 WHERE id = {ID}");
            parent.UpdateVisual();
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddOrEditFlute_windowpopupform aoefwpuf = new AddOrEditFlute_windowpopupform(parent, ID);
            aoefwpuf.ShowDialog();
        }
    }
}
