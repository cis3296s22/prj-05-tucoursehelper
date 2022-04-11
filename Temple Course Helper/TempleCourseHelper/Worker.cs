using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
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
        Dictionary<int, CourseDetails> CourseSchedule = new Dictionary<int, CourseDetails>();
        String CoursicleURL = "https://www.coursicle.com/temple/";

        public Dictionary<int, CourseDetails> searchCatalog(String[] courseLetters,String[] courseNumbers)
        {
            //Open Chrome "headless" or not visible to user
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");

            //Add chrom exe location
            //driver = new ChromeDriver(chromeOptions);
            IWebDriver driver = new ChromeDriver(@"../../" + "/Driver/");

            //Goes to Coursicle
            driver.Navigate().GoToUrl(CoursicleURL);
            Thread.Sleep(3);

            //Searches 4 classes
            for (int i = 0; i < courseNumbers.Length; i++)
            {
                CourseDetails courseDetails = new CourseDetails();
                //Searches course

                driver.FindElement(By.Id("searchBox")).SendKeys( courseLetters[i] + " " + courseNumbers[i]);
                Thread.Sleep(500);

                //Selects result                                //This div iterates\/
                driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div[1]/div[9]/div[3]")).Click();

                //Get Section/Title/Instructor/Days/Times
                courseDetails.setCourseSection(driver.FindElement(By.ClassName("section")).Text);
                courseDetails.setCourseName(driver.FindElement(By.ClassName("abbrevTitle")).Text);
                courseDetails.setCourseProfessor(driver.FindElement(By.ClassName("instructor")).Text);
                //Tries to get rating, not all professors have them
                try
                {
                    courseDetails.setProfessorRating(driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div[2]/div/div[1]/div[9]/div[2]/div[3]/div[2]/div[2]")).Text);
                }
                catch (Exception NoSuchElementException)
                {
                    courseDetails.setProfessorRating(null);
                }
                //courseDetails.setCourseTime(driver.FindElement(By.ClassName("")).Text);//Add time here
                courseDetails.setCourseDays(driver.FindElement(By.ClassName("days")).Text);
                //Click small info circle
                driver.FindElement(By.CssSelector("#cardContainer > div:nth-child(1) > div.wrap > div.card.back > div.infoIcon > i")).Click();
                Thread.Sleep(100);

                //Get course description and credits
                courseDetails.setCourseDescription(driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div[2]/div[1]/div[1]")).Text);
                courseDetails.setCourseCredit(driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div/div/div[2]/div[1]/div[7]")).Text);
                //Close extra info box
                driver.FindElement(By.CssSelector("#descriptionModal > div > div > div.modal-body > div.centerButton > button")).Click();
                Thread.Sleep(1);

                CourseSchedule.Add((i + 1), courseDetails);
                driver.FindElement(By.Id("searchBox")).Clear();
            }

            //Call Setup DB connection

            //Call setDBData

            driver.Close();
            return CourseSchedule;
        }

        public Dictionary<int, CourseDetails> getUserInfo(String ID)
        {
            //Fill CourseSchedule with previous search of the user
            return CourseSchedule;
        }
    }
}
