using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SchoolHouseRock1
{
    class Example
    {
        using (var connection = new SqlConnection(PathToDotNetUniversity))
            {
                connection.Open();

                var query1 = new SqlCommand(
                                "SELECT Course.Name AS CourseTitle, Instructor.Name AS TeacherName " +
                                "FROM Course " +
                                "JOIN UniversityConnector ON Course.ID = UniversityConnector.CourseID " +
                                "JOIN Instructor ON UniversityConnector.InstructorID = Instructor.ID",
                                connection
                                );

                var reader = query1.ExecuteReader();

                while (reader.Read())
                {
                    //stuff
                }

                connection.Close();
            }
    }
}
