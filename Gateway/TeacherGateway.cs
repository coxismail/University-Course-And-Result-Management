using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class TeacherGateway: ConnectionGateway
    {
        public int SaveTeacher(Teacher teacher)
        {
            Connection.Open();
            string query = "INSERT INTO Teacher(Name, Address, Email, Designation, Contact,  DepartmentCode, Credit) " +
                           "VALUES(@name, @address, @email, @designation, @contact, @departmentcode, @credit)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", teacher.Name);
            Command.Parameters.AddWithValue("@address", teacher.Address);
            Command.Parameters.AddWithValue("@email", teacher.Email);
            Command.Parameters.AddWithValue("@designation", teacher.Designation);
            Command.Parameters.AddWithValue("@contact", teacher.Contact);
            Command.Parameters.AddWithValue("@departmentcode", teacher.DepartmentCode);
            Command.Parameters.AddWithValue("@credit", teacher.CreditbeTaken);

            int rowsAffect = Command.ExecuteNonQuery();
            Connection.Close();

            return rowsAffect;
        }
        // Availabilty of Email Address
        public bool isExistMail(Teacher teacher)
        {
            Connection.Open();

            string query = "SELECT * from Teacher WHERE EMail = @mail";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@mail", teacher.Email);
            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Connection.Close();
            return isExist;



        }
        // is exist Mobile Number
        public bool isExistNumber(Teacher teacher)
        {
            Connection.Open();

            string query = "SELECT * FROM Teacher WHERE Contact = @contact";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@contact", teacher.Contact);
            Reader = Command.ExecuteReader();

            bool isExist = Reader.HasRows;

            Connection.Close();

            return isExist;
        }







        // Teacher Query according to deparment code
        public List<Teacher> GetTotalTeacherlist(string departmentCode) // just for dropdownlist
        {
            Connection.Open();

            string query = "SELECT * from Teacher WHERE DepartmentCode= @code";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", departmentCode);
            Reader = Command.ExecuteReader();
            List<Teacher> TeacherList = new List<Teacher>();

            while (Reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = Convert.ToInt32(Reader["Id"]);
                teacher.Name = Reader["Name"].ToString();
                teacher.Email = Reader["Email"].ToString();
                teacher.CreditbeTaken = Convert.ToInt32(Reader["Credit"]);
                teacher.Designation = Reader["Designation"].ToString();
                teacher.Contact = Reader["Contact"].ToString();
                TeacherList.Add(teacher);
            }

            Connection.Close();
            return TeacherList;
        }


        // Teacher query according to Teacher id
        public Teacher GetTeacherbyTeacherID(string Teacherid) // just for dropdownlist
        {
            Connection.Open();

            string query = "SELECT Credit FROM Teacher WHERE Id= @code";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", Teacherid);
            Reader = Command.ExecuteReader();

            Teacher teacher = new Teacher();
            while (Reader.Read())
            {
             
                teacher.CreditbeTaken = Convert.ToInt32(Reader["Credit"]);
            
            }

            Connection.Close();
            return teacher;
        }


       









    }

}