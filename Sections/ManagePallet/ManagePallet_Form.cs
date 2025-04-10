using MyWinFormsApp.SupportClass;
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
    public partial class ManagePallet_Form : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        Scalingsupport scale = new Scalingsupport();
        List<PalletSelectView_Form> list = new List<PalletSelectView_Form>();
        public ManagePallet_Form()
        {
            InitializeComponent();
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
        private void add_btn_Click(object sender, EventArgs e)
        {
            AddPallet_windowpopup adwp = new AddPallet_windowpopup(this);
            adwp.ShowDialog();
        }

        public void UpdateVisual()
        {
            resetFilter();
            add_btn.Size = scale.ScaleObject(add_btn.Size);
            resetList();
            DataTable data = sql.ExecuteQuery($"SELECT * FROM Pallet_Table WHERE is_deleted = 0");
            foreach (DataRow row in data.Rows)
            {
                PalletSelectView_Form psvf = new PalletSelectView_Form(
                    Convert.ToInt32(row["id"]),
                    Convert.ToInt32(row["_length"]),
                    Convert.ToInt32(row["_width"]),
                    Convert.ToInt32(row["_height"]),
                    row["name"].ToString(),
                    this
                    );
                psvf.TopLevel = false;
                storedarea_flt.Controls.Add(psvf);
                psvf.Show();
                list.Add(psvf);
            }

            noresult();
        }

        private void resetList()
        {
            foreach (PalletSelectView_Form form in list)
            {
                form.Dispose();
            }
            list.Clear();
        }

        private void ManagePallet_Form_VisibleChanged(object sender, EventArgs e)
        {
            SetGradientBackground("#D4ECD7", "#B2E2B8");
            UpdateVisual();
        }

        private void resetFilter()
        {
            searchname_tb.Text = "ex. Standard Pallet";
            searchname_tb.ForeColor = Color.Gray;
            setSearchFilter();
        }

        private void setSearchFilter()
        {
            FilterInputSupportClass filter = new FilterInputSupportClass();
            foreach (PalletSelectView_Form f in list)
            {
                bool _name = searchname_tb.Text == "ex. Standard Pallet" || string.IsNullOrEmpty(searchname_tb.Text) || (filter.ContainsSimilarSubstring(f.palletname, searchname_tb.Text));
                f.Visible = _name;
            }
            noresult();

        }

        private void storedarea_flt_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchname_tb_TextChanged(object sender, EventArgs e)
        {
            setSearchFilter();
        }

        private void searchname_tb_Enter(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "ex. Standard Pallet")
            {
                searchname_tb.Text = "";
                searchname_tb.ForeColor = Color.Black;
            }
        }

        private void searchname_tb_Leave(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "")
            {
                searchname_tb.Text = "ex. Standard Pallet";
                searchname_tb.ForeColor = Color.Gray;
            }
        }

        private void noresult()
        {
            int a = 0;
            foreach (PalletSelectView_Form f in list) a += f.Visible ? 1 : 0;
            a = Math.Min(a, list.Count);
            _no_result.Visible = a < 1;
        }

        private void ManagePallet_Form_Load(object sender, EventArgs e)
        {
            UpdateVisual();
        }
    }
}
