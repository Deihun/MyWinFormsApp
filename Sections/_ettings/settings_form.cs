using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private void flowLayoutPanel1_VisibleChanged(object sender, EventArgs e)
        {
            SetGradientBackground("#D4ECD7", "#B2E2B8");
        }

        private void SetGradientBackground(string hexColor1, string hexColor2)
        {
            Color color1 = ColorTranslator.FromHtml(hexColor1);
            Color color2 = ColorTranslator.FromHtml(hexColor2);

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, this.Width, this.Height),
                color1,
                color2,
                LinearGradientMode.Vertical)) // Change direction if needed
            {
                g.FillRectangle(brush, 0, 0, this.Width, this.Height);
            }
            this.BackgroundImage = bmp;
        }
    }
}
