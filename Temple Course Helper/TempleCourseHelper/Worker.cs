using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TempleCourseHelper
{
    internal class Worker
    {   
        private EmailBot bot = new EmailBot();
        private DBConnector DB = new DBConnector();

        //Dictionary of dictionary of class sections for different classes
        private Dictionary<int, Dictionary<int,CourseDetails>> CourseSchedule = new Dictionary<int, Dictionary<int,CourseDetails>>();
        
        private string CoursicleURL = "https://www.coursicle.com/temple/";
        private string TUID = "", email = "", info = "";

        public Dictionary<int, Dictionary<int, CourseDetails>> searchCatalog(string[] courseLetters,string[] courseNumbers)
        {
            int section = 1;
            //Open Chrome "headless" or not visible to user
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            //Add chrom exe location
            //driver = new ChromeDriver(chromeOptions);
            IWebDriver driver = new ChromeDriver(@"../../" + "/Resources/");

            //Goes to Coursicle
            driver.Navigate().GoToUrl(CoursicleURL);
            Thread.Sleep(500);

            //Clears any contents in CourseSchedule
            CourseSchedule.Clear();

            //Searches 4 classes
            for (int i = 0; i < courseNumbers.Length; i++)
            {
                section = 1;
                //Dictionary for class sections
                Dictionary<int, CourseDetails> ClassSection = new Dictionary<int, CourseDetails>();

                //Searches course, tries twice
                try
                {
                    driver.FindElement(By.Id("searchBox")).SendKeys(courseLetters[i] + " " + courseNumbers[i]);
                    Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    driver.Navigate().GoToUrl(CoursicleURL);
                    Thread.Sleep(500);
                    driver.FindElement(By.Id("searchBox")).SendKeys(courseLetters[i] + " " + courseNumbers[i]);
                    Thread.Sleep(500);
                }

                while (true)
                {
                    CourseDetails courseDetails = new CourseDetails();
                    //Sets course number
                    courseDetails.setCourseCode(courseNumbers[i]);

                    //Selects result
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div["+section+"]/div[9]/div[3]")).Click();
                    }
                    catch (Exception NoSuchElementException)
                    {
                        //If the first section doesnt exist, null will be returned else there is no more sections to add
                        if (section == 1)
                        {
                            driver.Close();
                            return null;
                        }
                        else
                        {
                            break;
                        }
                    }

                    //Get Section/Title/Instructor/Days/Times
                    courseDetails.setCourseSection(driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div["+section+"]/div[9]/div[2]/div[2]/span[3]")).Text);
                    courseDetails.setCourseName(driver.FindElement(By.ClassName("abbrevTitle")).Text);//Doesnt need xpath since the name is not unique per section
                    courseDetails.setCourseProfessor(driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div["+section+"]/div[9]/div[2]/div[3]/div[2]/div[1]")).Text);
                    
                    //Tries to get rating, not all professors have them
                    try
                    {
                        courseDetails.setProfessorRating(driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div["+section+"]/div[9]/div[2]/div[3]/div[2]/div[2]")).Text);
                    }
                    catch (Exception NoSuchElementException)
                    {
                        courseDetails.setProfessorRating("No Rating");
                    }
                   
                    //Tries to get time, some classes provide two time creating two different element id's
                    try //Multiple times
                    {
                        courseDetails.setCourseTime(driver.FindElement(By.CssSelector("#cardContainer > div:nth-child("+section+") > div.wrap > div.card.back > div.courseNameBack > div.time.twoTimes")).Text);
                    }
                    catch (Exception NoSuchElementException) // One time
                    {
                        courseDetails.setCourseTime(driver.FindElement(By.CssSelector("#cardContainer > div:nth-child("+section+") > div.wrap > div.card.back > div.courseNameBack > div.time")).Text);
                    }
                    courseDetails.setCourseDays(driver.FindElement(By.ClassName("days")).Text);

                    if (section == 1)
                    {
                        //Click small info circle
                        driver.FindElement(By.CssSelector("#cardContainer > div:nth-child("+section+") > div.wrap > div.card.back > div.infoIcon > i")).Click();
                        Thread.Sleep(200);

                        //Get course description and credits
                        courseDetails.setCourseDescription(driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div[2]/div[1]/div[1]")).Text);
                        courseDetails.setCourseCredit(driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div[2]/div[1]/div[7]")).Text);
                        //Close extra info box
                        driver.FindElement(By.CssSelector("#descriptionModal > div > div > div.modal-body > div.centerButton > button")).Click();
                    }
                   
                    //Section is iterator for html elements for different sections & is an iterator for dictionaries int key
                    ClassSection.Add(section, courseDetails);
                    section++;
                }
                driver.FindElement(By.Id("searchBox")).Clear();
                CourseSchedule.Add((i + 1), ClassSection);
            }

            //Call Setup DB connection
            DB.setupConnection();

            if (checkRecords())
            {
                UpdateRecords();
            }
            else
            {
                //adding data to database
                DB.AddDataToDB(TUID, CourseSchedule);
            }

            driver.Close();
            return CourseSchedule;
        }

       // public Dictionary<int, CourseDetails> getUserInfo(string ID)
        //{
            //Fill CourseSchedule with previous search of the user
        //    return CourseSchedule;
       // }
        public void setTUID(string TUID)
        {
            this.TUID = TUID;
        }

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setInfo(string info)
        {
            this.info = info;
        }

        public async Task sendEmail(string email, string info)
        {
            await bot.Main(email, info);
        }
        public bool checkRecords()
        {
            //Call Setup DB connection
            DB.setupConnection();
             return DB.checkRecords(TUID);

        }
        
        public DataSet GetRecords()
        {
            DataSet ds = new DataSet();
            if (checkRecords())
            {
                ds = DB.GetRecords(TUID);
            }
            return ds;
        }

        public void UpdateRecords()
        {
            //Call Setup DB connection
            DB.setupConnection();

            //call update search 
            DB.UpdateSearch(TUID, CourseSchedule);

        }
    }
}
