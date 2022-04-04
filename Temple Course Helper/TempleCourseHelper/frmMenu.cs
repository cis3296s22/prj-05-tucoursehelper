using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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


        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Checks if all textboxes have a valid input
            if (badInput(txtBoxCourse1)|| badInput(txtBoxCourse2) || badInput(txtBoxCourse3)|| badInput(txtBoxCourse4))
            {
                MessageBox.Show("Either all boxes have not been filled\nOr the course number is invalid");
            }
            else
            {
                Course = worker.searchCatalog();
            }
        }
        private bool badInput(Control ctrl)
        {
            //Checks if the box is not empty and if the course code is 4 keys in length
            if (ctrl.Text == "" || ctrl.Text.Length != 4)
            {
                return true;
            }
            else
            {
                return false;
            }
       
        }
    }
}