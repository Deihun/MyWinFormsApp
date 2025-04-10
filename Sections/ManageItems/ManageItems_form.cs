using COMBINE_CHECKLIST_2024.DateToText;
using MyWinFormsApp.Sections.ManageItems;
using MyWinFormsApp.Sections.ManageItems.Flute;
using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp.Sections
{
    public partial class ManageItems_form : Form
    {
        private Scalingsupport scalingsupport = new Scalingsupport();
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private PageSelection page;
        private main_startup_form parent;

        private List<ViewPerItem_Form> list = new List<ViewPerItem_Form>();
        private List<CheckBox> categ_list = new List<CheckBox>();
        private List<FlowLayoutPanel> pages = new List<FlowLayoutPanel>();

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;

        private const int object_perPage = 4;
        private int max_count = 0;
        private int selected_page = 1;

        public ManageItems_form(main_startup_form parent)
        {
            InitializeComponent();
            page = new PageSelection(2, whenPageIsSelected);
            panel1.Controls.Add(page);
            page.Show();

            this.parent = parent;

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 100;
            updateTimer.Tick += (s, e) =>
            {
                updateTimer.Stop();
                UpdateVisual();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 100;
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _update_page_selection();
            };
        }



        //VISUALS
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
        public void TriggerVisualUpdate()
        {
            if (updateTimer.Enabled) return;
            updateTimer.Start();
        }


        public void UpdateVisual()
        {
            foreach (FlowLayoutPanel control in pages) control.Dispose();
            pages.Clear();

            int object_created_count = 0;
            int current_page_now = 0;
            add_page();

            foreach (DataRow row in get_ItemTable_IDs().Rows)
            {
                var form = create_viewPerItem(Convert.ToInt32(row["id"]));
                pages[current_page_now].Controls.Add(form);
                form.Show();
                object_created_count++;
                Debug.WriteLine($"CurrentObjectNo: {object_created_count}, pageCodeNumber:{current_page_now}, id {row["id"]}");
                if (object_created_count % object_perPage == 0)
                {
                    add_page();
                    current_page_now++;
                }
            }
            max_count = object_created_count;


            Debug.WriteLine($"DEBUG" +
                $"\n number_of_page = {current_page_now}, number_of_object = {max_count}");
            _NoResult();
            updatePageSelection();
            whenPageIsSelected(0);
        }

        
        private void _update_page_selection()
        {
            foreach (Control control in panel1.Controls) control.Dispose();
            panel1.Controls.Clear();
            decimal result = (decimal)max_count / object_perPage;
            var pages = Convert.ToInt32(Math.Ceiling(result));
            page = new PageSelection(pages, whenPageIsSelected);
            panel1.Controls.Add(page);
            page.Show();
        }


        public void updatePageSelection()
        {
            if (pageTimer.Enabled) return;
            pageTimer.Start();
        }



        private void whenPageIsSelected(int page)
        {
            foreach (FlowLayoutPanel flp in pages) flp.Hide();
            try
            {
                Debug.WriteLine($"Changing Page: {page}");
                pages[page].Show();
            }
            catch
            {
                MessageBox.Show("not normal paging detected");
                page = 0;
                pages[page].Show();
            }
        }




        //OBJECT SETTER
        private ViewPerItem_Form create_viewPerItem(int id)
        {
            ViewPerItem_Form form = new ViewPerItem_Form(id, this, parent);
            form.TopLevel = false;
            form.Show();
            return form;
        }


        private CheckBox create_category(string text)
        {
            CheckBox cb = new CheckBox();
            cb.Tag = text;
            cb.Text = text;
            cb.ForeColor = Color.White;
            cb.AutoSize = true;
            cb.Padding = new Padding(20, 0, 0, 0);
            flowLayoutPanel1.Controls.Add(cb);
            categ_list.Add(cb);
            cb.Show();
            cb.CheckedChanged += this.check;
            return cb;
        }


        public void resetFilter()
        {
            foreach (CheckBox c in categ_list) c.Dispose();
            categ_list.Clear();
            client_cb.Items.Clear();
            flutetype_cb.Items.Clear();
            client_cb.Items.Add("<select-client>");
            flutetype_cb.Items.Add("<select-flutetype>");

            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Flute_Table WHERE is_deleted = 0").Rows) flutetype_cb.Items.Add(row["code_name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted = 0").Rows) client_cb.Items.Add(row["name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Item_Table WHERE is_deleted = 0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                create_category(row["category"].ToString());
            }

            client_cb.SelectedIndex = 0;
            flutetype_cb.SelectedIndex = 0;
            searchname_tb.Text = "ex. Piatos Small";
            searchname_tb.ForeColor = Color.Gray;
        }


        private FlowLayoutPanel add_page()
        {
            FlowLayoutPanel flp = new FlowLayoutPanel();
            pages.Add(flp);
            storedarea_flt.Controls.Add(flp);
            flp.FlowDirection = FlowDirection.TopDown;
            flp.WrapContents = false;
            flp.AutoScroll = true;
            flp.BackColor = TransparencyKey;
            flp.Width = storedarea_flt.Width - 30;
            flp.Height = Height - 100;
            flp.Hide();
            return flp;
        }


        private DataTable get_ItemTable_IDs()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = @"SELECT DISTINCT item.id, MIN(item.item_name) AS item_name " +
                                   "FROM Item_Table item JOIN Flute_Table flute ON item.flute_id = flute.id " +
                                   " JOIN Client_Table client ON item.client_id = client.id WHERE item.is_deleted = 0 ";
            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piatos Small")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>")
                conditions.Add($"client.name LIKE '%{client_cb.Text}%'");

            if ((flutetype_cb.Text != "<select-flutetype>") && (flutetype_cb.Text != string.Empty))
                conditions.Add($"flute.code_name LIKE '%{flutetype_cb.Text}%'");
            foreach (CheckBox checkbox in categ_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"item.category = '{checkbox.Tag}'");
            }

            if (conditions.Count > 0)
                preset_query += $" AND ({string.Join(" AND ", conditions)})";
            if (category.Count > 0)
                preset_query += $" AND ({string.Join(" OR ", category)})";
            preset_query += $" GROUP BY item.id;";

            DataTable data = sql.ExecuteQuery(preset_query);
            return data;
        }




        //CONTROL EVENTS
        private void check(object sender, EventArgs e)
        {
            foreach (CheckBox c in categ_list)
            {
                if (sender is CheckBox cb) if (cb == c) continue;
                c.Checked = false;
            }
        }


        private void ManageItems_form_VisibleChanged(object sender, EventArgs e)
        {
            SetGradientBackground("#D4ECD7", "#B2E2B8");
            resetFilter();
            updatePageSelection();
            TriggerVisualUpdate();
            updatePageSelection();
        }


        private void manageflute_btn_Click(object sender, EventArgs e)
        {
            ManageFlute_WindowPopupForm mfwpuf = new ManageFlute_WindowPopupForm();
            mfwpuf.ShowDialog();
        }


        private void add_btn_Click(object sender, EventArgs e)
        {
            AddNewItems_WindowPopUpForm aniwpuf = new AddNewItems_WindowPopUpForm(this, parent);
            aniwpuf.ShowDialog();
        }


        private void searchname_tb_Enter(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "ex. Piatos Small")
            {
                searchname_tb.Text = "";
                searchname_tb.ForeColor = Color.Black;
            }
        }


        private void searchname_tb_Leave(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "")
            {
                searchname_tb.Text = "ex. Piatos Small";
                searchname_tb.ForeColor = Color.Gray;
            }
        }


        private void clear_btn_Click(object sender, EventArgs e)
        {
            resetFilter();
            TriggerVisualUpdate();
        }


        private void _NoResult()
        {
            _no_result.Visible = max_count < 1;
            label1.Visible = categ_list.Count > 0;
        }


        private void search_btn_Click(object sender, EventArgs e)
        {
            TriggerVisualUpdate();
        }
    }
}
