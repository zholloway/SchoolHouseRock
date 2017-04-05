using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolHouseRock1
{
    class Instructor
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public bool HeadInstructorStatus { get; set; }

        public Instructor() { }

        public Instructor(SqlDataReader reader)
        {
            this.Name = reader["Name"].ToString();
            this.ID = (int)reader["ID"];
            this.HeadInstructorStatus = (bool)reader["HeadInstructorStatus"];                
        }

        public static void AddInstructor(SqlConnection connection, Instructor instructor )
        {
            var query = @"INSERT INTO Instructor (Name, HeadInstructorStatus)"
                        + "Values (@Name, @HeadInstructorStatus)";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", instructor.Name);
            cmd.Parameters.AddWithValue("@HeadInstructorStatus", instructor.HeadInstructorStatus);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateInstuctor(SqlConnection connection, Instructor instructor)
        {
            var query = @"UPDATE Instructor " +
                        "SET Name=@Name, HeadInstructorStatus=@HeadInstructorStatus " +
                        "WHERE ID=@ID ";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", instructor.Name);
            cmd.Parameters.AddWithValue("@HeadInstructorStatus", instructor.HeadInstructorStatus);
            cmd.Parameters.AddWithValue("@ID", instructor.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteInstructor(SqlConnection connection, Instructor instructor)
        {
            var query = @"DELETE " +
                        "FROM Instructor " +
                        "WHERE ID=@ID ";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", instructor.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
