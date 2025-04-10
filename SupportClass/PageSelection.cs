using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyWinFormsApp.SupportClass
{
    public partial class PageSelection : UserControl
    {
        private int max_pagenumber;
        private int selected_pagenumber;
        private List<Button> pagebutton_list = new List<Button>();
        private List<Label> previewLabel_list = new List<Label>();

        public Action<int> page_onceselected;

        public PageSelection(int max_pagenumber, Action<int> page_onceselected)
        {
            InitializeComponent();
            this.max_pagenumber = Math.Max(1, max_pagenumber);
            this.page_onceselected = page_onceselected;

            selected_pagenumber = 1; // Start at page 1

            instantiatePageNumberButton();
        }
        public void reinstantiate(int max_pagenumber)
        {
            this.max_pagenumber = max_pagenumber;
            foreach (Control control in pagebutton_list) control.Dispose();
            foreach (Control control in previewLabel_list) control.Dispose();
            previewLabel_list.Clear();
            pagebutton_list.Clear();
            instantiatePageNumberButton();
        }

        private Label create_preview_label(string text = "...", bool addOnButtonPage = true)
        {
            Label label = new Label();
            label.Text = text;
            label.AutoSize = true;
            previewLabel_list.Add(label);
            if (addOnButtonPage) flowLayoutPanel1.Controls.Add(label);
            label.Show();
            return label;
        }

        private Button create_page_button(int page)
        {
            Button button = new Button
            {   
                FlatStyle = FlatStyle.Flat,
                AutoSize = true,
                Text = page.ToString(),
                BackColor = (page == selected_pagenumber) ? Color.LightBlue : Color.White,
                Tag = page
            };
            button.Width = 10;
            button.AutoSize = true;
            button.Click += pagebutton_is_click;
            flowLayoutPanel1.Controls.Add(button);
            pagebutton_list.Add(button);
            button.Show();
            return button;
        }

        private void instantiatePageNumberButton()
        {
            this.Visible = max_pagenumber > 1;
            instantiatePageNumberButton(selected_pagenumber);
        }

        private void instantiatePageNumberButton(int selected_page)
        {
            selected_pagenumber = selected_page;
            foreach (Control control in pagebutton_list) control.Dispose();
            foreach (Control control in previewLabel_list) control.Dispose();
            previewLabel_list.Clear();
            pagebutton_list.Clear();

            if (max_pagenumber <= 9)
            {
                for (int i = 1; i <= max_pagenumber; i++)
                {
                    create_page_button(i);
                }
                return;
            }

            if (too_away_from_bottom_page()) create_page_button(1);

            int start_page = Math.Max(1, selected_pagenumber - 4);
            int end_page = Math.Min(max_pagenumber , selected_pagenumber + 4);
            //MessageBox.Show($"startpage {start_page}, endpage {end_page}, {max_pagenumber}, {selected_page}");

            if (start_page > 2) create_preview_label();
            for (int i = start_page; i < end_page; i++)
            {
                create_page_button(i);
            }
            if (end_page < max_pagenumber - 1) create_preview_label();

            if (too_away_from_upper_page()) create_page_button(max_pagenumber-1);
        }

        private bool too_away_from_bottom_page()
        {
            return selected_pagenumber > 5;
        }

        private bool too_away_from_upper_page()
        {
            return selected_pagenumber < max_pagenumber - 4;
        }

        private void pagebutton_is_click(object sender, EventArgs e)
        {
            if (sender is Button button && int.TryParse(button.Tag.ToString(), out int page))
            {
                if (page == -1) return;

                page_onceselected?.Invoke(page-1);
                instantiatePageNumberButton(page);
            }
        }
        private void set_page(int input_page)
        {
            input_page = Math.Min(max_pagenumber, input_page);
            input_page = Math.Max(input_page, 1);
            page_onceselected?.Invoke(input_page-1);
            instantiatePageNumberButton(input_page);
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            set_page(selected_pagenumber - 1);
        }

        private void next_btn_Click(object sender, EventArgs e)
        {
            set_page(selected_pagenumber + 1);
        }
    }
}
