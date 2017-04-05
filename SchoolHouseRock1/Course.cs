using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolHouseRock1
{
    class Course
    {
        public string Name { get; set; }

        public int InstructorCode { get; set; }

        public int ID { get; set; }

        public int CourseNumber { get; set; }

        public Course() { }

        public Course(SqlDataReader reader)
        {
            this.Name = reader["Name"].ToString();
            this.InstructorCode = (int)reader["InstructorCode"];
            this.ID = (int)reader["ID"];
            this.CourseNumber = (int)reader["CourseNumber"];
        }

        public static void AddCourse(SqlConnection connection, Course courseToAdd)
        {
            var query = @"INSERT INTO Course (Name, InstructorCode, CourseNumber)"
                        + "Values (@Name, @InstructorCode, @CourseNumber)" ;

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", courseToAdd.Name);
            cmd.Parameters.AddWithValue("@InstructorCode", courseToAdd.InstructorCode);
            cmd.Parameters.AddWithValue("@CourseNumber", courseToAdd.CourseNumber);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateCourse (SqlConnection connection, Course courseToUpdate)
        {
            var query = @"UPDATE Course " +
                        "SET Name=@Name, InstructorCode=@InstructorCode, CourseNumber=@CourseNumber " +
                        "WHERE ID=@ID ";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", courseToUpdate.Name);
            cmd.Parameters.AddWithValue("@InstructorCode", courseToUpdate.InstructorCode);
            cmd.Parameters.AddWithValue("@CourseNumber", courseToUpdate.CourseNumber);
            cmd.Parameters.AddWithValue("@ID", courseToUpdate.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteCourse (SqlConnection connection, Course courseToDelete)
        {
            var query = @"DELETE " + 
                        "FROM Course " + 
                        "WHERE ID=@ID ";

            var cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@ID", courseToDelete.ID);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
