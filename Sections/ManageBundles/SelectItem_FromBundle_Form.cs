using MyWinFormsApp.SupportClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruckEstimation.Sections.ManageBundles
{
    public partial class SelectItem_FromBundle_Form : Form
    {
        private FilterInputSupportClass filter = new FilterInputSupportClass();
        private Action<int> set_id;
        private List<Button> button_list = new List<Button>();
        public SelectItem_FromBundle_Form(Dictionary<int, string> items, Action<int> method)
        {
            InitializeComponent();
            this.set_id = method;
            foreach (var item in items)
            {
                create_button_item(item.Key, item.Value);
            }
        }

        private Button create_button_item(int id, string name)
        {
            Button button = new Button();
            button.Width = flp.Width - 20;
            button.Text = name;
            button.Tag = id;
            flp.Controls.Add(button);
            button_list.Add(button);
            button.Show();
            button.Click += click_trigger;
            return button;
        }

        private void click_trigger(Object sender, EventArgs e)
        {
            Button button = sender as Button;
            set_id.Invoke(Convert.ToInt32(button.Tag));
            Dispose();
        }

        private void Search_TB_TextChanged(object sender, EventArgs e)
        {
            foreach (Button b in button_list)
            {
                b.Visible = filter.ContainsSimilarSubstring(b.Text.ToUpper(), Search_TB.Text.ToUpper(), 2) || string.IsNullOrWhiteSpace(Search_TB.Text);
            }
        }
    }
}
