using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace MyWinFormsApp.Sections.InstructionManual
{
    public partial class PreviewInstructions : UserControl
    {
        Dictionary<string, Image> image;
        int sections = 0;
        public PreviewInstructions(Dictionary<string, Image> image)
        {
            InitializeComponent();
            this.image = image;
            changeSection(0);
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
        private int changeSection(int addSections)
        {
            addSections = Math.Max(0, addSections);
            addSections = Math.Min(image.Count - 1, addSections);
            //MessageBox.Show($"CurrentIndex {sections}, {addSections}, {image.Count}");
            next_btn.Visible = addSections != (image.Count - 1);
            back_btn.Visible = addSections != 0;

            var item = image.ElementAt(addSections);
            description_label.Text = item.Key;
            pictureBox1.Image = item.Value;
            return addSections;
        }
        private void back_btn_Click(object sender, EventArgs e)
        {
            sections = changeSection(sections - 1);
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            sections = changeSection(sections + 1);
        }
    }
}
