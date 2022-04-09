using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;



namespace TempleCourseHelper
{

    internal class DBConnector
    {
        OleDbConnection myConnection;
        OleDbDataAdapter myDataAdapter;
        OleDbCommand myCommand = new OleDbCommand();
        DataSet myDataSet;
        string strSQL;

        public void setupConnection()
        {
            myConnection = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source=TempleUserDB.accdb;");
            strSQL = "SELECT * FROM UserSearches";
            myDataAdapter = new OleDbDataAdapter(strSQL, myConnection);
            myDataSet = new DataSet("UserSearchesTable");
            myDataAdapter.Fill(myDataSet, "UserSearchesTable");
        }
        public void AddDataToDB(String TUID,Dictionary<int, CourseDetails> CourseSchedule)
        {
            int i = 1;
            foreach (KeyValuePair<int, CourseDetails> keyValue in CourseSchedule)
            {
                myCommand.CommandType = CommandType.Text;
                myCommand.CommandText = "INSERT INTO UserSearches VALUES ('"+(TUID+"-0"+i)+"','"+keyValue.Value.getCourseCode()+"','"+keyValue.Value.getCourseSection()+"','"+keyValue.Value.getCourseName()+"','"+keyValue.Value.getCourseProfessor()+"','"+keyValue.Value.getProfessorRating()+"','"+keyValue.Value.getCourseTime()+"','"+keyValue.Value.getCourseDays()+"','"+keyValue.Value.getCourseCredit()+"','"+keyValue.Value.getCourseDescription()+"')";
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();

                i++;
            }
            
        }
    }
}
