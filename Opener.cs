using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using SQLSupportLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace MyWinFormsApp
{
    public partial class Opener : Form
    {
        bool _exit = false;

        public Opener()
        {
            InitializeComponent();
            startup();
        }

        private void startup()
        {
            bool isInstalled = IsSQLExpressInstalled();
            bool isRunning = IsSQLExpressRunning();
            bool isDatabaseDetected = IsDatabaseDetected();
            bool isSchemaValid = isDatabaseDetected && isRunning;
            //&& IsDatabaseSchemaValid();

            if (isSchemaValid)
            {
                return;
            }
            else
            {
                if (!isInstalled) addLabel("* UNABLE TO DETECT THE SERVER");
                if (!isRunning) addLabel("* SERVER HAS STOPPED");
                if (!isDatabaseDetected) addLabel("* UNABLE TO DETECT THE DATABASE");
                if (isDatabaseDetected && !isSchemaValid) addLabel("* DATABASE SCHEMA MISMATCH");

                if (isInstalled && isRunning && (!isDatabaseDetected || !isSchemaValid))
                {
                    MessageBox.Show("ATTEMPTING TO CREATE A NEW DATABASE AND RESTARTING APPLICATION");
                    try
                    {
                        CreateDatabase(".\\SQLEXPRESS", "TruckEstimationSystem");
                        Sqlsupportlocal sql = new Sqlsupportlocal(".\\SQLEXPRESS", "TruckEstimationSystem", null, null);
                        sql.ExecuteQuery(getPresetCreationOfDatabase());
                        Application.Restart();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"ERROR {e.Message}");
                    }
                }
                _exit = true;
            }
        }

        public bool IsDatabaseSchemaValid()
        {
            var expectedTables = new HashSet<string>
            {
                "AddedBundle_Table", "AddedClient_Table", "Bundle_Table", "Client_Table", "Flute_Table",
                "History_Table", "Item_Table", "Pallet_Table", "Record_Table", "Truck_Table"
            };
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=TruckEstimationSystem;Trusted_Connection=True;TrustServerCertificate=True;"))
                {
                    conn.Open();
                    string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var existingTables = new HashSet<string>();
                        while (reader.Read())
                        {
                            existingTables.Add(reader.GetString(0));
                        }
                        return expectedTables.SetEquals(existingTables);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"ERROR {e.Message}");
                return false;
            }
        }

        private void CreateDatabase(string server, string dbName)
        {
            string connectionString = $"Server={server};Integrated Security=True;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
            string query = $"CREATE DATABASE {dbName}";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public bool IsSQLExpressInstalled()
        {
            string registryKey = @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL";
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                return key?.GetValueNames().Any(name => name.Equals("SQLEXPRESS", StringComparison.OrdinalIgnoreCase)) ?? false;
            }
        }

        public bool IsSQLExpressRunning()
        {
            try
            {
                string query = "SELECT State FROM Win32_Service WHERE Name='MSSQL$SQLEXPRESS'";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                using (ManagementObjectCollection services = searcher.Get())
                {
                    foreach (ManagementObject service in services)
                    {
                        return service["State"].ToString().Equals("Running", StringComparison.OrdinalIgnoreCase);
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool IsDatabaseDetected()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;"))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM sys.databases WHERE name = 'TruckEstimationSystem'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        return (int)cmd.ExecuteScalar() > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private void addLabel(string text)
        {
            Label label = new Label { Text = text, AutoSize = true };
            flowLayoutPanel1.Controls.Add(label);
            label.Show();
        }

        private void Opener_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_exit) Application.Exit();
        }

        private string getPresetCreationOfDatabase()
        {
            string query = @"
CREATE TABLE AddedBundle_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    record_id INT,
    bundle_id INT,
    _value DECIMAL(18,2),
    pallet_id INT,
    pallet_quantiy INT
);

CREATE TABLE AddedClient_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    record_id INT,
    client_id INT
);

CREATE TABLE Bundle_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    quantity INT,
    dimension NVARCHAR(255),
    item_id INT,
    category NVARCHAR(100),
    is_deleted BIT DEFAULT(0)
);

CREATE TABLE Client_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255),
    description NVARCHAR(MAX),
    category NVARCHAR(100),
    filter NVARCHAR(100),
    is_deleted BIT DEFAULT(0)
);

CREATE TABLE Flute_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    code_name NVARCHAR(100),
    _value DECIMAL(18,2),
    targetrange_from DECIMAL(18,2),
    targetrange_to DECIMAL(18,2),
    tolerance DECIMAL(18,2),
    is_deleted BIT DEFAULT(0)
);

CREATE TABLE History_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    content NVARCHAR(MAX),
    date_added DATETIME
);

CREATE TABLE Item_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    item_name NVARCHAR(255),
    fc_control_number NVARCHAR(100),
    _length DECIMAL(18,2),
    _width DECIMAL(18,2),
    _height DECIMAL(18,2),
    category NVARCHAR(100),
    client_id INT,
    flute_id INT,
    is_deleted BIT DEFAULT(0),
    isFolded BIT
);

CREATE TABLE Pallet_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(255),
    _length DECIMAL(18,2),
    _width DECIMAL(18,2),
    _height DECIMAL(18,2),
    is_deleted BIT DEFAULT(0)
);

CREATE TABLE Record_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    date_added DATETIME,
    remarks NVARCHAR(MAX),
    truck_id INT,
    client_id INT,
    category VARCHAR(MAX),
    is_deleted BIT DEFAULT(0)
);

CREATE TABLE Truck_Table (
    id INT PRIMARY KEY IDENTITY(1,1),
    platenumber NVARCHAR(50),
    trucktype NVARCHAR(100),
    _length DECIMAL(18,2),
    _width DECIMAL(18,2),
    _height DECIMAL(18,2),
    category NVARCHAR(100),
    is_deleted BIT DEFAULT(0)
);

CREATE TABLE client_rules (
    rules VARCHAR(50)
);
";
            return query;
        }
    }
}
