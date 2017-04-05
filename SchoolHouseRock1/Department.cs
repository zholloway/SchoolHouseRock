using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolHouseRock1
{
    class Department
    {
        public string Name { get; set; }

        public int HeadInstructorID { get; set; }

        public int ID { get; set; }

        public Department() { }

        public Department(SqlDataReader reader)
        {
            Name = reader["Name"].ToString();
            HeadInstructorID = (int)reader["HeadInstructorID"];
            ID = (int)reader["ID"];
        }

        public static void AddDepartment(SqlConnection connection, Department department)
        {
            var query = @"INSERT INTO Department (Name, HeadInstructorID)"
                        + "Values (@Name, @HeadInstructorID)";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", department.Name);
            cmd.Parameters.AddWithValue("@HeadInstructorID", department.HeadInstructorID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateDepartment(SqlConnection connection, Department department)
        {
            var query = @"UPDATE Department " +
                        "SET Name=@Name, HeadInstructorID=@HeadInstructorID " +
                        "WHERE ID=@ID ";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", department.Name);
            cmd.Parameters.AddWithValue("@HeadInstructorID", department.HeadInstructorID);
            cmd.Parameters.AddWithValue("@ID", department.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteDepartment(SqlConnection connection, Department department)
        {
            var query = @"DELETE " +
                        "FROM Department " +
                        "WHERE ID=@ID ";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", department.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
