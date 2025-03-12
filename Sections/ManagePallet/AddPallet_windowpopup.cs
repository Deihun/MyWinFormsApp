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

namespace MyWinFormsApp.Sections.ManagePallet
{
    public partial class AddPallet_windowpopup : Form
    {
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        ManagePallet_Form parent;
        private int ID = -1;
        public AddPallet_windowpopup(ManagePallet_Form parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public AddPallet_windowpopup(ManagePallet_Form parent, int id)
        {
            InitializeComponent();
            this.parent = parent;
            this.ID = id;

            DataRow row = sql.ExecuteQuery($"SELECT * FROM Pallet_Table WHERE id = {ID}").Rows[0] ;
            name_tb.Text = row["name"].ToString();
            length_tb.Text = row["_length"].ToString();
            width_tb.Text = row["_width"].ToString();
            height_tb.Text = row["_height"].ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (ID == -1) AddPallet();
            else RewritePallet();
            parent.UpdateVisual();
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void AddPallet() //REWRITE THIS WHEN INTEGRATING TO DATABASE
        {
            Dictionary <string, object> value = new Dictionary<string, object>(){
                { "name", name_tb.Text},
                { "_length", Convert.ToInt32(length_tb.Text) },
                 { "_width", Convert.ToInt32(width_tb.Text) },
                  { "_height", Convert.ToInt32(height_tb.Text) }
            };

            sql.InsertData("Pallet_Table", value);
        }

        private void RewritePallet() //REWRITE THIS WHEN INTEGRATING TO DATABASE
        {
            string query = "UPDATE Pallet_Table " +
                $"SET name =  '{name_tb.Text}', _length = {Convert.ToInt32(length_tb.Text)}, _width = {Convert.ToInt32(width_tb.Text)}, _height = {Convert.ToInt32(height_tb.Text)};";
            sql.ExecuteQuery(query);
        }
    }
}
