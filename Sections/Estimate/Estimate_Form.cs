using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp.Sections.Estimate
{
    public partial class Estimate_Form : Form
    {
        storedMeasurements smeasure = new storedMeasurements();
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);

        public List<bundleview_estimation_form> list = new List<bundleview_estimation_form>();
        public List<clientselectView_form> clientList = new List<clientselectView_form>();

        public Estimate_Form()
        {
            InitializeComponent();
        }

        public void UpdateVisual()
        {
            UpdateToChangeIntoQuantityMode();
            getValues();
            computeData();
            updateWarnings();
        }
        public void UpdateToChangeIntoQuantityMode()
        {
            foreach (bundleview_estimation_form besf in list)
            {
                besf.setVisible(list.Count > 1);
            }
        }
        public void UpdateSelectionWithinChange()
        {
            foreach (bundleview_estimation_form besf in list)
            {
                besf.initializeBundleCombobox();
            }
        }

        private void getValues()    //MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            if (truck_cb.Text != "<Select a Truck>")
            {
                DataRow row = sql.ExecuteQuery($"SELECT * FROM Truck_Table WHERE platenumber = '{truck_cb.Text}'").Rows[0];
                smeasure.Trucklength = Convert.ToDecimal(row["_length"]);
                smeasure.Truckwidth = Convert.ToDecimal(row["_width"]);
                smeasure.Truckheight = Convert.ToDecimal(row["_height"]);
            }
        }

        private void initializeComboBox()
        {
            truck_cb.Items.Clear();
            truck_cb.Items.Add("<Select a Truck>");
            foreach (DataRow row in sql.ExecuteQuery("SELECT * FROM Truck_Table").Rows) truck_cb.Items.Add(row["platenumber"].ToString());
            truck_cb.SelectedIndex = 0;

        }

        private void Estimate_Form_VisibleChanged(object sender, EventArgs e)
        {
            initializeComboBox();
        }

        private void addbundle_btn_Click(object sender, EventArgs e)
        {
            bundleview_estimation_form bwef = new bundleview_estimation_form(this);
            bwef.TopLevel = false;
            stored_bundlecontainer.Controls.Add(bwef);
            list.Add(bwef);
            bwef.Show();
            UpdateVisual();
        }

        private void computeData()
        {
            if (list.Count == 1) singleEstimation();
            else if (list.Count > 1) multipleEstimation();
        }

        private void singleEstimation()
        {
            foreach (bundleview_estimation_form form in list)
            {
                if (!form.isApplicableForComputation()) continue;
                decimal bundleLength = smeasure.Trucklength / form.getlength();
                decimal bundleWidth = smeasure.Truckwidth / form.getwidth();
                decimal bundleHeight = smeasure.Truckheight / form.getheight();

                bundleHeight = Math.Round(bundleHeight, MidpointRounding.ToZero);
                bundleWidth = Math.Round(bundleWidth, MidpointRounding.ToZero);
                bundleLength = Math.Round(bundleLength, MidpointRounding.ToZero);


                int totalFitBundle = (int)(bundleHeight * bundleLength * bundleWidth);
                int totalItemPerPieces = form.getQuantity() * totalFitBundle;
                this.contentresult_label.Text = $"Value: {totalFitBundle} = ({smeasure.Trucklength}/{form.getlength()})({smeasure.Truckwidth}/{form.getwidth()})({smeasure.Truckheight}/{form.getheight()}) || {smeasure.Trucklength / form.getlength()} * {smeasure.Truckwidth / form.getwidth()} * {smeasure.Truckheight / form.getheight()} || {form.getQuantity()}";
            }
        }

        private void multipleEstimation()
        {
            decimal truckDimension = smeasure.Trucklength * smeasure.Truckwidth * smeasure.Truckheight;
            decimal truckCurrentDimension = truckDimension;
            decimal totalEatingVolume = 0m;
            foreach (bundleview_estimation_form form in list)
            {
                if (!form.isApplicableForComputation()) continue;
                decimal bundleLength =  form.getlength();
                decimal bundleWidth = form.getwidth();
                decimal bundleHeight = form.getheight();

                decimal Bundlevolume = bundleLength * bundleWidth * bundleHeight;
                decimal totalVolumeOccupied = Bundlevolume * form.geTotalBundlesToLoadInTruck();
                totalEatingVolume += totalVolumeOccupied;
                truckCurrentDimension -= totalVolumeOccupied;

                //int totalFitBundle = (int)(bundleHeight * bundleLength * bundleWidth);
                //int totalItemPerPieces = form.getQuantity() * totalFitBundle;
                //this.contentresult_label.Text = $"Value: {totalFitBundle} = ({smeasure.Trucklength}/{form.getlength()})({smeasure.Truckwidth}/{form.getwidth()})({smeasure.Truckheight}/{form.getheight()}) || {smeasure.Trucklength / form.getlength()} * {smeasure.Truckwidth / form.getwidth()} * {smeasure.Truckheight / form.getheight()} || {form.getQuantity()}";
                this.contentresult_label.Text = $"Value Available-Space =({truckCurrentDimension}), totalOccupiedVolume =({totalEatingVolume}), trucksVolume =({truckDimension})";
            }
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


        List<Label> warningList = new List<Label>();
        private void updateWarnings()
        {
            foreach (Label l in warningList) l.Dispose();
            warningList.Clear();
            storedRuleWarning_flp.Controls.Add(createWarning("WARNING: ", warningList));
            if (truck_cb.SelectedIndex == 0) storedRuleWarning_flp.Controls.Add(createWarning("* Please Select a Truck", warningList));
            if (list.Count == 0) storedRuleWarning_flp.Controls.Add(createWarning("* Please add a new bundle", warningList));
        }

        private Label createWarning(string content, List<Label> list)
        {
            Label label = new Label();
            label.Font = new Font("Arial",12, FontStyle.Bold); ;
            label.Text = content;
            label.AutoSize = true;
            label.ForeColor = Color.Orange;
            list.Add(label);
            return label;
        }
    }

    class storedMeasurements 
    {
        public decimal Trucklength;
        public decimal Truckwidth;
        public decimal Truckheight;

    }
}
