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

namespace MyWinFormsApp.Sections.ManagePallet
{
    public partial class PalletSelectView_Form : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS","TruckEstimationSystem",null,null);
        ManagePallet_Form parent;
        int ID = -1;
        public string palletname = "";
        public PalletSelectView_Form(int iD, int length, int width, int height, string name, ManagePallet_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            id_label.Text = $"ID: {iD}";
            content_label.Text = $"Length(mm): {length}\n" +
                                 $"Width(mm) : {width}\n" +
                                 $"Height(mm): {height}\n" +
                                 $"Volume(mm): {length*width*height}";
            name_label.Text = name;
            palletname = name;
            ID = iD;
            SetGradientBackground("#FFFFFF", "#E6E5E5");
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
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddPallet_windowpopup apwp = new AddPallet_windowpopup(parent, ID);
            apwp.ShowDialog();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            deleteSelfIDPallet();
            this.parent.UpdateVisual();
        }

        private void deleteSelfIDPallet() //MODIFY THIS WHEN CHANGING FROM LOCALDB TO INTEGRATED DB
        {
            DialogResult result = MessageBox.Show(
                "Once this data is deleted, it can no longer be retrieve. Are you sure?",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation);

            if (result == DialogResult.Yes)
            {
                sql.ExecuteQuery($"UPDATE Pallet_Table SET is_deleted = 1 WHERE id = {ID}");
                sql.commitReport($"A data Pallet '{palletname}' was deleted");
            }
        }
    }
}
