﻿using System;
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
        private Worker worker = new Worker();
        //Dictionary for course details
        Dictionary<int, Dictionary<int, CourseDetails>> CourseSchedule = new Dictionary<int, Dictionary<int, CourseDetails>>();
        private String searchResult = "",ratingResult = "";
        private int i = 0;

        private string[] emailList = new string[] {
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
                MessageBox.Show("Either all boxes have not been filled\n\tOr the entry is invalid");
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

                if (CourseSchedule == null)
                {
                    searchResult = "Error, you either entered incorrect course letters or the class doesn't exist currently";
                }
                else
                {
                    this.Size = new Size(2200, 800);
                    disableControl(lblCourse1);
                    disableControl(lblCourse2);
                    disableControl(lblCourse3);
                    disableControl(lblCourse4);
                    disableControl(btnSearch);
                    disableControl(txtBoxCourse1);
                    disableControl(txtBoxCourse2);
                    disableControl(txtBoxCourse3);
                    disableControl(txtBoxCourse4);
                    disableControl(txtBoxEmail);
                    disableControl(cbCourse1);
                    disableControl(cbCourse2);
                    disableControl(cbCourse3);
                    disableControl(cbCourse4);
                    enableControl(lblResults1);
                    enableControl(lblResults2);
                    enableControl(lblResults3);
                    enableControl(lblResults4);
                    enableControl(lblEmail);
                    enableControl(txtBoxEmail);
                    enableControl(btnSend);

                    //Reset i
                    i = 0;
                    foreach (KeyValuePair<int, Dictionary<int, CourseDetails>> kd in CourseSchedule)
                    {
                        //Clear the search result
                        searchResult = "";
                        var courseSections = kd.Value;
                        foreach (KeyValuePair<int, CourseDetails> kv in courseSections)
                        {
                            ratingResult = kv.Value.getProfessorRating();
                            if (ratingResult != "No Rating")
                            {
                                ratingResult = ratingResult + "/100";
                            }
                            searchResult += "\n__________________________________________________________________________________________"
                            + "\n" + kv.Value.getCourseName() + " " + kv.Value.getCourseCode() + "-" + kv.Value.getCourseSection() + "\n"
                            + "Days: " + kv.Value.getCourseDays() + " Times: " + kv.Value.getCourseTime() + "\n"
                            + "Professor: " + kv.Value.getCourseProfessor() + " Rating: " + ratingResult;

                            if (kv.Key == 1)
                            {
                                searchResult += " Credits: " + kv.Value.getCourseCredit() + "\n"
                                                + kv.Value.getCourseDescription();
                            }


                        }

                        //Each iteration will post the section into a different label
                        switch (i)
                        {
                            case 0:
                                lblResults1.Text = searchResult;
                                break;
                            case 1:
                                lblResults2.Text = searchResult;  
                                break;
                            case 2:
                                lblResults3.Text = searchResult;
                                break;
                            case 3:
                                lblResults4.Text = searchResult;
                                break;
                        }
                        i++;
                    }
                }
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

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500,500);
            int centerW = this.Width / 2, centerH = this.Height / 2;
            lblTUID.Location = new Point(centerW-100,centerH-30);
            txtBoxTUID.Location = new Point(centerW-30, centerH-33);
            btnEnterID.Location = new Point(centerW -30 , centerH);
        }

        private void btnEnterID_Click(object sender, EventArgs e)
        {
            //replaces all whitespaces \s with empty strings
            String IDChecker = Regex.Replace(txtBoxTUID.Text, @"\s", "");

            //checks if input is valid
            for (int i =0; i < IDChecker.Length; i++){
                if(char.IsNumber(IDChecker[i]) && IDChecker.Length >= 0)//<--Should be 9, is 0 for testing
                {
                    worker.setTUID(IDChecker);

                    //checks if previous search exists
                    if (worker.GetRecords().Tables["SearchResults"] != null)
                    {
                            enableControl(dgvResults);
                            this.Size = new Size(1200, 500);
                            //displays previous search
                            dgvResults.DataSource = (worker.GetRecords()).Tables["SearchResults"].DefaultView;
                        
                        
                    }
                    //Disable and enables appropriate controls
                    disableControl(txtBoxTUID);
                    disableControl(btnEnterID);
                    disableControl(lblTUID);
                    enableControl(lblCourse1);
                    enableControl(lblCourse2);
                    enableControl(lblCourse3);
                    enableControl(lblCourse4);
                    enableControl(btnSearch);
                    enableControl(txtBoxCourse1);
                    enableControl(txtBoxCourse2);
                    enableControl(txtBoxCourse3);
                    enableControl(txtBoxCourse4);
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