using MyWinFormsApp.Sections;
using MyWinFormsApp.Sections._ettings;
using MyWinFormsApp.Sections.Estimate;
using MyWinFormsApp.Sections.InstructionManual;
using MyWinFormsApp.Sections.ManageBundles;
using MyWinFormsApp.Sections.ManageClient;
using MyWinFormsApp.Sections.ManagePallet;
using MyWinFormsApp.Sections.ManageTrucks;
using MyWinFormsApp.Sections.Record;
using SQLSupportLibrary;

namespace MyWinFormsApp
{

    public partial class main_startup_form : Form
    {
        Panel viewer;
        Sqlsupportlocal sql;
        Dashboard dashboard = new Dashboard();
        ManageItems_form manageitem;
        ManageTrucks_Form truck;
        ManageBundles_Form bundle;
        ManagePallet_Form pallet;
        ManageClient_Form client;
        Estimate_Form estimate;
        ViewRecord_Form viewrecord;
        settings_form settings;
        Instruction_Manual instruction;

        public main_startup_form()
        {
            //try
            //{
                Opener open = new Opener();
                if (!open.IsDatabaseDetected() && !open.IsSQLExpressInstalled() && !open.IsSQLExpressRunning() && !open.IsDatabaseSchemaValid()) open.ShowDialog();


                InitializeComponent();

                sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
                manageitem = new ManageItems_form(this);
                truck = new ManageTrucks_Form();
                bundle = new ManageBundles_Form();
                pallet = new ManagePallet_Form();
                client = new ManageClient_Form();
                estimate = new Estimate_Form();
                viewrecord = new ViewRecord_Form();
                settings = new settings_form();
                instruction = new Instruction_Manual();
                viewer = this.workpanel;

                viewrecord.parent = this;

                dashboard.all_SectionTabs.Add(manageitem);
                dashboard.all_SectionTabs.Add(truck);
                dashboard.all_SectionTabs.Add(bundle);
                dashboard.all_SectionTabs.Add(pallet);
                dashboard.all_SectionTabs.Add(client);
                dashboard.all_SectionTabs.Add(estimate);
                dashboard.all_SectionTabs.Add(viewrecord);
                dashboard.all_SectionTabs.Add(settings);
                dashboard.all_SectionTabs.Add(instruction);

                dashboard.all_buttonsDashBoard.Add(this.estimation_dashboard_btn);
                dashboard.all_buttonsDashBoard.Add(this.managebundle_dashboard_btn);
                dashboard.all_buttonsDashBoard.Add(this.manageclient_dashboard_btn);
                dashboard.all_buttonsDashBoard.Add(this.manageitems_dashboard_btn);
                dashboard.all_buttonsDashBoard.Add(this.viewrecords_dashboard_btn);
                dashboard.all_buttonsDashBoard.Add(this.managepallet_dashboard_btn);
                dashboard.all_buttonsDashBoard.Add(this.managetruck_dashboard_btn);
                dashboard.all_buttonsDashBoard.Add(this.system_btn);
                dashboard.all_buttonsDashBoard.Add(this.help_btn);
                sql.commitReport($"The system log in.");

            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show($"ERROR: {e.Message}");
            //}

        }
        public void copyFromRecord_To_Estimate(int id)
        {
            dashboard.change_workpanelsection(estimate, viewer, estimation_dashboard_btn);
            estimate.paste_in(id);
        }
        public void copyFromItem_To_Bundle(string item_name)
        {
            dashboard.change_workpanelsection(bundle, viewer, managebundle_dashboard_btn);
            bundle.AddBundleFromCopy(item_name);
        }
        private void managebundle_dashboard_btn_Click(Object sender, EventArgs eg) //
        {
            dashboard.change_workpanelsection(bundle, viewer, managebundle_dashboard_btn);
        }

        private void exit_dashboard_btn_Click(Object sender, EventArgs eg)
        {
            Application.Exit();
        }

        private void managetruck_dashboard_btn_Click(Object sender, EventArgs eg)
        {
            dashboard.change_workpanelsection(truck, viewer, managetruck_dashboard_btn);
        }

        private void managepallet_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(pallet, viewer, managepallet_dashboard_btn);
        }

        private void manageclient_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(client, viewer, manageclient_dashboard_btn);
        }

        private void manageitems_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(manageitem, viewer, manageitems_dashboard_btn);
        }

        private void viewrecords_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(viewrecord, viewer, viewrecords_dashboard_btn);
        }

        private void estimation_dashboard_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(estimate, viewer, estimation_dashboard_btn);
        }

        private void main_startup_form_Load(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(viewrecord, viewer, viewrecords_dashboard_btn);
        }

        private void system_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(settings, viewer, system_btn);
        }

        private void main_startup_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                sql.commitReport($"System log off");
            }
            catch
            {

            }
        }

        private void help_btn_Click(object sender, EventArgs e)
        {
            dashboard.change_workpanelsection(instruction, viewer, help_btn);
        }
    }

    public class Dashboard
    {
        public List<Panel> all_dashboard_Panel;
        public List<Form> all_SectionTabs = new List<Form>();
        public List<Button> all_buttonsDashBoard = new List<Button>();
        public void expand_currugator_panel(Panel selected_panel, int max_Height = 200, int min_Height = 50)
        {
            Panel _selected_panel = selected_panel;
            _selected_panel.Height = _selected_panel.Height == max_Height ? min_Height : max_Height;
        }

        public void change_workpanelsection(Form Form_To_Set, Panel viewer, Button button)
        {
            _hide_forms_in_workpanelsection();
            Form_To_Set.TopLevel = false;
            Form_To_Set.Size = viewer.Size;
            //Form_To_Set.Dock = DockStyle.Right;
            viewer.Controls.Clear();
            viewer.Controls.Add(Form_To_Set);
            Form_To_Set.Show();

            foreach (Button b in all_buttonsDashBoard)
            {
                b.BackColor = b == button ? Color.MediumSeaGreen : Color.SeaGreen;
                b.Padding = b == button ? new Padding(30, 0, 0, 0) : new Padding(0);
            }
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