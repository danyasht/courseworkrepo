using System;
using System.Data;
using System.IO.Ports;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Timers;
using System.Data.SqlClient;

namespace KeyValidationApp
{
    public partial class Form1 : Form
    {
        SerialPort serialPort;
        MySqlConnection connection;
        System.Timers.Timer refreshTimer;
        string correctKey = "1234"; 

        public Form1()
        {
            InitializeComponent();
            InitializeSerialPort();
            InitializeDatabase();
            InitializeDataGridView();
            InitializeTimer();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort("COM1", 9600);
            serialPort.Open();
        }

        private void InitializeDatabase()
        {
            string connectionString = "server=localhost;user=root;database=KeyLogDB;port=3306;password=1111";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Connected to database successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to database: " + ex.Message);
            }
        }

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Entered Key";
            dataGridView1.Columns[2].Name = "Entry Time";
            dataGridView1.Columns[3].Name = "Is Valid";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UpdateDataGridView();
        }

        private void InitializeTimer()
        {
            refreshTimer = new System.Timers.Timer();
            refreshTimer.Interval = 5000;
            refreshTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            refreshTimer.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            UpdateDataGridView();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string key = textBoxKey.Text;
            if (key.Length < 4 || key.Length > 7)
            {
                MessageBox.Show("Key should be between 4 and 7 characters.");
                return;
            }

            string validationStatus = key == correctKey ? "V" : "I";
            serialPort.WriteLine(validationStatus);
            InsertKeyToDatabase(key);
            UpdateDataGridView();

            textBoxKey.Clear();
        }

        private void buttonUpdateCorrectKey_Click(object sender, EventArgs e)
        {
            string newCorrectKey = textBoxCorrectKey.Text;
            if (newCorrectKey.Length < 4 || newCorrectKey.Length > 7)
            {
                MessageBox.Show("Correct key should be between 4 and 7 characters.");
                return;
            }

            correctKey = newCorrectKey;
            MessageBox.Show("Correct key updated successfully.");

            textBoxCorrectKey.Clear();
        }

        private void InsertKeyToDatabase(string key)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "INSERT INTO KeyEntries (entered_key, entry_time, is_valid) VALUES (@key, @entryTime, @isValid)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@key", key);
                cmd.Parameters.AddWithValue("@entryTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@isValid", key == correctKey);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Key inserted successfully.");
                }
                else
                {
                    MessageBox.Show("Key insertion failed.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to insert key into database: " + ex.Message);
            }
        }

        private void UpdateDataGridView()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                string query = "SELECT * FROM KeyEntries";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.Invoke(new Action(() =>
                {
                    dataGridView1.Rows.Clear();
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(row["id"], row["entered_key"], row["entry_time"], row["is_valid"]);
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to retrieve data from database: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Close();
            }
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            base.OnFormClosing(e);
        }
    }
}
