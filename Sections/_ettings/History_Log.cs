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

namespace MyWinFormsApp.Sections._ettings
{
    public partial class History_Log: Form
    {
        public History_Log()
        {
            Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS","TruckEstimationSystem",null,null);
            InitializeComponent();
            dataGridView1.DataSource = sql.ExecuteQuery("SELECT date_added, content FROM History_Table");
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
    }
}
