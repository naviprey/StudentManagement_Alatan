using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private MySqlConnection mySqlConnection;
        private DataGridView studentGridView;

        public Form1()
        {
            InitializeComponent();

            
            string mysqlCon = "server=127.0.0.1; port=3306; user=root; database=studentinfodb; password=";
            mySqlConnection = new MySqlConnection(mysqlCon);

            
            studentGridView = new DataGridView
            {
                Name = "studentGridView",
                Size = new Size(500, 250),
                Location = new Point(10, 10),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            studentGridView.CellContentClick += StudentGridView_CellContentClick;

            this.Controls.Add(studentGridView);
            this.Load += Form1_Load; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadStudents(); 
        }

        private void LoadStudents()
        {
            try
            {
                mySqlConnection.Open();
                string query = "SELECT studentId, CONCAT(firstName, ' ', lastName) AS fullName FROM StudentRecordTB LIMIT 5";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, mySqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                
                studentGridView.DataSource = dt;

                
                if (studentGridView.Columns["ViewButton"] == null)
                {
                    DataGridViewButtonColumn viewButton = new DataGridViewButtonColumn
                    {
                        HeaderText = "Action",
                        Name = "ViewButton",
                        Text = "VIEW",
                        UseColumnTextForButtonValue = true
                    };
                    studentGridView.Columns.Add(viewButton);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void StudentGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == studentGridView.Columns["ViewButton"].Index)
            {
                object studentIdValue = studentGridView.Rows[e.RowIndex].Cells["studentId"].Value;

                if (studentIdValue != null)
                {
                    string studentId = studentIdValue.ToString();

                    
                    StudentPage_Individual studentForm = new StudentPage_Individual(studentId);
                    studentForm.Show();
                }
                else
                {
                    MessageBox.Show("⚠️ Student ID is missing. Please try again.");
                }
            }
        }
    }
}
