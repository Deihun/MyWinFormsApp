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

namespace MyWinFormsApp.Sections.Estimate
{
    public partial class clientselectView_form : Form
    {
        Estimate_Form parent;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);

        public List<string> filter = new List<string>();
        private int id = -1;
        public clientselectView_form(Estimate_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        public clientselectView_form(Estimate_Form parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.id = id;
            DataRow client = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE id = {id}").Rows[0];
            clientname_label.Text = client["name"].ToString();
            description_label.Text = client["description"].ToString();
            seperate(client["filter"].ToString());
            create_warning_label();
            SetGradientBackground("#FFFFFF", "#A6A4A4");
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
        public List<string> getFilter()
        {
            return filter;
        }

        public void seperate(string raw_filter)
        {
            raw_filter = raw_filter.Trim('(', ')');
            filter = raw_filter.Split('%').ToList();
        }

        private void create_warning_label()
        {
            foreach (string f in filter)
            {
                Label l = new Label();
                l.ForeColor = Color.DarkRed;
                l.Text = f;
                l.AutoSize = false;
                storedfilter_flp.Controls.Add(l);
                l.Show();
            }
        }

    }
}
