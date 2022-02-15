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
    public partial class ScholarshipPage : System.Web.UI.Page
    {
        public String queryCount;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Method to Populate Text Fields when "Populate Button" is pressed
        protected void populateScholarship_Click(object sender, EventArgs e)
        {
            txtName.Text = "Hendrix Foundation";
            txtScholarshipAmount.Text = "$25,000";
            txtYear.Text = "2022";
        }
        //Method to Clear Text Fields when "Clear Button" is pressed
        protected void clearScholarship_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtScholarshipAmount.Text = "";
            txtYear.Text = "";
        }
        //Method to Query for MemberID using Member Name
        //This is needed since our DDL utilizes MemberID as a Not-Null Foreign Key when creating a scholarship
        public int selectMemberID()
        {
            String sqlQueryMemberID = "Select MemberID FROM Member WHERE MemberName = '" + dropdownListMember.SelectedItem.Text + "'";
            // Define the connection to the DB:
            SqlConnection sqlConnect =
                new SqlConnection(
                    WebConfigurationManager.ConnectionStrings
                    ["Lab1Database"].ConnectionString);
            // Create and Structure the Query Command:
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlQueryMemberID;
            // Execute the Query and Retrieve the Results
            sqlConnect.Open();
            sqlCommand.ExecuteReader(); // Used for other than SELECT Queries
            sqlConnect.Close();

            return 1;
        }
        //Checks Duplication of Records. Checks to see if Scholarship Name is same
        protected Boolean duplication()
        {
            String sqlQueryStudentName = "Select COUNT(ScholarshipName) AS ScholarshipName FROM Scholarship WHERE ScholarshipName = '" + txtName.Text + "'";
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
                queryCount = queryResults["ScholarshipName"].ToString();
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
        //Method to Commit Scholarship to Database when "Commit Scholarship" button is pressed
        protected void commitScholarship_Click(object sender, EventArgs e)
        {
            Boolean x = duplication();

            if (x == true)
            {
                buttonStatus.Text = "Error: Scholarship Already Exists";
            }
            else
            {

                int memberID = selectMemberID();


                // Create the Query with Concatenation of Text Boxes:
                String sqlQuery = "INSERT INTO Scholarship (ScholarshipName, ScholarshipYear, ScholarshipAmount, MemberID) " +
                    "VALUES('"
                    + txtName.Text + "','"
                    + txtYear.Text + "','"
                    + txtScholarshipAmount.Text + "','"
                    + memberID + "')";
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

                // 3. Clear the UI
                txtName.Text = "";
                txtScholarshipAmount.Text = "";
                txtYear.Text = "";
                buttonStatus.Text = "SCHOLARSHIP " + txtName + "  Successfully Committed";
            }
        }
        //Method to Save Scholarship to an Instance Object of Scholarship type. Triggered by "Save Scholarship" Button
        protected void saveScholarship_Click(object sender, EventArgs e)
        {
            
            int index = -1;
            for (int i = 0; i < Scholarship.scholarshipArray.Length; i++)
            {
                if (Scholarship.scholarshipArray[i] == null)
                {
                    index = i;
                    Scholarship.scholarshipArray[index] = new Scholarship(txtName.Text, txtYear.Text, txtScholarshipAmount.Text);
                    buttonStatus.Text = "Scholarship " + txtName + "  Successfully Saved";
                }
            }
            
            
        }


    }
}