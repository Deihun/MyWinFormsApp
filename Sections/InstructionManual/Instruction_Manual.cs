using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp.Sections.InstructionManual
{
    public partial class Instruction_Manual: Form
    {
        public Instruction_Manual()
        {
            InitializeComponent();
            initializeContent();
        }

        private void initializeContent() //DITO KA MAG COCODE NG MGA CONTENT
        {
            Dictionary<string, Image> _value = new Dictionary<string, Image>();
            _value.Add("Start Managing Trucks", Properties.Resources.MANAGE_TRUCK);
            _value.Add("Adding new Trucks Click on ADD NEW TRUCK", Properties.Resources.AddTruck);
            _value.Add("Add Truck Data when you are done click ADD", Properties.Resources.AddingTruckData);
            _value.Add("To Edit truck data click on EDIT and CONFIRM CHANGE when done",Properties.Resources.EditTruck);
            _value.Add("To Delete truck data click on DELETE", Properties.Resources.DeleteTruck);
            _value.Add("To Filter truck data input information in filter", Properties.Resources.TruckFilter);
            createContent(_value, "Manage Truck");

            _value.Add("Start Managing Clients", Properties.Resources.ManageClient1);
            _value.Add("Adding new Clients Click on ADD NEW CLIENT",Properties.Resources.AddClient1);
            _value.Add("Add Client Data when you are done click ADD",Properties.Resources.AddingClientData1);
            _value.Add("To Edit client data click on EDIT and CONFIRM CHANGES when done", Properties.Resources.EditClient1);
            _value.Add("To Delete client data click on DELETE", Properties.Resources.DeleteClient1);
            _value.Add("To Filter client data input information in filter", Properties.Resources.ClientFilter1);
            createContent(_value, "Manage Client");

            _value.Add("Start Managing Items", Properties.Resources.ManageItems);
            _value.Add("Adding new Flute type Click MANAGE FLUTE", Properties.Resources.ManageFlute);
            _value.Add("Click ADD NEW FLUTE to add flute type ", Properties.Resources.AddNewFlute);
            _value.Add("Add Flute data when you are done click ADD ", Properties.Resources.AddingFluteData);
            _value.Add("To Edit flute data click on EDIT and CONFIRM CHANGES when done", Properties.Resources.EditFlute);
            _value.Add("To Delete flute data click on DELETE",Properties.Resources.DeleteFlute);
            _value.Add("Adding new Item Click ADD NEW ITEM",Properties.Resources.AddNewItem);
            _value.Add("Add Item data when you are done click ADD ITEM",Properties.Resources.AddingItemData);
            _value.Add("To Edit item data click on EDIT and CONFIRM when done", Properties.Resources.EditItem);
            _value.Add("To Delete item data click on DELETE", Properties.Resources.DeleteItem);
            _value.Add("To Filter item data input information in filter",Properties.Resources.ItemFilter);
            _value.Add("When making an Item you can also use a shortcut in making bundles by Clicking ADD && COPY",Properties.Resources.ConfirmCopy);
            createContent(_value, "Manage Item && Flute");

            _value.Add("Start Managing Bundles",Properties.Resources.ManageBundle);
            _value.Add("Adding new Bundles Click on ADD NEW BUNDLE", Properties.Resources.AddBundle);
            _value.Add("Add Bundle Data when you are done click ADD BUNDLE",Properties.Resources.AddingBundleData);
            _value.Add("To Edit bundle data click on EDIT and CONFIRM when done",Properties.Resources.EditBundle);
            _value.Add("To Delete bundle data click on DELETE",Properties.Resources.DeleteBundle);
            _value.Add("To Filter bundle data input information in filter",Properties.Resources.BundleFilter);
            createContent(_value, "Manage Bundles");

            _value.Add("Start Managing Pallets",Properties.Resources.ManagePallet);
            _value.Add("Adding new Pallet Click on ADD NEW PALLET PRESET", Properties.Resources.AddPallet);
            _value.Add("Add Pallet Data when you are done click ADD", Properties.Resources.AddingPalletData);
            _value.Add("To Edit pallet data click on EDIT and CONFIRM CHANGES when done",Properties.Resources.EditPallet);
            _value.Add("To Delete pallet data click on DELETE", Properties.Resources.DeletePallet);
            _value.Add("To Filter pallet data input information in filter",Properties.Resources.PalletFilter);
            createContent(_value, "Manage Pallets");

            _value.Add("Start Truck Estimation", Properties.Resources.TruckEstimate);
            _value.Add("Adding required data to start estimate example of single estimation",Properties.Resources.AddingEstimateDataSingle);
            _value.Add("Adding required data to start estimate example of single estimation with pallet", Properties.Resources.AddingEstimateDataSinglePallet);
            _value.Add("Adding required data to start estimate example of multiple estimation",Properties.Resources.AddingEstimateDataMultiple);
            _value.Add("Adding required data to start estimate example of multiple estimation with pallet", Properties.Resources.AddingEstimateDataMultiplePallet);
            _value.Add("When you are done with estimation click SAVE RECORD to save estimation to records",Properties.Resources.SaveTruckEstimateRecord);
            createContent(_value, "Truck Estimation");

            _value.Add("Start Viewing Records",Properties.Resources.ViewRecords);
            _value.Add("To view with more details click FULL VIEW",Properties.Resources.FullViewRecord);
            _value.Add("To Delete record data click on DELETE",Properties.Resources.DeleteRecord);
            _value.Add("To Filter record data input information in filter",Properties.Resources.RecordFilter);
            createContent(_value, "View Records");

            _value.Add("Start System Maintenance",Properties.Resources.ManageSystem);
            _value.Add("Checking History click HISTORY this will show all of the user activity",Properties.Resources.CheckHistory);
            _value.Add("Saving local database backup click SAVE",Properties.Resources.SystemBackup);
            _value.Add("Restore Backup of local database click RESTORE then click YES navigate the backup file and it should say database backup completed click OK",Properties.Resources.NavigateBackup);
            _value.Add("To Reset Database click RESET note this will permanently erase all data you need to backup the data if you want to access it again",Properties.Resources.ResetSystem);
            createContent(_value, "System settings");
        }

        private void createContent(Dictionary<string, Image> value, string pageNameContext)
        {
            Dictionary<string, Image> _value = new Dictionary<string, Image>(value);
            Button b = new Button();
            b.Text = pageNameContext;
            b.Font = new Font(b.Font.FontFamily, 7);
            b.FlatStyle = FlatStyle.Flat;
            b.BackColor = Color.White;
            b.Width = flowLayoutPanel1.Width - 20;
            b.Height = 35;
            flowLayoutPanel1.Controls.Add(b);
            b.Show();
            b.Click += delegate (object sender, EventArgs e)
            {
                contentChange(_value);
            };
            value.Clear();
        }

        private void createdClick(object sender, EventArgs e)
        {

        }

        private void contentChange(Dictionary<string, Image> value)
        {
            foreach (Control ctrl in panel1.Controls)
            {
               panel1.Controls.Remove(ctrl);
               ctrl.Dispose(); 
            }
            PreviewInstructions preview = new PreviewInstructions(value);//im using dictionary here but i get an error System.ArgumentOutOfRangeException: 'Specified argument was out of the range of valid values. (Parameter 'index')'
            panel1.Controls.Add(preview);
            preview.Dock = DockStyle.Fill;
            preview.Show();
        }
    }
}
