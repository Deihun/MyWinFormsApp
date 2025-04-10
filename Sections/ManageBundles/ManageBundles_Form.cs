using COMBINE_CHECKLIST_2024.DateToText;
using MyWinFormsApp.Sections.ManageItems;
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

namespace MyWinFormsApp.Sections.ManageBundles
{
    public partial class ManageBundles_Form : Form
    {
        private Scalingsupport scale = new Scalingsupport();
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private PageSelection page;

        private List<viewSelectedBundle_Form> list = new List<viewSelectedBundle_Form>();
        private List<CheckBox> categ_list = new List<CheckBox>();
        private List<FlowLayoutPanel> pages = new List<FlowLayoutPanel>();

        private const int objects_perPage = 4;
        private int selected_page = 1;
        private int max_count = 0;

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;

        public ManageBundles_Form()
        {
            InitializeComponent();

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 5; // Delay for 100ms
            updateTimer.Tick += (s, e) =>
            {
                updateTimer.Stop();
                UpdateVisual();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 5; 
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _update_page_selector();

            };
        }




        //UPDATE VISUALS
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


        private void _update_page_selector()
        {
            foreach (Control control in panel2.Controls) control.Dispose();
            panel2.Controls.Clear();
            decimal result = (decimal)max_count / objects_perPage;
            var pages = Convert.ToInt32(Math.Ceiling(result));
            page = new PageSelection(pages, whenPageIsSelected);
            panel2.Controls.Add(page);
            page.Show();
        }


        public void updatePageSelector()
        {
            if (pageTimer.Enabled) return;
            pageTimer.Start();
        }


        public void UpdateVisual()
        {
            foreach (FlowLayoutPanel control in pages) control.Dispose();
            pages.Clear();

            int object_created_count = 0;
            int current_page_now = 0;
            add_page();

            foreach (DataRow row in getRecordTable_ID().Rows)
            {
                var form = create_selectedbundleForm(Convert.ToInt32(row["id"]));
                pages[current_page_now].Controls.Add(form);
                form.Show();
                object_created_count++;
                Debug.WriteLine($"CurrentObjectNo: {object_created_count}, pageCodeNumber:{current_page_now}, id {row["id"]}");
                if (object_created_count % objects_perPage == 0)
                {
                    add_page();
                    current_page_now++;
                }
            }
            max_count = object_created_count;

            Debug.WriteLine($"DEBUG" +
                $"\n number_of_page = {current_page_now}, number_of_object = {max_count}");
            noResult();
            updatePageSelector();
            whenPageIsSelected(0);
        }


        private void noResult()
        {
            _no_result.Visible = max_count < 1;
            label1.Visible = categ_list.Count > 0;
        }


        public void resetFilter()
        {
            foreach (Control c in categ_list) c.Dispose();
            categ_list.Clear();
            client_cb.Items.Clear();
            client_cb.Items.Add("<select-client>");
            flutetype_cb.Items.Clear();
            flutetype_cb.Items.Add("<select-flutetype>");
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Flute_Table WHERE is_deleted =0").Rows) flutetype_cb.Items.Add(row["code_name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Client_Table WHERE is_deleted =0").Rows) client_cb.Items.Add(row["name"].ToString());
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Bundle_Table WHERE is_deleted =0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                CheckBox check = new CheckBox();
                check.Text = row["category"].ToString();
                check.Tag = row["category"].ToString();
                check.AutoSize = true;
                check.ForeColor = Color.White;
                flowLayoutPanel1.Controls.Add(check);
                categ_list.Add(check);
                check.Padding = new Padding(20, 0, 0, 0);
                check.Show();
                check.CheckedChanged += this.check;
            }
            searchname_tb.Text = "ex. Piattos Small";
            searchname_tb.ForeColor = Color.Gray;
            client_cb.SelectedIndex = 0;
            flutetype_cb.SelectedIndex = 0;
        }



        //OBJECT SETTER
        private viewSelectedBundle_Form create_selectedbundleForm(int id)
        {
            viewSelectedBundle_Form vsbf = new viewSelectedBundle_Form(this, Convert.ToInt32(id));
            vsbf.TopLevel = false;
            storedarea_flt.Controls.Add(vsbf);
            vsbf.Show();
            list.Add(vsbf);
            return vsbf;
        }


        public void AddBundleFromCopy(int id)
        {
            AddEditBundle_windowpopupform aebwpf = new AddEditBundle_windowpopupform(this, id, true);
            aebwpf.ShowDialog();
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


        private DataTable getRecordTable_ID()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = @"SELECT DISTINCT bundle.id, MIN(item.item_name) AS item_name " +
                                   " FROM Bundle_Table bundle JOIN Item_Table item ON bundle.item_id = item.id " +
                                   " JOIN Flute_Table flute ON item.flute_id = flute.id " +
                                   " JOIN Client_Table client ON item.client_id = client.id " +
                                   " WHERE bundle.is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();

            if (!string.IsNullOrEmpty(searchname_tb.Text) && searchname_tb.Text != "ex. Piattos Small")
                conditions.Add($"item.item_name LIKE '%{searchname_tb.Text}%'");

            if (client_cb.Text != "<select-client>" && !string.IsNullOrEmpty(client_cb.Text))
                conditions.Add($"client.name LIKE '%{client_cb.Text}%'");

            if (flutetype_cb.Text != "<select-flutetype>" && !string.IsNullOrEmpty(client_cb.Text))
                conditions.Add($"flute.code_name LIKE '%{flutetype_cb.Text}%'");

            foreach (CheckBox checkbox in categ_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"bundle.category = '{checkbox.Tag}'");
            }

            if (category.Count > 0)
                preset_query += $" AND ({string.Join(" OR ", category)})";
            if (conditions.Count > 0)
                preset_query += " AND " + string.Join(" AND ", conditions);
            preset_query += $" GROUP BY bundle.id;";
            //MessageBox.Show(preset_query);
            DataTable table = sql.ExecuteQuery(preset_query);
            return table;
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


        private void ManageBundles_Form_VisibleChanged(object sender, EventArgs e)
        {
            SetGradientBackground("#D4ECD7", "#B2E2B8");
            resetFilter();
            TriggerVisualUpdate();

        }


        private void add_btn_Click(object sender, EventArgs e)
        {
            AddEditBundle_windowpopupform aebwpuf = new AddEditBundle_windowpopupform(this);
            aebwpuf.ShowDialog();
        }


        private void searchname_tb_Enter(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "ex. Piattos Small")
            {
                searchname_tb.Text = "";
                searchname_tb.ForeColor = Color.Black;
            }
        }


        private void searchname_tb_Leave(object sender, EventArgs e)
        {
            if (searchname_tb.Text == "")
            {
                searchname_tb.Text = "ex. Piattos Small";
                searchname_tb.ForeColor = Color.Gray;
            }
        }


        private void clear_btn_Click(object sender, EventArgs e)
        {
            resetFilter();
            TriggerVisualUpdate();
        }
        

        private void search_btn_Click(object sender, EventArgs e)
        {
            TriggerVisualUpdate();
        }
    }
}
