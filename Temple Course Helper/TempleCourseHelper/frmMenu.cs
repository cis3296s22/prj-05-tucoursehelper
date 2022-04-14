using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TempleCourseHelper
{
    public partial class frmMenu : Form
    {
        //Worker Class
        Worker worker = new Worker();
        //Dictionary for course details
        Dictionary<int, CourseDetails> CourseSchedule = new Dictionary<int, CourseDetails>();
        String searchResult = "",ratingResult = "";
        int i = 0;

        string[] emailList = new string[] {
            "@gmail.com",
            "@temple.edu",
            "@yahoo.com",
            "@hotmail.com",
            "@outlook.com",
            "@aol.com",
            "@msn.com"
        };


        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Checks if all textboxes have a valid input
            if (badInput(txtBoxCourse1)||badInput(txtBoxCourse2)||badInput(txtBoxCourse3)||badInput(txtBoxCourse4)||badInput(cbCourse1)||badInput(cbCourse2)||badInput(cbCourse3)||badInput(cbCourse4))
            {
                MessageBox.Show("Boxes are empty or entry is invalid");
            }
            else
            {
                string[] courseNumbers = new string[]
                {
                    txtBoxCourse1.Text,
                    txtBoxCourse2.Text,
                    txtBoxCourse3.Text,
                    txtBoxCourse4.Text
                };
                string[] courseLetters = new string[]
               {
                    cbCourse1.Text.ToUpper(),
                    cbCourse2.Text.ToUpper(),
                    cbCourse3.Text.ToUpper(),
                    cbCourse4.Text.ToUpper()
               };

                CourseSchedule = worker.searchCatalog(courseLetters, courseNumbers);

              
                foreach (KeyValuePair<int, CourseDetails> kv in CourseSchedule)
                {
                    ratingResult = kv.Value.getProfessorRating();
                    if (ratingResult != "No Rating")
                    {
                        ratingResult = ratingResult + "/100";
                    }
                    searchResult += "\n______________________________________________________________________________________________"
                    + "\n" + kv.Value.getCourseName() + " " + courseNumbers[i] + "-" + kv.Value.getCourseSection() + "\n"
                    + "Days: " + kv.Value.getCourseDays() + " Times: " + kv.Value.getCourseTime() + "\n"
                    + "Professor: " + kv.Value.getCourseProfessor() + " Rating: " + ratingResult
                    + " Credits: " + kv.Value.getCourseCredit() + "\n"
                    + kv.Value.getCourseDescription();
                    
                    i++;
                }
                lblResults.Text = searchResult;
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            
            if (badInput(txtBoxEmail))
            {
                MessageBox.Show("Bot is empty or email is invalid");
            }
            else 
            {
                //Code to send via Twilio
                String email = txtBoxEmail.Text;
                worker.setEmail(email);
                MessageBox.Show("Email has been send to: " + email);
                

            }
            

        }
        private bool badInput(Control ctrl)
        {
            //Checks input for course codes
            if (ctrl.Name.Equals("txtBoxCourse1") || ctrl.Name.Equals("txtBoxCourse2") || ctrl.Name.Equals("txtBoxCourse3") || ctrl.Name.Equals("txtBoxCourse4"))
            {
                //Checks if the box is not empty and if the course code is 4 keys in length
                if (ctrl.Text.Length == 4 && !ctrl.Text.Contains(" "))
                {
                    return false;
                }
            }
            //Checks input for email
            else if (ctrl.Name.Equals("txtBoxEmail"))
            {
                //Checks if the box is empty, is a valid email inbox or is less than 4 charecters meaning user cant write "@.com"
                for (int i = 0; i < emailList.Length; i++)
                {
                    if (ctrl.Text.ToLower().Contains(emailList[i]) && ctrl.Text.IndexOf("@") != 0 && !ctrl.Text.Contains(" "))
                    {
                        return false;
                    }
                }
            }
            //Checks input for course letters
            else
            {
                //Checks if the box is not empty and if the course code is 4 keys in length
                if (ctrl.Text != "" && !ctrl.Text.Contains(" "))
                {
                    return false;
                }
            }
            return true;
        }
        private void disableControl(Control ctrl)
        {
            ctrl.Enabled = false;
            ctrl.Visible = false;
        }
        private void enableControl(Control ctrl)
        {
            ctrl.Enabled = true;
            ctrl.Visible = true;
        }

        private void btnEnterID_Click(object sender, EventArgs e)
        {
            //replaces all whitespaces \s with empty strings
            String IDChecker = Regex.Replace(txtBoxTUID.Text, @"\s", "");

            //checks if input is valid
            for (int i =0; i < IDChecker.Length; i++){
                if(char.IsNumber(IDChecker[i]) && IDChecker.Length >= 0)//<--Should be 9, is 0 for testing
                {
                    //Code for database
                    worker.setTUID(IDChecker);

                    //Disable and enables appropriate controls
                    disableControl(txtBoxTUID);
                    disableControl(btnEnterID);
                    disableControl(lblTUID);
                    enableControl(lblCourse1);
                    enableControl(lblCourse2);
                    enableControl(lblCourse3);
                    enableControl(lblCourse4);
                    enableControl(lblResults);
                    enableControl(lblEmail);
                    enableControl(btnSearch);
                    enableControl(btnSend);
                    enableControl(txtBoxCourse1);
                    enableControl(txtBoxCourse2);
                    enableControl(txtBoxCourse3);
                    enableControl(txtBoxCourse4);
                    enableControl(txtBoxEmail);
                    enableControl(cbCourse1);
                    enableControl(cbCourse2);
                    enableControl(cbCourse3);
                    enableControl(cbCourse4);
                }
                else
                {
                    MessageBox.Show("Please enter a valid 9-digit TUID");
                    return;
                }
            }
            
        }
    }
}