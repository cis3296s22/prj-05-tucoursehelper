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

    internal class DBConnector
    {
        private OleDbConnection myConnection;
        private OleDbDataAdapter myDataAdapter;
        private OleDbCommand myCommand = new OleDbCommand();
        private DataSet myDataSet;
        private string strSQL;

        public void setupConnection()
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=TempleUserDB.accdb;");
            strSQL = "SELECT * FROM UserSearches";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myDataSet = new DataSet("UserSearchesTable");
            myDataAdapter.Fill(myDataSet, "UserSearchesTable");
        }

        public void OpenCloseConnection()
        {
            myCommand.Connection = myConnection;
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            myConnection.Close();
        }
        public void AddDataToDB(string TUID, Dictionary<int, Dictionary<int, CourseDetails>> CourseSchedule)
        {
            int i = 1;
            foreach (KeyValuePair<int, Dictionary<int, CourseDetails>> kd in CourseSchedule)
            {
                int checker = 1;
                //Clear the search result
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

        public DataSet GetRecords(string TUID)
        {
            myCommand.CommandType = CommandType.Text;
            strSQL = "SELECT * FROM UserSearches WHERE (TUID) LIKE '%" + TUID + "%'";
            myDataAdapter.SelectCommand.CommandText = strSQL;
            myDataSet = new DataSet("SearchResults");
            myDataAdapter.Fill(myDataSet, "SearchResults");
            return myDataSet;

        }
    }
}
