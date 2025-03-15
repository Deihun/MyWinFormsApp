using MyWinFormsApp.SupportClass;
using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp.Sections.Estimate
{
    public partial class Estimate_Form : Form
    {           //<REFERENCE CLASS>
                    storedMeasurements stored_measurement = new storedMeasurements();
                    Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);


                //<LIST>
                    public List<bundleview_estimation_form> bundle_list = new List<bundleview_estimation_form>();
                    public List<clientselectView_form> clientList = new List<clientselectView_form>();
                    public List<Label> warningList = new List<Label>();
                    public List<Label> forDisplayContentList = new List<Label>();
                    public List<IDisposable> requireManagementList = new List<IDisposable>();
                    public List<string> storedWarningList = new List<string>();
                    public List<string> forDisplayStringList = new List<string>();


                //VARIABLES
                     public int id = -1;

                    /// <summary>
                    /// Create an Estimate Form with purpose of creating a new record of Truck Estimation
                    /// </summary>
                    public Estimate_Form()
                    {
                        InitializeComponent();
                    }
                    /// <summary>
                    /// View an existing Estimation Record.
                    /// </summary>
                    /// <param name="id">'id' of Record_Table in Database</param>
                    public Estimate_Form(int id)
                    {
                        InitializeComponent();
                        this.id = id;
                        this.WindowState = FormWindowState.Normal;
                        this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                        this.add_client.Enabled = false;
                        this.addbundle_btn.Enabled = false;
                        this.action_button.Text = "CLOSE";

                        this.truck_cb.DropDownStyle = ComboBoxStyle.DropDownList; // Ensures no free text input
                        this.truck_cb.Items.Clear(); // Clears any previous items

                        string plateNumber = getTruckPlateNumber();
                        this.truck_cb.Items.Add("Select a Truck");
                        this.truck_cb.Items.Add(plateNumber); // Adds the new plate number
                    
                        this.truck_cb.SelectedItem = plateNumber; // Force selection of the first (new) item

                        this.truck_cb.Enabled = false; // Disable if necessary
                        initialize_all_sub_forms_referencing_id();
                        UpdateVisual();
        }





        //*** VISUAL METHODS
            public void UpdateVisual(bool set_for_view_only = true)
            {
                resetDisplay();
                UpdateToChangeIntoQuantityMode();

                getValues();
                computeData();
                updateWarnings();
                showDisplay();
            }
            public void showDisplay()
            {
                foreach (Label l in forDisplayContentList) l.Dispose();
                forDisplayContentList.Clear();
                bool clientCount = clientList.Count > 0;
                bool bundleCount = bundle_list.Count > 0;

                if (clientCount && bundleCount && isThereAtleastPresentClient()) { }
                else
                {
                    forDisplayStringList.Clear(); 
                    forDisplayStringList.Add("FILL UP ALL THE REQUIREMENTS:");
                    forDisplayStringList.Add($"\n - Missing:");
                    if (!clientCount) forDisplayStringList.Add(" -  There's no client. Please insert a client!");
                    else if (clientCount && !isThereAtleastPresentClient()) forDisplayStringList.Add(" -  Please select a target client.");
                    if (!bundleCount) forDisplayStringList.Add(" -  There's no Bundle. Please insert a bundle");

                }


                foreach (string message in forDisplayStringList)
                {
                    Label label = new Label();
                    label.Font = new Font("Arial", 12, FontStyle.Bold);
                    label.Text = message;
                    label.AutoSize = true;
                    label.ForeColor = Color.White;
                    storeddetailreport_flp.Controls.Add(label);
                    forDisplayContentList.Add(label);
                    label.Show();
                }
                forDisplayStringList.Clear();
            }
            public void UpdateToChangeIntoQuantityMode()
            {
                foreach (bundleview_estimation_form besf in bundle_list)
                {
                    besf.setVisible(bundle_list.Count > 1);
                }
            }

            public void UpdateSelectionWithinChange()
            {
                foreach (bundleview_estimation_form besf in bundle_list)
                {
                    besf.initializeBundleCombobox();
                }
            }
            private void resetDisplay()
            {
                foreach (var l in requireManagementList) l.Dispose();
                requireManagementList.Clear();
                storedWarningList.Clear();


                foreach (clientselectView_form f in clientList) requireManagementList.Add(new RequirementsManagement_class(f.getFilter()));
                foreach (RequirementsManagement_class reqms in requireManagementList) storedWarningList = storedWarningList.Concat(reqms.getAllConditionAsList()).ToList();
            }
            private void updateWarnings()
            {
                foreach (Label l in warningList) l.Dispose();
                warningList.Clear();
                storedRuleWarning_flp.Controls.Add(createWarning("WARNING: ", warningList));
                if (truck_cb.SelectedIndex == 0) storedRuleWarning_flp.Controls.Add(createWarning("* Please Select a Truck", warningList));
                if (bundle_list.Count == 0) storedRuleWarning_flp.Controls.Add(createWarning("* Please add a new bundle", warningList));
                presetMultipleWarnings();
                foreach (string a in storedWarningList) storedRuleWarning_flp.Controls.Add(createWarning($"* {a}", warningList));
            }
            private Label createWarning(string content, List<Label> bundle_list)
            {
                Label label = new Label();
                label.Font = new Font("Arial", 12, FontStyle.Bold); ;
                label.Text = content;
                label.AutoSize = true;
                label.ForeColor = Color.Orange;
                bundle_list.Add(label);
                return label;
            }
            private void createDisplay(string content)
            {
                forDisplayStringList.Add(content); 
            }
            private void presetMultipleWarnings()
            {
                storedWarningList = storedWarningList.Distinct().ToList();
                checkForPalletCondition();
            }





        //**INITIALIZATIONS AND MANIPULATION OF CONTROLS
        private void initializeComboBox()
            {
                truck_cb.Items.Clear();
                truck_cb.Items.Add("<Select a Truck>");
                foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Truck_Table").Rows) truck_cb.Items.Add(row["platenumber"].ToString());
                truck_cb.SelectedIndex = 0;
            }
            private void add_new_bundle_form()
            {
                bundleview_estimation_form bwef = new bundleview_estimation_form(this);
                bwef.TopLevel = false;
                stored_bundlecontainer.Controls.Add(bwef);
                bundle_list.Add(bwef);
                bwef.Show();
            }
            private void resetAllUserInputs()
            {
            truck_cb.SelectedIndex = 0;
            foreach (Form f in clientList) f.Dispose();
            foreach (Form f in bundle_list) f.Dispose();
            bundle_list.Clear();
            clientList.Clear();
            UpdateVisual();
            }
            private void ExitRecord()
            {
                this.Dispose();
            }
        private void initialize_all_sub_forms_referencing_id()
        {
            DataRow record = sql.ExecuteQuery($"SELECT * FROM Record_Table WHERE id={id} AND is_deleted = 0;").Rows[0];
            foreach (DataRow row in sql.ExecuteQuery(
                $"SELECT i.id AS item_id, p.id AS pallet_id " +
                $"FROM AddedBundle_Table ab " +
                $"JOIN Bundle_Table b ON ab.bundle_id = b.id " +
                $"JOIN Item_Table i ON b.item_id = i.id " +
                $"LEFT JOIN Pallet_Table p ON ab.pallet_id = p.id " +
                $"WHERE ab.record_id = {id}"
            ).Rows)
            {
                int pallet_id = row["pallet_id"] == DBNull.Value ? -1 : Convert.ToInt32(row["pallet_id"]);
                bundleview_estimation_form bvef = new bundleview_estimation_form(this, Convert.ToInt32(row["item_id"]), pallet_id);
                bvef.TopLevel = false;
                stored_bundlecontainer.Controls.Add(bvef);
                bundle_list.Add(bvef);
                bvef.Show();
            }
            foreach (DataRow row in sql.ExecuteQuery($"SELECT * FROM AddedClient_Table WHERE record_id = {Convert.ToInt32(record["id"])}").Rows)
            {
                clientselectView_form csvf = new clientselectView_form(this, Convert.ToInt32(row["client_id"]));
                csvf.TopLevel = false;
                storedclient_flp.Controls.Add(csvf);
                clientList.Add(csvf);
                csvf.Show();
            }
        }






        // ** DATA MANIPULATION
            private void singleEstimation()
            {
                decimal bundleLength = 0m;
                decimal bundleWidth = 0m;
                decimal bundleHeight = 0m;
                long totalFitBundle = 0;
                long totalItemPerPieces = 0;
                string productname = "";

                decimal availableTruckLength = stored_measurement.Trucklength;
                decimal availableTruckWidth = stored_measurement.Truckwidth;
                decimal availableTruckHeight = stored_measurement.Truckheight;

                decimal palletLength = 0m;
                decimal palletWidth = 0m;
                decimal palletHeight = 0m;
                int palletQuantity = 0;

                foreach (bundleview_estimation_form form in bundle_list)
                {
                    if (!form.isApplicableForComputation()) continue;

                    productname = form.getProductName();
                    if (form.canPalletComputationBeUse())
                    {
                        palletLength = form.getLengthPallet();
                        palletWidth = form.getWidthPallet();
                        palletHeight = form.getHeightPallet();
                        palletQuantity = form.getQuantityOfPallet();


                        availableTruckLength -= (palletQuantity * palletLength);
                        availableTruckWidth -= (palletQuantity * palletWidth);
                        availableTruckHeight -= (palletQuantity * palletHeight);
                    }

                    bundleLength = (availableTruckLength / form.getlength());
                    bundleWidth = (availableTruckWidth / form.getwidth());
                    bundleHeight = (availableTruckHeight / form.getheight());

                    totalFitBundle = (long)(bundleHeight * bundleLength * bundleWidth);
                    totalItemPerPieces = form.getQuantity() * totalFitBundle;
                }

                createDisplay("SINGLE ESTIMATION");
                createDisplay($"TRUCKS DIMENSIONS: \n\tPlate Number: {stored_measurement.TruckPlateName}\n\tTruckType: {stored_measurement.TruckType} \n\tLength: {stored_measurement.Trucklength}mm\n\tWidth: {stored_measurement.Truckwidth}mm\n\tHeight: {stored_measurement.Truckheight}mm\n\tVolume: {stored_measurement.Trucklength * stored_measurement.Truckwidth * stored_measurement.Truckheight}mm");
                createDisplay("\n\n");

                if (palletQuantity > 0)
                {
                    createDisplay($"PALLET DETAILS: \n\tPallet Length: {palletLength}mm\n\tPallet Width: {palletWidth}mm\n\tPallet Height: {palletHeight}mm\n\tQuantity: {palletQuantity}");
                    createDisplay("\n\n");
                }

                createDisplay($"PRODUCT: '{productname}'");
                createDisplay($"Amount of bundles that can fit: {totalFitBundle}\nAmount of items in those bundles: {totalItemPerPieces}");
            }
            private void multipleEstimation()
            {
                Computation_For_MultipleObject cfmo = new Computation_For_MultipleObject(stored_measurement.Trucklength, stored_measurement.Truckwidth, stored_measurement.Truckheight);
                foreach (bundleview_estimation_form form in bundle_list)
                {
                    if (!form.isApplicableForComputation()) continue;
                    cfmo.AddObject(new ObjectDimension(form.getlength(), form.getwidth(), form.getheight(), form.geTotalBundlesToLoadInTruck(), form.getProductName()));
                    if (form.canPalletComputationBeUse())
                    {
                        cfmo.AddObject(new ObjectDimension(form.getLengthPallet(), form.getWidthPallet(), form.getHeightPallet(), form.getQuantityOfPallet(), form.getPalletName(), true));
                    }
                }
                createDisplay("MULTIPLE ESTIMATION");
                createDisplay($"TRUCKS DIMENSIONS: \n\tPlate Number: {stored_measurement.TruckPlateName}\n\tTruckType: {stored_measurement.TruckType} \n\tLength: {stored_measurement.Trucklength}mm\n\tWidth: {stored_measurement.Truckwidth}mm\n\tHeight: {stored_measurement.Truckheight}mm\n\tVolume: {stored_measurement.Trucklength * stored_measurement.Truckwidth * stored_measurement.Truckheight}mm");


                bool result = cfmo.CanFitAllObjects(); Debug.WriteLine("TRIGGERING CANFITALLOBJECT"); 
                string canFit = result ? "ALL OBJECTS CAN FIT!" : "NOT ALL OBJECTS CAN FIT!";
                foreach (string a in cfmo.getMessageList()) createDisplay(a);
            }
            private void computeData()
            {
                if (bundle_list.Count == 1) singleEstimation();
                else if (bundle_list.Count > 1) multipleEstimation();
            }
            private void getValues()    //MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
            {
                if (truck_cb.Text != "<Select a Truck>")
                {
                    
                    DataRow row = sql.ExecuteQuery($"SELECT * FROM Truck_Table WHERE platenumber = '{truck_cb.Text}'").Rows[0];
                    stored_measurement.Trucklength = getClearanceSpaceRequirement() ? Convert.ToDecimal(row["_length"]) - (Convert.ToDecimal(row["_length"]) * 0.05m) : Convert.ToDecimal(row["_length"]);
                    stored_measurement.Truckwidth = getClearanceSpaceRequirement() ? Convert.ToDecimal(row["_width"]) - (Convert.ToDecimal(row["_width"]) * 0.05m) : Convert.ToDecimal(row["_width"]);
                    stored_measurement.Truckheight = getClearanceSpaceRequirement() ? Convert.ToDecimal(row["_height"]) - (Convert.ToDecimal(row["_height"]) * 0.05m) : Convert.ToDecimal(row["_height"]);
                    stored_measurement.TruckPlateName = row["platenumber"].ToString();
                    stored_measurement.TruckType = row["trucktype"].ToString();
                }
            }
            private void checkForPalletCondition()
            {
                if (storedWarningList.Contains("Required Pallet"))
                {
                    if (containAtLeastPallet()) storedWarningList.Remove("Required Pallet");
                }
            }
            private void AddNewRecord()
            {
                int newID;
                int palletID;
                Dictionary<string, object> values_Record_Table = new Dictionary<string, object>()
                {
                    {"date_added", DateTime.Now },
                    {"remarks",remarks_rtb.Text },
                    {"truck_id", getTruckID()}
                };
                newID = sql.InsertDataAndGetId("Record_Table", values_Record_Table);
            


                foreach (bundleview_estimation_form bvef in bundle_list)
                {
                    if (!bvef.isApplicableForComputation()) continue;
                    Dictionary<string, object> values_AddedBundleData = new Dictionary<string, object>();
                    palletID = bvef.getPalletID();
                    if (palletID == -1)
                    {
                        values_AddedBundleData.Add("record_id", newID);
                        values_AddedBundleData.Add("bundle_id", bvef.getBundleID());
                        values_AddedBundleData.Add("_value", bvef.getQuantity());
                        //values_AddedBundleData.Add();
                    }
                    else
                    {
                        values_AddedBundleData.Add("record_id", newID);
                        values_AddedBundleData.Add("bundle_id", bvef.getBundleID());
                        values_AddedBundleData.Add("_value", bvef.getQuantity());
                        values_AddedBundleData.Add("pallet_id",bvef.getPalletID());
                        values_AddedBundleData.Add("pallet_quantity", bvef.getQuantityOfPallet());
                    }
                    sql.InsertDataAndGetId("AddedBundle_Table", values_AddedBundleData);
                }
                foreach (clientselectView_form client in clientList)
                {
                    Dictionary<string, object> values_AddedClientData = new Dictionary<string, object>()
                    {
                        {"record_id", newID },
                        {"client_id", client.getMyID() }
                    };
                sql.InsertDataAndGetId("AddedClient_Table", values_AddedClientData);
                }
            
            MessageBox.Show("SUCCESSFULLY ADDED IN THE DATABASE");
            resetAllUserInputs();
        }





        // ** RETURN TYPE
            private bool getClearanceSpaceRequirement()
                {
                    ;
                    return (storedWarningList.Contains("Require in-between spaces"));
                }
            private bool containAtLeastPallet()
            {
                foreach (bundleview_estimation_form f in bundle_list)
                {
                    if (f.isProvidingPallet()) return true;
                }
                return false;
            }
            private bool isThereAtleastPresentClient()
            {
                foreach (clientselectView_form f in clientList) if (f.canBeSelected()) return true;
                return false;
            }
            private int getTruckID()
            {
                return Convert.ToInt32(sql.ExecuteQuery($"SELECT id FROM Truck_Table WHERE platenumber = '{truck_cb.Text}'").Rows[0][0]);
            }
            private string getTruckPlateNumber()
            {
                try
                { 
                    return sql.ExecuteQuery($"SELECT Truck.platenumber FROM Record_Table Record JOIN Truck_Table Truck ON Record.truck_id = Truck.id WHERE Record.id = {id};").Rows[0][0].ToString();
                }
                catch { return "error"; }
            }

        /// <summary>
        /// Returns a Boolean value base on how much complete is the user input controls.
        /// </summary>
        /// <param name="completion"></param>
        /// <returns></returns>
        private bool isTheUserInputComplete(int completion = 2)
        {
            return true;
        }





        // ** CONTROL EVENTS
            private void Estimate_Form_VisibleChanged(object sender, EventArgs e)
            {
                if (id == -1)initializeComboBox();
            }
            private void addbundle_btn_Click(object sender, EventArgs e)
            {
                add_new_bundle_form();
                UpdateVisual();
            }
            private void add_client_Click(object sender, EventArgs e)
            {
                clientselectView_form csvf = new clientselectView_form(this);
                csvf.TopLevel = false;
                storedclient_flp.Controls.Add(csvf);
                csvf.Show();
                clientList.Add(csvf);
                UpdateVisual();
            }
            private void truck_cb_SelectedIndexChanged(object sender, EventArgs e)
            {
                UpdateVisual();
            }
            private void action_button_Click(object sender, EventArgs e)
            {
                if (this.id == -1) AddNewRecord();
                else ExitRecord();Debug.WriteLine("\n\n\tXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX   SAVE    XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX\n\n");
            }

    }

    class storedMeasurements 
    {
        public decimal Trucklength;
        public decimal Truckwidth;
        public decimal Truckheight;
        public string TruckPlateName;
        public string TruckType;
    }
    public class ObjectDimension
    {
        public decimal Length { get; }
        public decimal Width { get; }
        public decimal Height { get; }
        public int Quantity { get; } // User-defined
        public bool isPallet = false;
        public string _name;

        public ObjectDimension(decimal length, decimal width, decimal height, int quantity, string name, bool isPallet = false)
        {
            Length = length;
            Width = width;
            Height = height;
            Quantity = quantity;
            this._name = name;
            this.isPallet = isPallet;
        }
    }
    public class Computation_For_MultipleObject
    {
        private decimal TruckLength;
        private decimal TruckWidth;
        private decimal TruckHeight;
        private decimal PackingEfficiencyFactor;
        private List<ObjectDimension> StoredObjects;
        private List<string> informationList = new List<string>();
        private string computationDetails; // Stores details for logging

        private int testvalue = 0;//for testing
        
        public Computation_For_MultipleObject(decimal length, decimal width, decimal height, decimal packingEfficiencyFactor = 0.75m)
        {
            TruckLength = length;
            TruckWidth = width;
            TruckHeight = height;
            PackingEfficiencyFactor = packingEfficiencyFactor;
            StoredObjects = new List<ObjectDimension>();
            computationDetails = "";
        }

        public void AddObject(ObjectDimension obj)
        {
            StoredObjects.Add(obj);
        }

        private void AddMessage(string list)
        {
            string l = list;
            informationList.Add(l);
        }

        public bool CanFitAllObjects()
        {
            
            decimal remainingVolume = TruckLength * TruckWidth * TruckHeight;
            informationList.Clear();
            AddMessage("\n\n");
            foreach (ObjectDimension obj in StoredObjects)
            {
                int bundlesPlaced = 0;
                decimal objectVolume = obj.Length * obj.Width * obj.Height;
                int bundlesFit = (int)(remainingVolume / objectVolume);

                if (bundlesFit < obj.Quantity) //Add message in this area sometimes result an output of two times
                {
                    AddMessage($"Failed to fit {obj.Quantity} {obj._name}. Only {bundlesFit} fit.\n");
                    return false; 
                }

                remainingVolume -= obj.Quantity * objectVolume;
                bundlesPlaced += obj.Quantity;

                if (obj.isPallet) AddMessage($"Successfully fit {bundlesPlaced} {obj._name} pallet of {obj.Length}x{obj.Width}x{obj.Height}.\n");
                else AddMessage($"Successfully fit {bundlesPlaced} {obj._name} Bundles of {obj.Length}x{obj.Width}x{obj.Height}.\n");
            }
            AddMessage($"\nRemaining available volume: {Math.Round(remainingVolume)}mm");
            AddMessage("All objects fit successfully!");//until here
            testvalue++;
            return true;
        }

        public string GetComputationDetails()
        {
            return computationDetails;
        }

        public List<string> getMessageList()
        {
            List<string> retur = informationList.Distinct().ToList();
            return informationList;
        }
        /*
         VISUAL DOUBLE DISPLAY BUG, ROOT CAUSE IS RELATED TO MULTI-ESTIMATION IS CALLED TWICE
         
         */
}
}


