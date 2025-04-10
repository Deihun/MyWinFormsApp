using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyWinFormsApp.Sections.ManageItems
{
    public partial class ViewPerItem_Form : Form
    {
        ManageItems_form parent;
        main_startup_form mainparent;
        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
        int id;
        public string itemname = "";
        public string clientname = "";
        public string flutecode = "";
        public string category = "";
        public ViewPerItem_Form(int id, ManageItems_form parent, main_startup_form mparent)
        {
            InitializeComponent();
            DataRow Item_Table = sql.ExecuteQuery($"SELECT * FROM Item_Table WHERE id = {id}").Rows[0];
            DataRow client_table = sql.ExecuteQuery($"SELECT * FROM Client_Table WHERE id = {Convert.ToInt32(Item_Table["client_id"])} ORDER BY is_deleted ASC").Rows[0];
            DataRow Flute_Table = sql.ExecuteQuery($"SELECT * FROM Flute_Table WHERE id = {Convert.ToInt32(Item_Table["flute_id"])}").Rows[0];
            bool ClientisDeleted = Convert.ToBoolean(client_table["is_deleted"]);
            bool FluteisDeleted = Convert.ToBoolean(Flute_Table["is_deleted"]);
            bool isError = ClientisDeleted || FluteisDeleted;
            bool isFolded = Convert.ToBoolean(Item_Table["isFolded"]);

            string clientName = client_table["name"].ToString();
            string fluteType = Flute_Table["code_name"].ToString();

            fluteType += FluteisDeleted ? " (DELETED)" : string.Empty;

            clientName = ClientisDeleted ? clientName + "(DELETED)" : clientName;
            decimal fluteValue = Convert.ToDecimal(Flute_Table["_value"]);
            decimal length = Convert.ToDecimal(Item_Table["_length"]);
            decimal width = Convert.ToDecimal(Item_Table["_width"]);

            fluteValue = isFolded ? fluteValue * 2 : fluteValue;
            id_label.Text = $"ID: {id}";
            itemname = Item_Table["item_name"].ToString();

            this.parent = parent;
            this.mainparent = mparent;
            this.id = id;
            client_label.Text = $"{clientName}";
            itemname_label.Text = itemname;
            flute_label.Text = $"FluteType: ({fluteType.ToUpper()})";
            content_label.Text = $"Length(mm):     {Math.Round(length,2)}\n" +
                                 $"Width(mm) :     {Math.Round(width,2)}\n" +
                                 $"Height(mm):     {Math.Round(fluteValue, 2)}\n" +
                                 $"Dimension (mm): {Math.Round(length * width * fluteValue, 0)}";
            this.fcc_label.Text = $"F.C. CONTROL No.:\n    {Item_Table["fc_control_number"]}";
            this.category = category;
            this.itemname = itemname;
            this.clientname = clientname;
            
            this.flutecode = Flute_Table["code_name"].ToString();
            
            //SetGradientBackground("#FFFFFF", "#E6E5E5");
            if (isError) SetGradientBackground("#FFB28C", "#D15834"); 

        }

        private void SetGradientBackground(string hexColor1, string hexColor2)
        {
            Color color1 = ColorTranslator.FromHtml(hexColor1);
            Color color2 = ColorTranslator.FromHtml(hexColor2);

            Bitmap bmp = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, this.Width, this.Height),
                color1,
                color2,
                LinearGradientMode.Vertical)) // Change direction if needed
            {
                g.FillRectangle(brush, 0, 0, this.Width, this.Height);
            }
            this.BackgroundImage = bmp;
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
"Once this data is deleted, it can no longer be retrieve. Are you sure?",
"Warning",
MessageBoxButtons.YesNo,
MessageBoxIcon.Exclamation
);
            if (result == DialogResult.Yes)
            {
                sql.commitReport($"A data Item '{itemname}' was deleted");
                DeleteMyValue();
                this.parent.resetFilter();
                this.parent.TriggerVisualUpdate();
                this.parent.updatePageSelection();
            }
            else if (result == DialogResult.No)
            {
            }
        }

        private void edit_btn_Click(object sender, EventArgs e)
        {
            AddNewItems_WindowPopUpForm aniwpuf = new AddNewItems_WindowPopUpForm(parent, id, mainparent);
            aniwpuf.ShowDialog();
        }
        private void DeleteMyValue()//MODIFY THIS WHEN INTEGRATING FROM LOCAL TO SHARE DB
        {
            sql.ExecuteQuery($"UPDATE Item_Table SET is_deleted = 1 WHERE id = {id}");

        }
    }
}
