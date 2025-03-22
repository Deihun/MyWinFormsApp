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

namespace MyWinFormsApp.Sections._ettings
{
    public partial class settings_form : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        public settings_form()
        {
            InitializeComponent();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            History.SetToolTip(label1, "Checks the over-all logs of every actions perform within the system");
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            History.SetToolTip(label4, "Select a specified folder for a backup of Database which can be retrieve upon emergencies");
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            History.SetToolTip(label2, "WARNING! This action is cannot be undone, reset the whole database removing every data within the system.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql.BackupDatabase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"WARNING. Proceeding will replace the current data with a backup data. Any data lost will not be retrieve. Do you want to continue this process?", // Message text
"Confirmation",             // Title
MessageBoxButtons.YesNo,    // Buttons
MessageBoxIcon.Warning     // Icon
);

            if (result == DialogResult.Yes)
            {
                Sqlsupportlocal master = new Sqlsupportlocal(".\\SQLEXPRESS", "master", null, null);
                master.RestoreToExistingDatabase();
            }

        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            Confirmation_Reset c = new Confirmation_Reset();
            c.ShowDialog();
        }

        private void history_btn_Click(object sender, EventArgs e)
        {
            History_Log h = new History_Log();
            h.ShowDialog();
        }
    }
}
