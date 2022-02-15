using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// SQL Imports
using System.Data;
using System.Data.SqlClient;
// Access to Connection Strings in Web.config
using System.Web.Configuration;

namespace Decker_Jake_Monday
{
    public partial class StudentPage : System.Web.UI.Page
    {
        public String queryCount;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Method to Populate Text Fields when "Populate Button" is pressed
        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            
            {
                txtFirstName.Text = "John";
                txtLastName.Text = "Doe";
                txtEmail.Text = "Doe@dukes.jmu.edu";
                txtPhoneNumber.Text = "8603472963";
                txtMajor.Text = "Marketing";
                txtGraduationDate.Text= "02/09/2023";
                dropDownGradeLevel.SelectedItem.Text = "Junior";
                dropDownEmploymentStatus.SelectedItem.Text = "Full-Time";

            }
        }
        //Method to Clear Text Fields when "Clear Button" is pressed
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtMajor.Text = "";
            txtGraduationDate.Text = "";
            dropDownGradeLevel.SelectedItem.Text = "Select Grade Level";
            dropDownEmploymentStatus.SelectedItem.Text = "Select Employment Status";
        }
        
        //Checks Duplication of Records. Checks to see if Student Email is same
        protected Boolean duplication()
        {
            String sqlQueryStudentName = "Select COUNT(EmailAddress) AS Email FROM Student WHERE EmailAddress = '" + txtEmail.Text +"'";
            // Define the connection to the DB:
            SqlConnection sqlConnect =
                new SqlConnection(
                    WebConfigurationManager.ConnectionStrings
                    ["Lab1Database"].ConnectionString);
            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQueryStudentName;
            // Execute the Query and Retrieve the Results
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader(); // Used for SELECT Queries
            

            
            while (queryResults.Read())
            {
                queryCount = queryResults["Email"].ToString();
            }

            if (queryCount == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
            sqlConnect.Close();
            queryResults.Close();

        }
        //Method to Commit Student to Database when "Commit Student" button is pressed
        protected void btnAdd_Click(object sender, EventArgs e)
        {
             Boolean x=duplication();

            if (x == true)
            {
                buttonStatus.Text = "Error: Student Already Exists";
            }
            else
            {
                // Create the Query with Concatenation of Text Boxes:
                String sqlQuery = "INSERT INTO Student (FirstName, LastName, EmailAddress, PhoneNumber, Major, GraduationDate, GradeLevel, EmploymentStatus) " +
                "VALUES('"
                + txtFirstName.Text + "','"
                + txtLastName.Text + "','"
                + txtEmail.Text + "','"
                + txtPhoneNumber.Text + "','"
                + txtMajor.Text + "','"
                + txtGraduationDate.Text + "','"
                + dropDownGradeLevel.Text + "','"
                + dropDownEmploymentStatus.Text + "')";
                // Define the connection to the DB:
                SqlConnection sqlConnect =
                    new SqlConnection(
                        WebConfigurationManager.ConnectionStrings
                        ["Lab1Database"].ConnectionString);
                // Create and Structure the Query Command:
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnect;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlQuery;
                // Execute the Query and Retrieve the Results
                sqlConnect.Open();
                sqlCommand.ExecuteScalar(); // Used for other than SELECT Queries
                sqlConnect.Close();
                // 2. Update the ListBox
                lstStudents.Items.Clear();
                updateFromDB();
                buttonStatus.Text = "Student " + txtFirstName.Text + " " + txtLastName.Text + " Successfully Committed";
            }
        }
        //Method to Update Student from Database
        protected void updateFromDB()
        {
            // Create the Query:
            String sqlQuery =
            "SELECT FirstName + ' ' + LastName AS StudentName, StudentID FROM Student";
            // Define the connection to the DB:
            SqlConnection sqlConnect =
                new SqlConnection(
                    WebConfigurationManager.ConnectionStrings
                    ["Lab1Database"].ConnectionString);
            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQuery;
            // Execute the Query and Retrieve the Results
            sqlConnect.Open();
            SqlDataReader queryResults = sqlCommand.ExecuteReader();
            // Read the results and populate the ListBox
            while (queryResults.Read())
            {
                lstStudents.Items.Add(
                    new ListItem(
                    queryResults["StudentName"].ToString(), queryResults
                    ["StudentID"].ToString()
                        ));
            }
            sqlConnect.Close();
            queryResults.Close();
        }


        //Method to Save Student to Array when "Save Student" button is pressed
        protected void btnSave_Click2(object sender, EventArgs e)
        {
            
            int index;
            for (int i = 0; i < Student.studentArray.Length; i++)
            {
                if (Student.studentArray[i] == null)
                {
                    index = i;
                    String studentName = txtFirstName.Text + ' ' + txtLastName.Text;
                    Student.studentArray[index] = new Student(studentName, txtEmail.Text, txtPhoneNumber.Text, txtMajor.Text, txtGraduationDate.Text, dropDownGradeLevel.Text, dropDownEmploymentStatus.Text);
                    buttonStatus.Text = "Student " + txtFirstName.Text + " " + txtLastName.Text + "  Successfully Saved";
                }
            }
            
        }
    }
}