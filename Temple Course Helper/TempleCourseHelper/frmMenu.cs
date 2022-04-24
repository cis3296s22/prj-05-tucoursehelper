using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TempleCourseHelper
{
    /// <summary>  
    /// frmMenu is the class for the GUI. When every button on the interface is pressed, its action is handled by this class.
    /// </summary>  
    public partial class frmMenu : Form
    {
        //Worker Class
        private Worker worker = new Worker();

        //Dictionary for course details
        private Dictionary<int, Dictionary<int, CourseDetails>> CourseSchedule = new Dictionary<int, Dictionary<int, CourseDetails>>();
       
        private string searchResult = "",ratingResult = "", info="";
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

        /// <summary>  
        /// Constructor.
        /// </summary> 
        public frmMenu()
        {
            InitializeComponent();
        }

        /// <summary>  
        /// Search button from the Interface.
        /// When this button is pressed, the input will be validated just to make sure all 4 boxes are filled and sets the letters and the numbers.
        /// </summary>  
        /// <param name="sender">Parameter used by default to specify the action and the event when creating the class.</param>  
        /// <param name="e">Parameter used by default to specify the action and the event when creating the class.</param>  
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

                if (CourseSchedule == null)
                {
                    MessageBox.Show("Error, you either entered incorrect course letters or the class doesn't exist currently");
                }
                else
                {
                    this.Size = new Size(1800, 850);
                    disableControl(dgvResults);
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
                    enableControl(btnSearchAgain);

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

                            searchResult += "\n______________________________________________________"
                              + "\n" + kv.Value.getCourseName() + " " + kv.Value.getCourseCode() + "-" + kv.Value.getCourseSection()
                              + "\nDays: " + kv.Value.getCourseDays() + " Times: " + kv.Value.getCourseTime()
                              + "\nProfessor: " + kv.Value.getCourseProfessor()
                              + "\nRating: " + ratingResult;

                            if (kv.Key == 1)
                            {
                                searchResult += "\nCredits: " + kv.Value.getCourseCredit()
                                    + "\n" + kv.Value.getCourseDescription();
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
                        info += searchResult;
                    }
                }
            }
        }

        /// <summary>  
        /// Send button from the Interface.
        /// When this button is pressed, the email will be sent to the user unless there is an invalid entry.
        /// </summary>  
        /// <param name="sender">Parameter used by default to specify the action and the event when creating the class.</param>  
        /// <param name="e">Parameter used by default to specify the action and the event when creating the class.</param> 
        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (badInput(txtBoxEmail))
            {
                MessageBox.Show("Bot is empty or email is invalid");
            }
            else
            {
                //Code to send via Twilio
                string email = txtBoxEmail.Text;
                worker.setEmail(email);
                await worker.sendEmail(email, info);
                MessageBox.Show("Email has been send to: " + email);
            }
        }

        /// <summary>  
        /// Validating the user's entry when searching for the classes.
        /// </summary>  
        /// <param name="ctrl">Parameter used by default.</param>
        /// <returns> Returns Yes or No if the input is valid or not.</returns>
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

        /// <summary>  
        /// Default class to handle the visibility if the components on the Interface.
        /// </summary>  
        /// <param name="ctrl">Parameter used by default.</param>  
        private void disableControl(Control ctrl)
        {
            ctrl.Enabled = false;
            ctrl.Visible = false;
        }

        /// <summary>  
        /// Default class to handle the visibility if the components on the Interface.
        /// </summary>  
        /// <param name="ctrl">Parameter used by default.</param>  
        private void enableControl(Control ctrl)
        {
            ctrl.Enabled = true;
            ctrl.Visible = true;
        }

        /// <summary>  
        /// Search Again button from the Interface.
        /// When this button is pressed, the user will be able to Search Again for the class they want.
        /// </summary>  
        /// <param name="sender">Parameter used by default to specify the action and the event when creating the class.</param>  
        /// <param name="e">Parameter used by default to specify the action and the event when creating the class.</param> 
        private void btnSearchAgain_Click(object sender, EventArgs e)
        {
            disableControl(lblResults1);
            disableControl(lblResults2);
            disableControl(lblResults3);
            disableControl(lblResults4);
            disableControl(lblEmail);
            disableControl(txtBoxEmail);
            disableControl(btnSend);
            disableControl(btnSearchAgain);
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
            enableControl(dgvResults);

            dgvResults.DataSource = (worker.GetRecords()).Tables["SearchResults"].DefaultView;
        }

        /// <summary>  
        /// Send button from the Interface.
        /// When this button is pressed, the email will be sent to the user unless there is an invalid entry.
        /// </summary>  
        /// <param name="sender">Parameter used by default.</param>  
        /// <param name="e">Parameter used by default.</param> 
        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500,500);
            int centerW = this.Width / 2, centerH = this.Height / 2;
            lblTUID.Location = new Point(centerW-100,centerH-30);
            txtBoxTUID.Location = new Point(centerW-30, centerH-33);
            btnEnterID.Location = new Point(centerW -30 , centerH);
        }

        /// <summary>  
        /// Enter ID button from interface.
        /// When this button is pressed, the user's ID will be validated for its length(9 digits) and then search if there is previous record.
        /// If there is, the previous search will be displayed on the next page, if not then they will be a new user.
        /// </summary>  
        /// <param name="sender">Parameter used by default to specify the action and the event when creating the class.</param>  
        /// <param name="e">Parameter used by default to specify the action and the event when creating the class.</param> 
        private void btnEnterID_Click(object sender, EventArgs e)
        {
            //replaces all whitespaces \s with empty strings
            string IDChecker = Regex.Replace(txtBoxTUID.Text, @"\s", "");
            bool checkerPass = true;
            //checks if input is valid
            for (int i = 0; i < IDChecker.Length; i++)
            {
                if (!char.IsNumber(IDChecker[i]) || IDChecker.Length != 9)
                {
                    checkerPass = false;
                    break;
                }
            }

            if (checkerPass)
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