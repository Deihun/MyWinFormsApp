using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MyWinFormsApp.Sections.Estimate
{
    public partial class Text_Unit_Conversion_list : UserControl
    {
        string input = "";
        string outputText = "";
        double baselinenumber = 0;
        public Text_Unit_Conversion_list(string input)
        {
            InitializeComponent();
            this.input = input;
            this.Margin = new Padding(0);
            this.Padding = new Padding(0);

            Match match = Regex.Match(input, @"%#%(\d.+)%#%");

            if (match.Success)
            {
                baselinenumber = double.Parse(match.Groups[1].Value);
                outputText = Regex.Replace(input, @"%#%\d.+%#%", "").Trim();
            }
            else
            {
                MessageBox.Show($"ERROR// value{match.Value}");
            }

                unit_cb.SelectedIndex = 0;
            updateContext();
        }


        private void updateContext()
        {
            double result = 0.0;
            
            switch (unit_cb.SelectedItem)
            {
                case "mm":
                    result = baselinenumber;
                    break;
                case "cm":
                    result = baselinenumber / 10;
                    break;
                case "inches":
                    result = baselinenumber / 25.4;
                    break;
                case "m":
                    result = baselinenumber / 1000;
                    break;
            }
            content_label.Text = $"{outputText} {Math.Round(result,2)}";
            this.Size = new Size(Convert.ToInt32(content_label.Text.Length*10.5) + 80, Height);
        }

        private void unit_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateContext();
        }
    }
}
