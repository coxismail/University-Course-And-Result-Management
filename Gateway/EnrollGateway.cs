using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class EnrollGateway : ConnectionGateway
    {

        public int EnrollCourse(Enroll enrull)
        {
            Connection.Open();
            string query = "INSERT INTO Enroll(RegNo,CourseCode,Date) VALUES(@regNo, @courseCode, @date)";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@regNo", enrull.RegNo);
            Command.Parameters.AddWithValue("@courseCode", enrull.CourseCode);
            Command.Parameters.AddWithValue("@date", enrull.Date);
            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }



        public int UpdateEnrolledCourse(Enroll enrull)
        {
            Connection.Open();
            string query = "UPDATE Enroll SET CourseCode = @courseCode, Date = @date WHERE RegNo = @regNo";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@regNo", enrull.RegNo);
            Command.Parameters.AddWithValue("@courseCode", enrull.CourseCode);
            Command.Parameters.AddWithValue("@date", enrull.Date);
            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }


        public bool allreadyEnrolled(Enroll enrull)
        {
            Connection.Open();
            string query = "SELECT RegNo, CourseCode FROM Enroll WHERE RegNo = @regNo AND CourseCode = @courseCode";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@regNo", enrull.RegNo);
            Command.Parameters.AddWithValue("@courseCode", enrull.CourseCode);

            Reader = Command.ExecuteReader();

            bool allreadyEnrolled = Reader.HasRows;
            Connection.Close();

            return allreadyEnrolled;
        }




















        public List<Enroll> GetAllRegNo()
        {
            Connection.Open();
            string query = "select RegNo from Student";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Enroll> RegNolist = new List<Enroll>();

            while (Reader.Read())
            {
                Enroll RegNo = new Enroll();
                RegNo.RegNo = Reader["RegNo"].ToString();
                RegNo.Name = Reader["RegNo"].ToString();

                RegNolist.Add(RegNo);
            }

            Connection.Close();

            return RegNolist;
        }


        // Return Student Data

        public Enroll GetStudentbyRegNo(string RegNo)
        {
            Connection.Open();

            string query = "SELECT dbo.Student.Name as StudentName, Email, dbo.Department.Name as Department, dbo.Department.Code as DepartmentCode from Student INNER JOIN Department ON DepartmentCode = Department.Code WHERE RegNo= @regNo";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@regNo", RegNo);
            Reader = Command.ExecuteReader();
            Enroll asStudent = new Enroll();
            while (Reader.Read())
            {

                asStudent.Name = Reader["StudentName"].ToString();
                asStudent.Email = Reader["Email"].ToString();
                asStudent.Department = Reader["Department"].ToString();
                asStudent.DepartmentCode = Reader["DepartmentCode"].ToString();

            }


            Connection.Close();
            return asStudent;



        }

        public List<Course> GetTotalCourseistbyStuentDepartmentCode(string departmentCode) // just for dropdownlist
        {
            Connection.Open();

            string query = "SELECT Code, Name from Course WHERE DepartmentCode= @code";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", departmentCode);
            Reader = Command.ExecuteReader();
            List<Course> CourseList = new List<Course>();

            while (Reader.Read())
            {
                Course course = new Course();
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                CourseList.Add(course);
            }

            Connection.Close();
            return CourseList;
        }



    }
}