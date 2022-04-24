using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Data.OleDb;



namespace TempleCourseHelper
{
    /// <summary>  
    /// The class that connects the Database with our program and updates it or pulls the info when needed. 
    /// </summary>  

    public class DBConnector
    {
        private OleDbConnection myConnection;
        private OleDbDataAdapter myDataAdapter;
        private OleDbCommand myCommand = new OleDbCommand();
        private DataSet myDataSet;

        /// <summary>  
        /// Checks if there is record from previous search (Throws Exception). 
        /// </summary>   
        /// <returns>Returns yes or true based on the existance of previous record.</returns>  
        public static bool checkRecords()
        {
            throw new NotImplementedException();
        }

        private string strSQL;

        /// <summary>  
        /// Sets up the connection with the Database.
        /// </summary>  
        public void setupConnection()
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=TempleUserDB.accdb;");
            strSQL = "SELECT * FROM UserSearches";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myDataSet = new DataSet("UserSearchesTable");
            myDataAdapter.Fill(myDataSet, "UserSearchesTable");
        }

        /// <summary>  
        /// Closes and sets up a new connection with the database.
        /// Used when updating the Database.
        /// </summary>  
        public void OpenCloseConnection()
        {
            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }

        /// <summary>  
        /// Adds the data into the Database for the specific user.  
        /// </summary>  
        /// <param name="TUID">User's ID.</param>  
        /// <param name="CourseSchedule">Dictionary of dictionaries with the different classes and their different sections.</param>  
        public void AddDataToDB(string TUID, Dictionary<int, Dictionary<int, CourseDetails>> CourseSchedule)
        {
            int i = 1;
            foreach (KeyValuePair<int, Dictionary<int, CourseDetails>> kd in CourseSchedule)
            {
                int checker = 1;
                var courseSections = kd.Value;
                foreach (KeyValuePair<int, CourseDetails> kv in courseSections)
                {
                    //to get general info about course (as all other sections have the same info) we will only need the information out of the first iteration
                    if (checker == 1)
                    {
                        myCommand.CommandType = CommandType.Text;
                        myCommand.CommandText = "INSERT INTO UserSearches (TUID, CourseCode, CourseName, CourseCredit, CourseDesc)  VALUES ('" + (TUID + "-0" + i) + "','" + kv.Value.getCourseCode() + "','" + kv.Value.getCourseName() + "','" + kv.Value.getCourseCredit() + "','" + Regex.Replace(kv.Value.getCourseDescription(), "'", "") + "')";
                        OpenCloseConnection();
                    }

                    checker++;
                }
                i++;
            }
        }

        /// <summary>  
        /// Checks for existing record for the specific user based on their ID. 
        /// </summary>  
        /// <param name="TUID">User's ID.</param>   
        /// <returns>True or false based on the existance of record.</returns>  
        public bool checkRecords(string TUID)
        {
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = "SELECT (TUID) FROM UserSearches WHERE (TUID) LIKE '%" + TUID + "%'";
            myCommand.Connection = myConnection;
            myConnection.Open();

            //get the result from SQL statement
            var result = myCommand.ExecuteScalar();
            myConnection.Close();

            bool ifExists = result != null ? true : false;
            return ifExists;
            
        }

        /// <summary>  
        /// Gets the specific user's record. 
        /// </summary> 
        /// <param name="TUID">User's ID.</param>
        /// <returns>Dataset with the user's record.</returns>  
        public DataSet GetRecords(string TUID)
        {
            myCommand.CommandType = CommandType.Text;
            strSQL = "SELECT * FROM UserSearches WHERE (TUID) LIKE '%" + TUID + "%'";
            myDataAdapter.SelectCommand.CommandText = strSQL;
            myDataSet = new DataSet("SearchResults");
            myDataAdapter.Fill(myDataSet, "SearchResults");
            return myDataSet;

        }

        /// <summary>  
        /// Updates the Database for the user with their new search.  
        /// </summary>  
        /// <param name="TUID">user's ID.</param>  
        /// <param name="CourseSchedule">The new searched classes.</param>  
        public void UpdateSearch(string TUID, Dictionary<int, Dictionary<int, CourseDetails>> CourseSchedule)
        {
            myCommand.CommandType = CommandType.Text;
            myCommand.CommandText = "DELETE FROM UserSearches WHERE (TUID) LIKE '%" + TUID + "%'";
            OpenCloseConnection();
            AddDataToDB(TUID, CourseSchedule);
        }
    }
}
