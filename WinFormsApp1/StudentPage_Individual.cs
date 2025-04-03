using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class StudentPage_Individual : Form
    {
        private string studentId;

        public StudentPage_Individual(string id)
        {
            InitializeComponent();
            studentId = id;
        }

        private void StudentPage_Individual_Load(object sender, EventArgs e)
        {
            LoadStudentData(studentId);
        }

        private void LoadStudentData(string studentId)
        {
            string connectionString = "server=127.0.0.1; port=3306; user=root; database=studentinfodb; password=";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = @"
                    SELECT sr.*, c.courseName, y.yearLvl
                    FROM studentrecordtb sr
                    LEFT JOIN coursetb c ON sr.courseId = c.courseId
                    LEFT JOIN yeartb y ON sr.yearId = y.yearId
                    WHERE sr.studentId = @studentId";

                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@studentId", studentId);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine("=== Columns in Query Result ===");

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.WriteLine($"Column {i}: {reader.GetName(i)} -> Value: {reader[i]}");
                        }

                        
                        string GetSafeValue(string column)
                        {
                            int index = reader.GetOrdinal(column);
                            return reader.IsDBNull(index) ? "N/A" : reader[column].ToString();
                        }

                        
                        txtStudentId.Text = GetSafeValue("studentId");
                        txtFullName.Text = $"{GetSafeValue("firstName")} {GetSafeValue("lastName")}";
                        txtAddress.Text = $"{GetSafeValue("houseNo")}, {GetSafeValue("brgyName")}, {GetSafeValue("municipality")}, {GetSafeValue("province")}";
                        txtBirthdate.Text = GetSafeValue("birthdate");
                        txtAge.Text = GetSafeValue("age");
                        txtContact.Text = GetSafeValue("studContactNo");
                        txtEmail.Text = GetSafeValue("emailAddress");
                        txtGuardian.Text = $"{GetSafeValue("guardianFirstName")} {GetSafeValue("guardianLastName")}";
                        txtHobbies.Text = GetSafeValue("hobbies");
                        txtNickname.Text = GetSafeValue("nickname");

                        
                        txtCourseYear.Text = $"{GetSafeValue("courseName")} - Year {GetSafeValue("yearLvl")}";
                    }
                    else
                    {
                        Console.WriteLine("❌ No student record found!");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}
