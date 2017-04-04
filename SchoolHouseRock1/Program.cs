using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolHouseRock1
{
    class Program
    {
        const string PathToDotNetUniversity = @"Server=localhost\SQLEXPRESS;Database=DotNetUniversity;Trusted_Connection=True;";

        public static List<Instructor> PopulateInstructor()
        {
            var instructorList = new List<Instructor>();

            using (var connection = new SqlConnection(PathToDotNetUniversity))
            {
                connection.Open();

                var cmd = new SqlCommand("SELECT * FROM Instructor", connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var instructor = new Instructor(reader);
                    instructorList.Add(instructor);
                }

                connection.Close();
            }

            return instructorList;
        }

        public static List<Course> PopulateCourse()
        {
            var courseList = new List<Course>();

            using (var connection = new SqlConnection(PathToDotNetUniversity))
            {
                connection.Open();

                var cmd = new SqlCommand("SELECT * FROM Course", connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var course = new Course(reader);
                    courseList.Add(course);
                }

                connection.Close();
            }

            return courseList;
        }

        public static List<Department> PopulateDepartment()
        {
            var departmentList = new List<Department>();

            using (var connection = new SqlConnection(PathToDotNetUniversity))
            {
                connection.Open();

                var cmd = new SqlCommand("SELECT * FROM Department", connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var department = new Department(reader);
                    courseList.Add(department);
                }

                connection.Close();
            }

            return departmentList;
        }

        static void Main(string[] args)
        {
            

            Console.ReadLine();
        }
    }
}
