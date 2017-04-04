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
    }
}
