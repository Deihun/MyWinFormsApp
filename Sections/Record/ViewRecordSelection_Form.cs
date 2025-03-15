using MyWinFormsApp.Sections.Estimate;
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
        private ViewRecord_Form parent;
        //<LIST>
        private List<Label> bundle_label_list = new List<Label>();
        private List<Label> client_label_list = new List<Label>();
        //<VARIABLES>
        private int id = -1;

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
            foreach (DataRow rows in sql.ExecuteQuery("SELECT * FROM Record_Table WHERE is_deleted = 0").Rows)
            {
                truck_label.Text = sql.ExecuteQuery($"SELECT t.platenumber FROM Record_Table r JOIN Truck_Table t ON r.truck_id = t.id WHERE r.id = {id};").Rows[0][0].ToString();
                data_label.Text = sql.ExecuteQuery($"SELECT date_added FROM Record_Table WHERE id = {id}").Rows[0][0].ToString();
                description_label.Text = sql.ExecuteQuery($"SELECT remarks FROM Record_Table WHERE id = {id}").Rows[0][0].ToString();

                DataTable Addedbundles = sql.ExecuteQuery($"SELECT * FROM AddedBundle_Table WHERE id = {id}");
                DataTable Addedclients = sql.ExecuteQuery($"SELECT * FROM AddedClient_Table WHERE id = {id}");

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

                foreach (DataRow row in Addedclients.Rows) AddClient(sql.ExecuteQuery($"SELECT ct.name FROM AddedClient_Table act JOIN Client_Table  ct ON act.client_id = ct.id WHERE act.record_id = {id}").Rows[0][0].ToString());
            }
        }
        private void AddBundleList(string name)
        {
            AddBundleList(name, null);
        }
        private void AddBundleList(string name, int? quantity)
        {
            Label label = new Label();
            label.Text = quantity > 0 && quantity != null ? $"{name} ({quantity})" : name;
            label.AutoSize = true;
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
        private void AddClient(string name)
        {
            Label label = new Label();
            label.Text = name;
            label.AutoSize = true;
            stored_client_flp.Controls.Add(label);
            label.Show();
        }
        private void FullViewData()
        {
            Estimate_Form estimate = new Estimate_Form(id);
            estimate.ShowDialog();
        }



        //RETURN TYPE






        //CONTROL EVENTS
        private void delete_button_Click(object sender, EventArgs e)
        {
            deleteMyData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FullViewData();
        }
    }
}
