using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolHouseRock1
{
    class Student
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public string Year { get; set; }

        public Student() { }

        public Student(SqlDataReader reader)
        {
            Name = reader["Name"].ToString();
            ID = (int)reader["ID"];
            Year = reader["Year"].ToString();
        }

        public static void AddStudent(SqlConnection connection, Student student)
        {
            var query = @"INSERT INTO Student (Name, Year)"
                        + "Values (@Name, @Year)";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Year", student.Year);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateStudent(SqlConnection connection, Student student)
        {
            var query = @"UPDATE student " +
                        "SET Name=@Name, Year=@Year " +
                        "WHERE ID=@ID ";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", student.Name);
            cmd.Parameters.AddWithValue("@Year", student.Year);
            cmd.Parameters.AddWithValue("@ID", student.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteStudent(SqlConnection connection, Student student)
        {
            var query = @"DELETE " +
                        "FROM Student " +
                        "WHERE ID=@ID ";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", student.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
