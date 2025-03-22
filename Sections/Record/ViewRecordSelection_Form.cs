using MyWinFormsApp.Sections.Estimate;
using MyWinFormsApp.SupportClass;
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

namespace MyWinFormsApp.Sections.Record
{
    public partial class ViewRecordSelection_Form : Form
    {
        //<REFERENCE CLASS>
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        private FilterInputSupportClass filter = new FilterInputSupportClass();
        private ViewRecord_Form parent;
        //<LIST>
        private List<Label> bundle_label_list = new List<Label>();
        private List<Label> client_label_list = new List<Label>();
        //<VARIABLES>
        private int id = -1;
        public DateTime datecreated;

        public ViewRecordSelection_Form(int id, ViewRecord_Form parent)
        {
            InitializeComponent();
            this.id = id;
            this.parent = parent;
            ReTextVisualControls();
        }





        //MODIFYING VARIABLES
        private void deleteMyData()
        {
            sql.ExecuteQuery($"UPDATE Record_Table SET is_deleted = 1 WHERE id = {id}");
        }





        //MODIFYING CONTROLS
        private void ReTextVisualControls()
        {
            AddClient("CLIENT:", true);
            AddBundleList("LIST OF BUNDLE:", null, true);
            foreach (DataRow rows in sql.ExecuteQuery($"SELECT * FROM Record_Table WHERE is_deleted = 0 AND id = {id}").Rows)
            {
                truck_label.Text = sql.ExecuteQuery($"SELECT t.platenumber FROM Record_Table r JOIN Truck_Table t ON r.truck_id = t.id WHERE r.id = {id};").Rows[0][0].ToString();
                data_label.Text = $"Date Created: {sql.ExecuteQuery($"SELECT date_added FROM Record_Table WHERE id = {id}").Rows[0][0].ToString()}";
                description_label.Text = sql.ExecuteQuery($"SELECT remarks FROM Record_Table WHERE id = {id}").Rows[0][0].ToString();
                datecreated = Convert.ToDateTime(sql.ExecuteQuery($"SELECT date_added FROM Record_Table WHERE id = {id}").Rows[0][0]);
            DataTable Addedbundles = sql.ExecuteQuery($"SELECT * FROM AddedBundle_Table WHERE record_id = {id}");
                DataTable Addedclients = sql.ExecuteQuery($"SELECT * FROM AddedClient_Table WHERE record_id = {id}");

                foreach (DataRow row in Addedbundles.Rows)
                {
                    DataRow item_table = sql.ExecuteQuery($"SELECT i.item_name, b._value FROM AddedBundle_Table b JOIN Item_Table i ON b.bundle_id = i.id WHERE b.record_id = {id}").Rows[0];
                    try
                    {
                        DataRow pallet_table = sql.ExecuteQuery($"SELECT p.name, b.pallet_quantiy FROM AddedBundle_Table b JOIN Pallet_Table p ON b.pallet_id = p.id WHERE b.record_id = {id}").Rows[0];
                        AddBundleList(item_table["item_name"].ToString(), Convert.ToInt32(item_table["_value"]));
                        AddPalletList(pallet_table["pallet_name"].ToString(), Convert.ToInt32(pallet_table["pallet_quantity"]));
                    }
                    catch
                    {
                        continue;
                    }
                }
                
                foreach (DataRow row in Addedclients.Rows) AddClient("- "+sql.ExecuteQuery($"SELECT name FROM Client_Table WHERE id = {row["client_id"]}").Rows[0][0].ToString());
                foreach (DataRow row in Addedbundles.Rows) AddBundleList("- " + sql.ExecuteQuery($"SELECT i.item_name FROM Bundle_Table b JOIN Item_Table i ON b.item_id = i.id WHERE b.id = {row["bundle_id"]}").Rows[0][0].ToString());
            }
        }
        private void AddBundleList(string name)
        {
            AddBundleList(name, null);
        }
        private void AddBundleList(string name, int? quantity, bool isHeader = false)
        {
            Label label = new Label();
            label.Text = quantity > 0 && quantity != null ? $"{name} ({quantity})" : name;
            label.AutoSize = true;
            label.ForeColor = isHeader ? Color.Black : Color.DimGray;
            stored_bundleitemnames_flp.Controls.Add(label);
            label.Show();
        }
        private void AddPalletList(string name, int? quantity)
        {
            Label label = new Label();
            label.Text = quantity > 0 && quantity != null ? $"   - {name} ({quantity})" : name;
            label.AutoSize = true;
            stored_bundleitemnames_flp.Controls.Add(label);
            label.Show();
        }
        private void AddClient(string name, bool isHeader = false)
        {
            Label label = new Label();
            label.Text = name;
            label.AutoSize = true;
            label.ForeColor = isHeader ? Color.Black : Color.DimGray;
            stored_client_flp.Controls.Add(label);
            label.Show();
        }
        private void FullViewData()
        {
            Estimate_Form estimate = new Estimate_Form(id);
            estimate.ShowDialog();
        }



        //RETURN TYPE
        public bool containsItemName(string item_name)
        {
            string query = $"SELECT DISTINCT i.item_name " +
                $"FROM Record_Table r " +
                $"JOIN AddedBundle_Table ab ON r.id = ab.record_id " +
                $"JOIN Bundle_Table b ON ab.bundle_id = b.id " +
                $"JOIN Item_Table i ON b.item_id = i.id " +
                $"WHERE r.id = {id};";
            //MessageBox.Show($"{sql.ExecuteQuery(query).Rows[0][0].ToString()}");
            //MessageBox.Show($"{filter.ContainsSimilarSubstring(sql.ExecuteQuery(query).Rows[0][0].ToString(), item_name)}");
            foreach (DataRow row in sql.ExecuteQuery(query).Rows)
            {
                //MessageBox.Show($"{row["item_name"].ToString()} is {item_name}");
                if (filter.ContainsSimilarSubstring(row["item_name"].ToString(), item_name)) return true;
            }
            return false;
        }

        public bool containsClientName(string name)
        {
            string query = "SELECT DISTINCT c.name, c.description, c.filter " +
                "FROM Record_Table r " +
                "JOIN AddedClient_Table ac ON r.id = ac.record_id " +
                "JOIN Client_Table c ON ac.client_id = c.id " +
                $"WHERE r.id = {id};";
            foreach (DataRow row in sql.ExecuteQuery(query).Rows) if (row["name"].ToString() == name) return true;
            return false;
        }
        public bool containsTruck(string truck_name)
        {
            string query = "SELECT t.platenumber FROM " +
                "Record_Table r JOIN Truck_Table t ON " +
                "r.truck_id = t.id " +
                $"WHERE r.id = {id}";
            foreach (DataRow row in sql.ExecuteQuery(query).Rows) if (row["platenumber"].ToString() == truck_name) return true;
            return false;
        }




        //CONTROL EVENTS
        private void delete_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
    "Once this data is deleted, it can no longer be retrieve. Are you sure?",
    "Warning",
    MessageBoxButtons.YesNo,
    MessageBoxIcon.Exclamation
);

            if (result == DialogResult.Yes)
            {
                string a = sql.ExecuteQuery($"SELECT i.item_name FROM AddedBundle_Table b JOIN Item_Table i ON b.bundle_id = i.id WHERE b.record_id = {id}").Rows[0][0].ToString();
                sql.commitReport($"A record data with item name '{a}' and id '{id}' has been deleted.");
                deleteMyData();
                parent.UpdateVisuals();
                
            }
            else if (result == DialogResult.No)
            {
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            FullViewData();
        }

        private void stored_bundleitemnames_flp_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
