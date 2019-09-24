using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class ResultGateway: ConnectionGateway
    {




        public List<Course> GetTotalCourseListbyStuentRegNo(string RegNO) // just for dropdownlist
        {
            Connection.Open();

            string query = "SELECT CourseCode, Name FROM Enroll INNER JOIN Course ON CourseCode = Course.Code WHERE RegNo = @regNo";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@regNo", RegNO);
            Reader = Command.ExecuteReader();
            List<Course> CourseList = new List<Course>();

            while (Reader.Read())
            {
                Course course = new Course();
                course.Code = Reader["CourseCode"].ToString();
                course.Name = Reader["Name"].ToString();
                CourseList.Add(course);
            }

            Connection.Close();
            return CourseList;
        }



        public int UpdateEnrolledCourseResult(Enroll enrull)
        {
            Connection.Open();
            string query = "UPDATE Enroll SET Result =@grade WHERE RegNo=@regNo AND CourseCode = @courseCode";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@regNo", enrull.RegNo);
            Command.Parameters.AddWithValue("@courseCode", enrull.CourseCode);
            Command.Parameters.AddWithValue("@grade", enrull.Grade);
            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }
        // Return Student Result

        public List<Enroll> GetStudentResultbyRegNo(string RegNo)
        {
            Connection.Open();

            string query = "SELECT CourseCode, Name, Result FROM Enroll INNER JOIN Course On CourseCode = Code WHERE RegNo= @regNo";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@regNo", RegNo);
            Reader = Command.ExecuteReader();
            List<Enroll> enrolledCourseResult = new List<Enroll>();
            
            while (Reader.Read())
            {
                Enroll aStudentResult = new Enroll();
                aStudentResult.CourseCode = Reader["CourseCode"].ToString();
                aStudentResult.Name = Reader["Name"].ToString();
                aStudentResult.Grade = Reader["Result"].ToString();
                enrolledCourseResult.Add(aStudentResult);

            }


            Connection.Close();
            return enrolledCourseResult;



        }

    }
}



