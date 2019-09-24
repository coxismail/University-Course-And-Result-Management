using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class StudentGateway : ConnectionGateway
    {


        private string Regno;
        public int RegistaterStudent(Student student, string Year, string RegNo)
        {
            string RegistrationNumber = student.DepartmentCode+"-"+Year+"-"+RegNo;

            Connection.Open();
            string query = "INSERT INTO Student(Name, RegNo, Email, Address, Year, Date, Contact,  DepartmentCode) " +
                           "VALUES(@name, @regno, @email, @address, @year, @date, @contact, @departmentCode )";
            Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@regno", RegistrationNumber);
            Command.Parameters.AddWithValue("@name", student.Name);
            Command.Parameters.AddWithValue("@email",student.Email);
            Command.Parameters.AddWithValue("@address",student.Address);
            Command.Parameters.AddWithValue("@year", Year);
            Command.Parameters.AddWithValue("@date",student.Date);
            Command.Parameters.AddWithValue("@contact",student.Contact);
            Command.Parameters.AddWithValue("@departmentCode",student.DepartmentCode);

            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }

        // Registerd Stduent check in year
        public bool hasStudentInYear(Student student, string year)
        {
            Connection.Open();

            string query = "SELECT * FROM Student WHERE DepartmentCode =@departmentCode AND Year =@year";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentCode", student.DepartmentCode);
            Command.Parameters.AddWithValue("@year", year);
            Reader = Command.ExecuteReader();

            bool hasStudent = Reader.HasRows;
            Connection.Close();

            return hasStudent;
        }

        // if hasstudent in year is True
        public string CollectRegNo(Student student, string year)
        {
            Connection.Open();

            string query = "SELECT RegNo FROM Student WHERE DepartmentCode=@departmentCode AND Year = @year";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentCode", student.DepartmentCode);
            Command.Parameters.AddWithValue("@year", year);

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Regno = Reader["RegNo"].ToString();
            }

            Connection.Close();

            return Regno;
        }




        // Availabilty of Email Address
        public bool isExistMail(Student student)
        {
            Connection.Open();

            string query = "SELECT * from Student WHERE EMail = @mail";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@mail", student.Email);
            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Connection.Close();
            return isExist;



        }
        // is exist Mobile Number
        public bool isExistNumber(Student student)
        {
            Connection.Open();

            string query = "SELECT * FROM Student WHERE Contact = @contact";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@contact", student.Contact);
            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Connection.Close();

            return isExist;
        }




// Return Student Data

        public Student registerdStudent(Student student)
        {
            Connection.Open();

            string query = "SELECT RegNo, dbo.Student.Name as StudentName, Email, Contact, Date, Address, dbo.Department.Name as DepartmentName from Student INNER JOIN Department ON DepartmentCode = Department.Code WHERE Email = @mail";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@mail", student.Email);
            Reader = Command.ExecuteReader();
            Student asStudent = new Student();
           while(Reader.Read())
            {
               
                asStudent.RegNo = Reader["RegNo"].ToString();
                asStudent.Name = Reader["StudentName"].ToString();
                asStudent.Email = Reader["Email"].ToString();
                asStudent.Address = Reader["Address"].ToString();
                asStudent.Contact = Reader["Contact"].ToString();
                asStudent.Date = Reader["Date"].ToString();
                asStudent.DepartmentCode = Reader["DepartmentName"].ToString();
               
            }


            Connection.Close();
            return asStudent;



        }







    }
}