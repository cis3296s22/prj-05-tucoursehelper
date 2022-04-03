using System;
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
        Worker worker = new Worker();
        Dictionary<string, CourseDetails> Course = new Dictionary<string, CourseDetails>();
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Course = worker.searchCatalog();
        }
    }
}