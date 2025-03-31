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
