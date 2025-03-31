using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp.SupportClass
{
    public partial class ListSelector : Form
    {
        private Action<string> returning_string;
        private Action reset_string;
        private FilterInputSupportClass filter = new FilterInputSupportClass();
        public ListSelector(Action<string> method,Action reset, List<string> List_of_Categories)
        {
            InitializeComponent();
            this.returning_string = method;
            this.reset_string = reset;
            create_delete();
            foreach (string a in List_of_Categories)
            {
                if (string.IsNullOrEmpty(a)) continue;
                create_button(a);
            }
        }
        private Button create_delete()
        {
            Button button = new Button();
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.Text = $"SELECT NONE";
            button.Width = stored_flp.Width - 10;
            button.Click += button_forReset;
            stored_flp.Controls.Add(button);
            button.Show();
            return button;
        }
        private Button create_button(string name)
        {
            Button button = new Button();
            button.FlatStyle = FlatStyle.Flat;
            button.BackColor = Color.White;
            button.Text = $"SELECT  <{name}>";
            button.Tag = name;
            button.Width = stored_flp.Width - 10;
            button.Click += button_is_click;
            stored_flp.Controls.Add(button);
            button.Show();
            return button;
        }

        private void button_is_click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            returning_string?.Invoke(filter.RemoveSQLInjectionRisks(button.Tag.ToString()).ToUpper());
            this.Dispose();
        }
        private void button_forReset(object sender, EventArgs e)
        {
            Button button = sender as Button;
            reset_string?.Invoke();
            Dispose();
        }

        private void Input_tb_Enter(object sender, EventArgs e)
        {
            if (Input_tb.Text.Equals("Enter new category..."))
            {
                Input_tb.Text = string.Empty;
                Input_tb.ForeColor = Color.Black;
            }
        }

        private void Input_tb_Leave(object sender, EventArgs e)
        {
            if (Input_tb.Text.Equals(""))
            {
                Input_tb.Text = "Enter new category...";
                Input_tb.ForeColor = Color.DimGray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Input_tb.Text.Equals("Enter new category...") || Input_tb.Text.Equals("")) return;
            returning_string?.Invoke(filter.RemoveSQLInjectionRisks(Input_tb.Text).ToUpper());
            this.Dispose();
        }
    }
}
