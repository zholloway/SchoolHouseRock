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
    }
}
