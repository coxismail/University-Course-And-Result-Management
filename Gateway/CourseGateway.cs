using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class CourseGateway : ConnectionGateway
    {

        public int SaveCourse(Course course)
        {
            Connection.Open();
            string query = "INSERT INTO Course(Code,Name, Credit, Description, DepartmentCode, Semester) VALUES(@code, @name, @credit, @description, @departmentcode, @semester)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", course.Code);
            Command.Parameters.AddWithValue("@name", course.Name);
            Command.Parameters.AddWithValue("@credit", course.Credit);
            Command.Parameters.AddWithValue("@description", course.Description);
            Command.Parameters.AddWithValue("@departmentcode", course.DepartmentCode);
            Command.Parameters.AddWithValue("@semester", course.Semester);

            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }
        // Availabilty Check
        public bool isExistCode(Course course)
        {
            Connection.Open();

            string query = "select * from Course where Code = @code";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", course.Code);
            Reader = Command.ExecuteReader();

            bool HasCode = Reader.HasRows;

            Connection.Close();

            return HasCode;
        }
        // is exist course name
        public bool isExistName(Course course)
        {
            Connection.Open();

            string query = "SELECT * FROM Course WHERE Name = @name";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", course.Name);
            Reader = Command.ExecuteReader();

            bool HasCode = Reader.HasRows;

            Connection.Close();

            return HasCode;
        }


        // is already assignd to another teacher
        public bool isAlreadyAssigned(AssignCourse course)
        {
            Connection.Open();

            string query = "SELECT flag FROM Course WHERE flag=1 AND Code = @courseCode";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@courseCode", course.CourseCode);
            Reader = Command.ExecuteReader();

            bool isAlreadyAssigned = Reader.HasRows;

            Connection.Close();

            return isAlreadyAssigned;
        }
        // Course Assigned to Teacher

        public int AssignToTeacher(AssignCourse course)
        {
            Connection.Open();
            string query = "UPDATE Course SET flag=1, TeacherId=@teaacherId, AssignTo= @AssignTo WHERE Code=@courseCode";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@courseCode", course.CourseCode);
            Command.Parameters.AddWithValue("@AssignTo", course.TeacherName);
            Command.Parameters.AddWithValue("@teaacherId", course.TeacherId);
          int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }


        // View Course Statics
        public List<Course> ViewCourseStatics(string departmentCode)
        {
            Connection.Open();

            string query = "SELECT Code, Name, Semester, AssignTo From Course Where DepartmentCode=@Dcode";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@Dcode", departmentCode);
            Reader = Command.ExecuteReader();
            List<Course> CourseStatics = new List<Course>();

            while (Reader.Read())
            {
                Course course = new Course();
              
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                course.Semester = Reader["Semester"].ToString();
                course.AssignTo = Reader["AssignTo"].ToString();
                CourseStatics.Add(course);
            }

            Connection.Close();
            return CourseStatics;
        }




        // Course Query according to deparment code
        public List<Course> GetTotalCourseistbyDepartment(string departmentCode) // just for dropdownlist
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


//
        // Course Credit Query according to Teacher Id
        public Course GetTaeknCredit(string teacherId) 
        {
            Connection.Open();

            string query = "SELECT TeacherId, SUM(Credit) as Credit FROM Course WHERE TeacherId=@teacherid AND flag=1 GROUP BY TeacherId";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@teacherid", teacherId);
            Reader = Command.ExecuteReader();
            Course courseCredit = new Course();

            while (Reader.Read())
            {

                courseCredit.Credit = Convert.ToInt32(Reader["Credit"]);
                courseCredit.TeacherId = Convert.ToInt32(Reader["TeacherId"]);

            }

            Connection.Close();
            return courseCredit;
        }



// Course query according to course id
        public Course GetCoursebyCourseCode(string CourseCode) // just for dropdownlist
        {
            Connection.Open();

            string query = "SELECT Name, Credit FROM Course WHERE Code= @code";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", CourseCode);
            Reader = Command.ExecuteReader();

            Course course = new Course();
            while (Reader.Read())
            {
                course.Name = Reader["Name"].ToString();
                course.Credit = Convert.ToInt32(Reader["Credit"]);
                
            }

            Connection.Close();
            return course;
        }

        // Un Assign all couse

        public int unAssignallCourse()
        {
            Connection.Open();
            string query = "UPDATE Course SET flag=0 WHERE TeacherId IS NOT NULL";
            Command = new SqlCommand(query, Connection);
            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }


    }
}