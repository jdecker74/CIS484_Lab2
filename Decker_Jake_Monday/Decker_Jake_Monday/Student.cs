using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Decker_Jake_Monday
{
    public class Student
    {   
        //Data Fields
        private string studentName;
        private string email;
        private string phoneNumber;
        private string major;
        private string gradYear;
        private string gradeLevel;
        private string employmnetStatus;
        public static Student[] studentArray = new Student[25];

        //Overloaded Constructor to Create Student Instance Object
        public Student(string name, string email, string phoneNumber, string major, string gradYear, string gradeLevel, string empStatus )
        {
            name = studentName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.major = major;
            this.gradYear = gradYear;
            this.gradeLevel = gradeLevel;
            empStatus = employmnetStatus;
        }
       
        //Properties 
        public string StudentName
        {
            get
            {
                return studentName;
            }
            set
            {
                studentName = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }
        public string Major
        {
            get
            {
                return major;
            }
            set
            {
                major = value;
            }
        }
        public string GradYear
        {
            get
            {
                return gradYear;
            }
            set
            {
                gradYear = value;
            }
        }
        public string GradeLevel
        {
            get
            {
                return gradeLevel;
            }
            set
            {
                gradeLevel = value;
            }
        }
        public string EmploymentStatus
        {
            get
            {
                return employmnetStatus;
            }
            set
            {
                employmnetStatus = value;
            }
        }

    }
}