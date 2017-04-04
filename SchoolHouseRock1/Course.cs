﻿using System;
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
    }
}
