using COMBINE_CHECKLIST_2024.DateToText;
using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace MyWinFormsApp.Sections.ManageTrucks
{
    public partial class ManageTrucks_Form : Form
    {
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private List<PreviewSelectedTruck_Form> list = new List<PreviewSelectedTruck_Form>();
        private List<CheckBox> checkbox_list = new List<CheckBox>();
        private List<FlowLayoutPanel> pages = new List<FlowLayoutPanel>();
        private PageSelection page;

        private const int objects_perPage = 4;
        private int max_count = 0;

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Timer pageTimer;
        public ManageTrucks_Form()
        {
            InitializeComponent();
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 50;
            updateTimer.Tick += (s, e) =>
            {
                updateTimer.Stop();
                updateVisual();
            };
            pageTimer = new System.Windows.Forms.Timer();
            pageTimer.Interval = 50;
            pageTimer.Tick += (s, e) =>
            {
                pageTimer.Stop();
                _start_updatePage_Selector();
            };
        }

        //VISUAL CHANGES
        private void noresult()
        {
            _no_result.Visible = max_count < 1;
            label1.Visible = checkbox_list.Count > 0;
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


        public void resetFilter()
        {
            foreach (CheckBox i in checkbox_list) i.Dispose();
            checkbox_list.Clear();
            wheelertype_cb.Items.Clear();
            wheelertype_cb.Items.Add("<select-type-of-truck>");
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT trucktype FROM Truck_Table WHERE is_deleted = 0").Rows) wheelertype_cb.Items.Add(row["trucktype"]);
            foreach (DataRow row in sql.ExecuteQuery("SELECT DISTINCT category FROM Truck_Table WHERE is_deleted = 0").Rows)
            {
                if (string.IsNullOrEmpty(row["category"].ToString())) continue;
                create_check(row["category"].ToString());
            }

            wheelertype_cb.SelectedIndex = 0;
            platenumbersearch_tb.Text = "<ex. AAU5659>";
            platenumbersearch_tb.ForeColor = Color.Gray;
        }


        private void _start_updatePage_Selector()
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
            pageTimer.Stop();
            pageTimer.Start();
        }


        public void updateVisual()
        {
            foreach (FlowLayoutPanel control in pages) control.Dispose();
            pages.Clear();

            List<string> year_data = new List<string>();
            int object_created_count = 0;
            int current_page_now = 0;
            add_page();

            foreach (DataRow row in getRecordTable_ID().Rows)
            {
                var form = create_viewTruck(Convert.ToInt32(row["id"]));
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
            noresult();
            updatePageSelector();
            whenPageIsSelected(0);
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


        public void TriggerVisualUpdate()
        {
            if (updateTimer.Enabled) return;
            updateTimer.Start();
        }




        //OBJECT SETTER
        private PreviewSelectedTruck_Form create_viewTruck(int id)
        {
            PreviewSelectedTruck_Form pstf = new PreviewSelectedTruck_Form(id, this);
            pstf.TopLevel = false;
            storedarea_flt.Controls.Add(pstf);
            pstf.Show();
            list.Add(pstf);
            return pstf;
        }


        private DataTable getRecordTable_ID()
        {
            Datetotext datetotext = new Datetotext();
            string preset_query = "\r\nSELECT DISTINCT truck.id, MIN(truck.platenumber) AS platenumber FROM Truck_Table truck WHERE is_deleted = 0 ";

            List<string> conditions = new List<string>();
            List<string> category = new List<string>();
            if (!string.IsNullOrEmpty(platenumbersearch_tb.Text) && platenumbersearch_tb.Text != "<ex. AAU5659>")
                conditions.Add($"truck.platenumber LIKE '%{platenumbersearch_tb.Text}%'");
            if (!string.IsNullOrEmpty(wheelertype_cb.Text) && wheelertype_cb.Text != "<select-type-of-truck>")
                conditions.Add($"truck.trucktype = '{wheelertype_cb.Text}'");

            foreach (CheckBox checkbox in checkbox_list)
            {
                if (!checkbox.Checked) continue;
                if (string.IsNullOrEmpty(checkbox.Text)) continue;
                category.Add($"truck.category = '{checkbox.Tag}'");
            }
            if (conditions.Count > 0)
                preset_query += $" AND ({string.Join(" AND ", conditions)})";
            if (category.Count > 0)
                preset_query += $" AND ({string.Join(" OR ", category)})";
            preset_query += $" GROUP BY truck.id;";

            //MessageBox.Show(preset_query);
            DataTable table = sql.ExecuteQuery(preset_query);
            return table;
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


        private CheckBox create_check(string category)
        {
            CheckBox check = new CheckBox();
            check.Text = category;
            check.Tag = category;
            flowLayoutPanel1.Controls.Add(check);
            checkbox_list.Add(check);
            check.Padding = new Padding(20, 0, 0, 0);
            check.ForeColor = Color.White;
            check.AutoSize = true;
            check.Visible = true;
            check.Checked = false;
            check.CheckedChanged += checkboxTrigger;
            return check;
        }




        //CONTROL EVENT
        private void add_btn_Click(object sender, EventArgs e)
        {
            AddTruck_popWindows addtruck = new AddTruck_popWindows(this);
            addtruck.ShowDialog();
        }


        private void checkboxTrigger(object sender, EventArgs e)
        {
            foreach (CheckBox cb in checkbox_list)
            {
                if (sender is CheckBox s) if (cb == s) continue;
                cb.Checked = false;
            }
        }


        private void ManageTrucks_Form_VisibleChanged(object sender, EventArgs e)
        {
            SetGradientBackground("#D4ECD7", "#B2E2B8");
            resetFilter();
            TriggerVisualUpdate();
        }


        private void platenumbersearch_tb_Enter(object sender, EventArgs e)
        {
            if (platenumbersearch_tb.Text == "<ex. AAU5659>")
            {
                platenumbersearch_tb.Text = "";
                platenumbersearch_tb.ForeColor = Color.Black;
            }
        }


        private void platenumbersearch_tb_Leave(object sender, EventArgs e)
        {
            if (platenumbersearch_tb.Text == "")
            {
                platenumbersearch_tb.Text = "<ex. AAU5659>";
                platenumbersearch_tb.ForeColor = Color.Gray;
            }
        }


        private void clear_btn_Click(object sender, EventArgs e)
        {
            resetFilter();
            TriggerVisualUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TriggerVisualUpdate();
        }
    }
}
