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
        Dictionary<string, CourseDetails> Course = new Dictionary<string, CourseDetails>();

        string[] emailList = new string[] {
            "@gmail.com",
            "@temple.edu",
            "@yahoo.com",
            "@hotmail.com",
            "@outlook.com",
            "@aol.com",
            "@msn.com"};

        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Checks if all textboxes have a valid input
            if (badInput(txtBoxCourse1)|| badInput(txtBoxCourse4) || badInput(txtBoxCourse3)|| badInput(txtBoxCourse2))
            {
                MessageBox.Show("Either all boxes have not been filled\nOr the course number is invalid");
            }
            else
            {
                Course = worker.searchCatalog();
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (badInput(txtBoxEmail))
            {
                MessageBox.Show("Either the box has not been filled\nOr the email is invalid (Illegal charecter or incorrect mailbox)");
            }
            else 
            {
                MessageBox.Show("Email has been send to: " + txtBoxEmail.Text.ToLower());
                //Code to send via Twilio
            }
        }
        private bool badInput(Control ctrl)
        {
            //Will skip this if not txtBoxEmail
            if (!ctrl.Name.Equals("txtBoxEmail"))
            {
                //Checks if the box is not empty and if the course code is 4 keys in length
                if (ctrl.Text.Length == 4 && !ctrl.Text.Contains(" "))
                {
                    return false;
                }
            }
            else
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
            //Code for database


            //replaces all whitespaces \s with empty strings
            String IDChecker = Regex.Replace(txtBoxTUID.Text, @"\s", "");

            //checks if input is valid
            for (int i =0; i < IDChecker.Length; i++){
                if(char.IsNumber(IDChecker[i]) && IDChecker.Length == 9)
                {
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