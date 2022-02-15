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
    public partial class MemberPage : System.Web.UI.Page
    {
        public String queryCount;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Method to Populate Text Fields when "Populate Button" is pressed
        protected void btnPopulate_Click(object sender, EventArgs e)
        {
            txtMemberName.Text = "Jeremey Ezell";
            txtEmailAddress.Text = "ezell2@dukes.jmu.edu";
            txtMemberGradYear.Text = "2000";
            txtPhoneNumber.Text = "5643247657";
            dropDownTitle.SelectedItem.Text = "Dr.";
        }
       
        //Method to Clear Text Fields when "Clear Button" is pressed
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtMemberName.Text = "";
            txtEmailAddress.Text = "";
            txtMemberGradYear.Text = "";
            txtPhoneNumber.Text = "";
            dropDownTitle.SelectedItem.Text = "Select Preffered Title";
        }
        //Checks Duplication of Records. Checks to see if Member Email is same
        protected Boolean duplication()
        {
            String sqlQueryStudentName = "Select COUNT(EmailAddress) AS Email FROM Member WHERE EmailAddress = '" + txtEmailAddress.Text + "'";
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
        //Method to Commit Member to Database when "Commit Member" button is pressed
        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            Boolean x = duplication();

            if (x == true)
            {
                buttonStatus.Text = "Error: Member Already Exists";
            }
            else
            {
                // Create the Query with Concatenation of Text Boxes:
                String sqlQuery = "INSERT INTO Member (Title, MemberName, EmailAddress, PhoneNumber,  GraduationYear) " +
                "VALUES('"
                + dropDownTitle.Text + "','"
                + txtMemberName.Text + "','"
                + txtEmailAddress.Text + "','"
                + txtPhoneNumber.Text + "','"
                + txtMemberGradYear.Text + "')";
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
                sqlCommand.ExecuteReader(); // Used for other than SELECT Queries
                sqlConnect.Close();

                // 3. Clear the UI
                txtMemberName.Text = "";
                txtMemberGradYear.Text = "";
                txtEmailAddress.Text = "";
                txtPhoneNumber.Text = "";
                dropDownTitle.SelectedItem.Text = "Select Preffered Title";
                buttonStatus.Text = "Member " + txtMemberName.Text + " Successfully Committed";
            }
        }

    
    }
}