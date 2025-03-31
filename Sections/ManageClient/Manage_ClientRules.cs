using Microsoft.Identity.Client;
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

namespace MyWinFormsApp.Sections.ManageClient
{
    public partial class Manage_ClientRules : Form
    {
        private Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        public Manage_ClientRules()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            update();
        }

        private void update()
        {

            DataTable dt = sql.ExecuteQuery("SELECT rules FROM client_rules;");
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            if (dataGridView1.Columns["ActionButton"] == null)
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                btnColumn.Width = 80;
                btnColumn.Name = "ActionButton";
                btnColumn.HeaderText = "DELETE";
                btnColumn.Text = "DELETE";
                btnColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btnColumn);
            }

            if (dataGridView1.Columns["id"] != null)
                dataGridView1.Columns["id"].Visible = false;

            dataGridView1.CellClick -= dataGridView1_CellClick;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["ActionButton"].Index)
            {
                string idValue = dataGridView1.Rows[e.RowIndex].Cells["rules"].Value.ToString();
                HandleButtonClick(idValue);
            }
        }

        private void HandleButtonClick(string id)
        {
            sql.ExecuteQuery($"DELETE FROM client_rules WHERE rules = '{id}' ");
            update();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            sql.ExecuteQuery($"INSERT INTO client_rules (rules) VALUES ('{input_textbox.Text}')");
            input_textbox.Text = string.Empty;
            update();
        }
    }
}
