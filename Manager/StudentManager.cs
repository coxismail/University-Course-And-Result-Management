using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class StudentManager
    {
        private StudentGateway studentGateway;

        public StudentManager()
        {
            studentGateway = new StudentGateway();
        }

        public string RegisterStudent(Student student)
        {

            string fullDate = student.Date;
            string year = fullDate.Substring(0, 4);


            if (studentGateway.hasStudentInYear(student, year))
            {
                string collectedRegNo = studentGateway.CollectRegNo(student, year);
                int Index = collectedRegNo.IndexOf("-");  // valur after first  --- sign 
                // Whithout Department Code  and Year with - sign  (-Year-  = 6 digit)
                string IncRegNo = collectedRegNo.Substring(Index + 6);
                int incrementableRegNo = Convert.ToInt32(IncRegNo);
                int IncrementedRegNo = incrementableRegNo + 1;
                if (IncrementedRegNo < 10)  // Add two zero for less than 10 registration number
                {
                    string RegNo = "00" + IncrementedRegNo;
                    int rowsAffected = studentGateway.RegistaterStudent(student, year, RegNo);

                    if (rowsAffected > 0)
                    {
                        return "Registraion Successfull";
                    }
                    else
                    {
                        return "Registraion Failed";
                    }
                }
                else if (IncrementedRegNo < 100)
                {
                    string RegNo = "0" + IncrementedRegNo;
                    int rowsAffected = studentGateway.RegistaterStudent(student, year, RegNo);

                    if (rowsAffected > 0)
                    {
                        return "Registraion Successfull";
                    }
                    else
                    {
                        return "Registraion Failed";
                    }
                }
                else
                {
                    string RegNo = IncrementedRegNo.ToString();
                    int rowsAffected = studentGateway.RegistaterStudent(student, year, RegNo);

                    if (rowsAffected > 0)
                    {
                        return "Registraion Successfull";
                    }
                    else
                    {
                        return "Registraion Failed";
                    }
                }
            }
            else
            {
                int rowsAffected = studentGateway.RegistaterStudent(student, year, "001");

                if (rowsAffected > 0)
                {
                    return "Registraion Successfull";
                }
                else
                {
                    return "Registraion Failed";
                }
            }
        }




        // Availabilty of Email Address
        public bool isExistMail(Student student)
        {
            return studentGateway.isExistMail(student);
        }
        public bool isExistNumber(Student student)
        {
            return studentGateway.isExistNumber(student);
        }





// Return Student Data

        public Student registerdStudent(Student student)
        {
            return studentGateway.registerdStudent(student);
        }















    }

}
