using MyWinFormsApp.Sections;
using MyWinFormsApp.Sections.Estimate;
using MyWinFormsApp.Sections.ManageBundles;
using MyWinFormsApp.Sections.ManageClient;
using MyWinFormsApp.Sections.ManagePallet;
using MyWinFormsApp.Sections.ManageTrucks;
using MyWinFormsApp.Sections.Record;

namespace MyWinFormsApp
{

    public partial class main_startup_form : Form
    {
        Panel viewer;

        Dashboard dashboard = new Dashboard();
        ManageItems_form manageitem;
        ManageTrucks_Form truck;
        ManageBundles_Form bundle;
        ManagePallet_Form pallet;
        ManageClient_Form client;
        Estimate_Form estimate;
        ViewRecord_Form viewrecord;

        public main_startup_form()
        {
            InitializeComponent();
            
            manageitem = new ManageItems_form();
            truck = new ManageTrucks_Form();
            bundle = new ManageBundles_Form();
            pallet = new ManagePallet_Form();
            client = new ManageClient_Form();
            estimate = new Estimate_Form();
            viewrecord = new ViewRecord_Form();
            viewer = this.workpanel;

            
         
            dashboard.all_SectionTabs.Add(manageitem);
            dashboard.all_SectionTabs.Add(truck);
            dashboard.all_SectionTabs.Add(bundle);
            dashboard.all_SectionTabs.Add(pallet);
            dashboard.all_SectionTabs.Add(client);
            dashboard.all_SectionTabs.Add(estimate);
            dashboard.all_SectionTabs.Add(viewrecord);
        }

        private void managebundle_dashboard_btn_Click(Object sender, EventArgs eg) //
        {
            dashboard.change_workpanelsection(bundle, viewer);
        }

        private void exit_dashboard_btn_Click(Object sender, EventArgs eg)
        {
            Application.Exit();
        }

        private void managetruck_dashboard_btn_Click(Object sender, EventArgs eg)
        {
            dashboard.change_workpanelsection(truck, viewer);
        }

        private void managepallet_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(pallet, viewer);
        }

        private void manageclient_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(client, viewer);
        }

        private void manageitems_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(manageitem, viewer);
        }

        private void viewrecords_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(viewrecord, viewer);
        }

        private void estimation_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(estimate, viewer);
        }
    }

    public class Dashboard
    {
        public List<Panel> all_dashboard_Panel;
        public List<Form> all_SectionTabs = new List<Form>();
        public void expand_currugator_panel(Panel selected_panel, int max_Height = 200, int min_Height = 50)
        {
            Panel _selected_panel = selected_panel;
            _selected_panel.Height = _selected_panel.Height == max_Height ? min_Height : max_Height;
        }

        public void change_workpanelsection(Form Form_To_Set, Panel viewer)
        {
            _hide_forms_in_workpanelsection();
            Form_To_Set.TopLevel = false;
            Form_To_Set.Size = viewer.Size;
            //Form_To_Set.Dock = DockStyle.Right;
            viewer.Controls.Clear();
            viewer.Controls.Add(Form_To_Set);
            Form_To_Set.Show();


        }

        public void _hide_forms_in_workpanelsection()
        {
            foreach (Form form in all_SectionTabs)
            {
                form.Hide();
            }
        }
    }
}